using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Weather.Data.V1;

namespace Weather.Business.V1
{
    public class DbUserRightHandler : IUserRightHandler
    {
        public async Task<OldResponse<Idm_Right>> Create(UserRightCreateRequestModel model)
        {
            try
            {
                using (var unitOfWork = new UnitOfWork())
                {
                    var data = AutoMapperUtils.AutoMap<UserRightCreateRequestModel, Idm_Right>(model);
                    data.CreatedOnDate = DateTime.Now;
                    unitOfWork.GetRepository<Idm_Right>().Add(data);

                    if (await unitOfWork.SaveAsync() >= 1)
                    {
                        return new OldResponse<Idm_Right>()
                        {
                            Data = data,
                            DataCount = 1,
                            Message = Status.SUCCESS.ToString(),
                            TotalCount = 1,
                            Status = (int)Status.SUCCESS
                        };
                    }
                    else
                    {
                        return new OldResponse<Idm_Right>()
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
                return new OldResponse<Idm_Right>()
                {
                    Data = null,
                    DataCount = 0,
                    Message = ex.Message,
                    Status = (int)Status.FAILED,
                    TotalCount = 0
                };
            }
        }

        public async Task<OldResponse<UserRightDeleteResponseModel>> Delete(string code)
        {
            try
            {
                using (var unitOfWork = new UnitOfWork())
                {
                    var data = unitOfWork.GetRepository<Idm_Right>().Get(x => x.RightCode == code).FirstOrDefault();
                    unitOfWork.GetRepository<Idm_Right>().Delete(data);

                    if (await unitOfWork.SaveAsync() >= 1)
                    {
                        return new OldResponse<UserRightDeleteResponseModel>()
                        {
                            Data = new UserRightDeleteResponseModel()
                            {
                                Id = Guid.Empty,
                                Message = Status.SUCCESS.ToString(),
                                Name = data.RightName,
                                Result = (int)Status.SUCCESS
                            },
                            DataCount = 1,
                            Status = (int)Status.SUCCESS,
                            Message = Status.SUCCESS.ToString(),
                            TotalCount = 1
                        };
                    }
                    else
                    {
                        return new OldResponse<UserRightDeleteResponseModel>()
                        {
                            Data = null,
                            DataCount = 0,
                            Status = (int)Status.FAILED,
                            Message = Status.FAILED.ToString(),
                            TotalCount = 0
                        };
                    }
                }
            }
            catch (Exception ex)
            {
                return new OldResponse<UserRightDeleteResponseModel>()
                {
                    Data = null,
                    DataCount = 0,
                    Message = ex.Message,
                    Status = (int)Status.FAILED,
                    TotalCount = 0
                };
            }
        }

        public async Task<OldResponse<List<UserRightDeleteResponseModel>>> DeleteMany(List<string> listCode)
        {
            try
            {
                using (var unitOfWork = new UnitOfWork())
                {
                    var results = new List<UserRightDeleteResponseModel>();
                    foreach(var code in listCode)
                    {
                        var result = await Delete(code);
                        results.Add(result.Data);
                    }
                    return new OldResponse<List<UserRightDeleteResponseModel>>()
                    {
                        Data = results,
                        DataCount = results.Count,
                        Message = Status.SUCCESS.ToString(),
                        Status = (int)Status.SUCCESS,
                        TotalCount = listCode.Count
                    };
                }
            }
            catch (Exception ex)
            {
                return new OldResponse<List<UserRightDeleteResponseModel>>()
                {
                    Data = null,
                    DataCount = 0,
                    Message = ex.Message,
                    Status = (int)Status.FAILED,
                    TotalCount = 0
                };
            }
        }

        public async Task<OldResponse<List<Idm_Right>>> GetFilter(UserRightFilterModel filter)
        {
            try
            {
                using (var unitOfWork = new UnitOfWork())
                {
                    var data = unitOfWork.GetRepository<Idm_Right>().GetAllIncluding();

                    return new OldResponse<List<Idm_Right>>()
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
                return new OldResponse<List<Idm_Right>>()
                {
                    Data = null,
                    DataCount = 0,
                    Message = ex.Message,
                    Status = (int)Status.FAILED,
                    TotalCount = 0
                };
            }
        }

        public async Task<OldResponse<Idm_Right>> Update(UserRightUpdateRequestModel model)
        {
            try
            {
                using (var unitOfWork = new UnitOfWork())
                {
                    var data = unitOfWork.GetRepository<Idm_Right>().Get(x => x.RightCode == model.RightCode).FirstOrDefault();
                    data.RightName = model.RightName;
                    data.Description = model.Description;
                    data.Status = model.Status;
                    data.Order = model.Order;
                    data.GroupCode = model.GroupCode;

                    if(await unitOfWork.SaveAsync() >= 1)
                    {
                        return new OldResponse<Idm_Right>()
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
                        return new OldResponse<Idm_Right>()
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
                return new OldResponse<Idm_Right>()
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
