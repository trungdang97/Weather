using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Weather.Data.V1;

namespace Weather.Business.V1
{
    public class DbUserRoleHandler : IUserRoleHandler
    {
        public async Task<OldResponse<AspnetRoles>> Create(UserRoleCreateRequestModel model)
        {
            try
            {
                using (var unitOfWork = new UnitOfWork())
                {
                    var data = AutoMapperUtils.AutoMap<UserRoleCreateRequestModel, AspnetRoles>(model);
                    data.RoleId = Guid.NewGuid();
                    data.LoweredRoleName = data.RoleName.ToLower();
                    data.CreatedOnDate = DateTime.Now;
                    unitOfWork.GetRepository<AspnetRoles>().Add(data);

                    if (model.RightList != null)
                    {
                        var rightsInRole = new List<Idm_RightsInRole>();
                        foreach (var rightId in model.RightList)
                        {
                            rightsInRole.Add(new Idm_RightsInRole()
                            {
                                Id = Guid.NewGuid(),
                                CreatedByUserId = data.CreatedByUserId,
                                CreatedOnDate = DateTime.Now,
                                RightId = rightId,
                                RoleId = data.RoleId
                            });
                        }
                        unitOfWork.GetRepository<Idm_RightsInRole>().AddRange(rightsInRole);
                    }

                    if (await unitOfWork.SaveAsync() >= 1)
                    {
                        return new OldResponse<AspnetRoles>()
                        {
                            Data = data,
                            DataCount = 1,
                            Message = Status.SUCCESS.ToString(),
                            Status = (int)Status.SUCCESS,
                            TotalCount = 1
                        };
                    }
                    else
                    {
                        return new OldResponse<AspnetRoles>()
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
                return new OldResponse<AspnetRoles>()
                {
                    Data = null,
                    DataCount = 0,
                    Message = ex.Message,
                    Status = (int)Status.FAILED,
                    TotalCount = 0
                };
            }
        }

        public async Task<OldResponse<UserRoleDeleteResponseModel>> Delete(Guid id)
        {
            try
            {
                using (var unitOfWork = new UnitOfWork())
                {
                    var data = unitOfWork.GetRepository<AspnetRoles>().GetAllIncluding(x => x.RoleId == id).FirstOrDefault();
                    if (data != null)
                    {
                        unitOfWork.GetRepository<Idm_RightsInRole>().DeleteRange(data.IdmRightsInRole);
                        unitOfWork.GetRepository<AspnetRoles>().Delete(data);
                        if (await unitOfWork.SaveAsync() >= 1)
                        {
                            return new OldResponse<UserRoleDeleteResponseModel>()
                            {
                                Data = new UserRoleDeleteResponseModel()
                                {
                                    Id = id,
                                    Message = Status.SUCCESS.ToString(),
                                    Name = data.RoleName,
                                    Result = (int)Status.SUCCESS
                                },
                                DataCount = 1,
                                Message = Status.SUCCESS.ToString(),
                                Status = (int)Status.SUCCESS,
                                TotalCount = 1
                            };
                        }
                        else
                        {
                            return new OldResponse<UserRoleDeleteResponseModel>()
                            {
                                Data = null,
                                DataCount = 0,
                                Message = Status.FAILED.ToString(),
                                Status = (int)Status.FAILED,
                                TotalCount = 0
                            };
                        }
                    }
                    else
                    {
                        return new OldResponse<UserRoleDeleteResponseModel>()
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
                return new OldResponse<UserRoleDeleteResponseModel>()
                {
                    Data = null,
                    DataCount = 0,
                    Message = ex.Message,
                    Status = (int)Status.FAILED,
                    TotalCount = 0
                };
            }
        }

        public async Task<OldResponse<List<UserRoleDeleteResponseModel>>> DeleteMany(List<Guid> listId)
        {
            throw new NotImplementedException();
        }

        public async Task<OldResponse<List<AspnetRoles>>> GetFilter(UserRoleFilterModel filter)
        {
            try
            {
                using (var unitOfWork = new UnitOfWork())
                {
                    var data = unitOfWork.GetRepository<AspnetRoles>().GetAllIncluding(x=>x.IdmRightsInRole);
                    if (filter.RoleId.HasValue)
                    {
                        var result = data.Where(x => x.RoleId == filter.RoleId);
                        return new OldResponse<List<AspnetRoles>>()
                        {
                            Data = await result.ToListAsync(),
                            DataCount = result.Count(),
                            Message = Status.SUCCESS.ToString(),
                            Status = (int)Status.SUCCESS,
                            TotalCount = result.Count()
                        };
                    }

                    return new OldResponse<List<AspnetRoles>>()
                    {
                        Data = await data.ToListAsync(),
                        DataCount = data.Count(),
                        Message = Status.SUCCESS.ToString(),
                        Status = (int)Status.SUCCESS,
                        TotalCount = data.Count()
                    };
                }
            }
            catch (Exception ex)
            {
                return new OldResponse<List<AspnetRoles>>()
                {
                    Data = null,
                    DataCount = 0,
                    Message = ex.Message,
                    Status = (int)Status.FAILED,
                    TotalCount = 0
                };
            }
        }

        public async Task<OldResponse<AspnetRoles>> Update(UserRoleUpdateRequestModel model)
        {
            try
            {
                using (var unitOfWork = new UnitOfWork())
                {
                    var data = unitOfWork.GetRepository<AspnetRoles>().Get(x => x.RoleId == model.RoleId).FirstOrDefault();
                    data.RoleName = model.RoleName;
                    data.Description = model.Description;
                    data.LoweredRoleName = data.RoleName.ToLower();
                    data.LastModifiedByUserId = model.LastModifiedByUserId;
                    data.LastModifiedOnDate = DateTime.Now;

                    var oldRights = unitOfWork.GetRepository<Idm_RightsInRole>().Get(x => x.RoleId == data.RoleId);
                    unitOfWork.GetRepository<Idm_RightsInRole>().DeleteRange(oldRights);
                    var newRights = new List<Idm_RightsInRole>();
                    foreach (var rightId in model.RightList)
                    {
                        newRights.Add(new Idm_RightsInRole()
                        {
                            Id = Guid.NewGuid(),
                            CreatedByUserId = data.CreatedByUserId,
                            CreatedOnDate = DateTime.Now,
                            RightId = rightId,
                            RoleId = data.RoleId
                        });
                    }

                    unitOfWork.GetRepository<AspnetRoles>().Update(data);
                    unitOfWork.GetRepository<Idm_RightsInRole>().AddRange(newRights);

                    if (await unitOfWork.SaveAsync() >= 1)
                    {
                        return new OldResponse<AspnetRoles>()
                        {
                            Data = data,
                            DataCount = 1,
                            Message = Status.SUCCESS.ToString(),
                            Status = (int)Status.SUCCESS,
                            TotalCount = 1
                        };
                    }
                    else
                    {
                        return new OldResponse<AspnetRoles>()
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
                return new OldResponse<AspnetRoles>()
                {
                    Data = null,
                    DataCount = 0,
                    Message = ex.Message,
                    Status = (int)Status.FAILED,
                    TotalCount = 0
                };
            }
        }
    }
}
