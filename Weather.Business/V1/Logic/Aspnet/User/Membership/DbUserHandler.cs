using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using Weather.Data.V1;
using Microsoft.EntityFrameworkCore;

namespace Weather.Business.V1
{
    public class DbUserHandler : IUserHandler
    {
        public async Task<OldResponse<AspnetMembership>> Ban(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<OldResponse<AspnetMembership>> Create(UserCreateRequestModel model)
        {
            try
            {
                using (var unitOfWork = new UnitOfWork())
                {
                    var data = AutoMapperUtils.AutoMap<UserCreateRequestModel, AspnetMembership>(model);
                    data.UserId = Guid.NewGuid();
                    data.CreatedOnDate = DateTime.Now;

                    var salt = GetSalt();
                    data.PasswordSalt = Convert.ToBase64String(salt);
                    data.Password = Convert.ToBase64String(GetHash(data.Password, salt));
                    data.PasswordAnswer = Convert.ToBase64String(GetHash(data.PasswordAnswer, salt));
                    // AspUsers have PK in relationship, must be created first
                    unitOfWork.GetRepository<AspnetUsers>().Add(new AspnetUsers()
                    {
                        UserId = data.UserId,
                        UserName = model.Username,
                        LoweredUserName = model.Username.ToLower(),
                    });
                    unitOfWork.GetRepository<AspnetMembership>().Add(data);
                    
                    if(await unitOfWork.SaveAsync() >= 1)
                    {
                        return new OldResponse<AspnetMembership>()
                        {
                            Data = null,
                            DataCount = 1,
                            Message = Status.SUCCESS.ToString(),
                            Status = (int)Status.SUCCESS,
                            TotalCount = 1
                        };
                    }
                    else
                    {
                        return new OldResponse<AspnetMembership>()
                        {
                            Data = null,
                            DataCount = 0,
                            Message = Status.FAILED.ToString(),
                            Status = (int)Status.FAILED,
                            TotalCount = 0
                        };
                    }
                }
            }
            catch(Exception ex)
            {
                return new OldResponse<AspnetMembership>()
                {
                    Data = null,
                    DataCount = 0,
                    Message = ex.Message,
                    Status = (int)Status.FAILED,
                    TotalCount = 0
                };
            }
        }

        public async Task<OldResponse<UserRightDeleteResponseModel>> Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<OldResponse<List<AspnetMembership>>> GetFilter(UserFilterModel filter)
        {
            try
            {
                using (var unitOfWork = new UnitOfWork())
                {
                    var data = unitOfWork.GetRepository<AspnetMembership>().GetAll();
                    var totalCount = data.Count();
                    if (filter.UserId.HasValue)
                    {
                        return new OldResponse<List<AspnetMembership>>()
                        {
                            Data = await data.Where(x => x.UserId == filter.UserId).ToListAsync(),
                            DataCount = 1,
                            Message = Status.SUCCESS.ToString(),
                            Status = (int)Status.SUCCESS,
                            TotalCount = 1
                        };
                    }

                    int excludedRows = (filter.PageNumber - 1) * filter.PageSize;
                    data = data.Skip(excludedRows).Take(filter.PageSize);
                    //foreach(var user in data)
                    //{
                    //    user.DeleteDate = null;
                    //    user.Email = string.Format("{0}****{1}", user.Email[0], user.Email.Substring(user.Email.IndexOf('@') - 1));
                    //    user.FailedPasswordAnswerAttemptCount = 0;
                    //    user.FailedPasswordAnswerAttemptWindowStart = null;
                    //    user.FailedPasswordAttemptCount = 0;
                    //    user.FailedPasswordAttemptWindowStart = null;
                    //    user.HomePhone = null;
                    //    user.LastLockoutDate = null;
                    //    user.LastLoginDate = null;
                    //    user.LastModifiedByUserId = null;
                    //    user.LastModifiedOnDate = null;
                    //    user.LastPasswordChangedDate = null;
                    //    user.
                    //}

                    return new OldResponse<List<AspnetMembership>>()
                    {
                        Data = await data.ToListAsync(),
                        DataCount = data.Count(),
                        Message = Status.SUCCESS.ToString(),
                        Status = (int)Status.SUCCESS,
                        TotalCount = totalCount,
                    };
                }
            }
            catch (Exception ex)
            {
                return new OldResponse<List<AspnetMembership>>()
                {
                    Data = null,
                    DataCount = 0,
                    Message = ex.Message,
                    Status = (int)Status.FAILED,
                    TotalCount = 0
                };
            }
        }

        public async Task<OldResponse<AspnetMembership>> Lock(Guid id)
        {
            //try
            //{
            //    using (var unitOfWork = new UnitOfWork())
            //    {

            //    }
            //}
            //catch (Exception ex)
            //{

            //}
            throw new NotImplementedException();
        }

        public async Task<OldResponse<AspnetMembership>> Suspense(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<OldResponse<AspnetMembership>> Update(UserUpdateRequestModel model)
        {
            try
            {
                using (var unitOfWork = new UnitOfWork())
                {
                    var data = unitOfWork.GetRepository<AspnetMembership>().Get(x => x.UserId == model.UserId).FirstOrDefault();
                    
                    var oldHash = GetHash(model.OldPassword, Convert.FromBase64String(data.PasswordSalt));
                    var newHash = GetHash(model.Password, Convert.FromBase64String(data.PasswordSalt));
                    if (oldHash == newHash)
                    {
                        // update password
                        data.Password = Convert.ToBase64String(newHash);
                        data.PasswordSalt = Convert.ToBase64String(GetSalt());
                        unitOfWork.GetRepository<AspnetMembership>().Update(data);
                        if (await unitOfWork.SaveAsync() >= 1)
                        {
                            return new OldResponse<AspnetMembership>()
                            {
                                Data = null,
                                DataCount = 1,
                                Message = Status.SUCCESS.ToString(),
                                Status = (int)Status.SUCCESS,
                                TotalCount = 1
                            };
                        }
                        else
                        {
                            return new OldResponse<AspnetMembership>()
                            {
                                Data = null,
                                DataCount = 0,
                                Message = Status.FAILED.ToString(),
                                Status = (int)Status.FAILED,
                                TotalCount = 0
                            };
                        }
                    }
                    data.Comment = model.Comment;
                    data.FullName = model.FullName;
                    data.NickName = model.NickName;
                    data.MobilePhone = model.MobilePhone;
                    data.LastModifiedByUserId = model.LastModifiedByUserId;
                    data.LastModifiedOnDate = DateTime.Now;

                    unitOfWork.GetRepository<AspnetMembership>().Update(data);
                    if (await unitOfWork.SaveAsync() >= 1)
                    {
                        return new OldResponse<AspnetMembership>()
                        {
                            Data = null,
                            DataCount = 1,
                            Message = Status.SUCCESS.ToString(),
                            Status = (int)Status.SUCCESS,
                            TotalCount = 1
                        };
                    }
                    else
                    {
                        return new OldResponse<AspnetMembership>()
                        {
                            Data = null,
                            DataCount = 0,
                            Message = Status.FAILED.ToString(),
                            Status = (int)Status.FAILED,
                            TotalCount = 0
                        };
                    }
                }
            }
            catch (Exception ex)
            {
                return new OldResponse<AspnetMembership>()
                {
                    Data = null,
                    DataCount = 0,
                    Message = ex.Message,
                    Status = (int)Status.FAILED,
                    TotalCount = 0
                };
            }
        }

        private byte[] GetSalt()
        {
            byte[] salt = new byte[128 / 8];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }
            return salt;
        }
        private byte[] GetHash(string password, byte[] salt)
        {
            var hash = KeyDerivation.Pbkdf2(
                        password: password,
                        salt: salt,
                        prf: KeyDerivationPrf.HMACSHA256,
                        iterationCount: 10000,
                        numBytesRequested: 256 / 8);
            return hash;
        }
    }
}
