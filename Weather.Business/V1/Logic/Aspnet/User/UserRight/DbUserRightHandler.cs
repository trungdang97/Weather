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
                    data.RightId = Guid.NewGuid();
                    if (data.IsGroup)
                    {
                        data.Level = 0;
                    }
                    else
                    {
                        var parent = unitOfWork.GetRepository<Idm_Right>().Get(x => x.RightId == data.GroupId).FirstOrDefault();
                        data.Level = parent.Level++;
                    }
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

        public async Task<OldResponse<UserRightDeleteResponseModel>> Delete(Guid id)
        {
            try
            {
                using (var unitOfWork = new UnitOfWork())
                {
                    var data = unitOfWork.GetRepository<Idm_Right>().Get(x => x.RightId == id).FirstOrDefault();
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

        public async Task<OldResponse<List<UserRightDeleteResponseModel>>> DeleteMany(List<Guid> listId)
        {
            try
            {
                using (var unitOfWork = new UnitOfWork())
                {
                    var results = new List<UserRightDeleteResponseModel>();
                    foreach(var id in listId)
                    {
                        var result = await Delete(id);
                        results.Add(result.Data);
                    }
                    return new OldResponse<List<UserRightDeleteResponseModel>>()
                    {
                        Data = results,
                        DataCount = results.Count,
                        Message = Status.SUCCESS.ToString(),
                        Status = (int)Status.SUCCESS,
                        TotalCount = listId.Count
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
                    if (filter.RightId.HasValue)
                    {
                        return new OldResponse<List<Idm_Right>>()
                        {
                            Data = await data.Where(x=>x.RightId == filter.RightId).ToListAsync(),
                            DataCount = 1,
                            Message = Status.SUCCESS.ToString(),
                            Status = (int)Status.SUCCESS,
                            TotalCount = 1
                        };
                    }

                    // default = get group with children
                    data = data.Where(x => x.IsGroup == true).Include(x=>x.InverseGroupIdNavigation);
                    foreach(var d in data)
                    {
                        d.InverseGroupIdNavigation = d.InverseGroupIdNavigation.OrderBy(x => x.Order).ToList();
                    }

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

        public async Task<OldResponse<Idm_Right>> IsRightCodeExist(string rightCode)
        {
            try
            {
                using(var unitOfWork = new UnitOfWork())
                {
                    var data = await unitOfWork.GetRepository<Idm_Right>().Get(x => x.RightCode == rightCode).ToListAsync();
                    if(data.Count > 0)
                    {
                        return new OldResponse<Idm_Right>()
                        {
                            Data = null,
                            DataCount = data.Count,
                            Message = Status.SUCCESS.ToString(),
                            Status = (int)Status.SUCCESS,
                            TotalCount = data.Count
                        };
                    }
                    else
                    {
                        return new OldResponse<Idm_Right>()
                        {
                            Data = null,
                            DataCount = data.Count,
                            Message = Status.SUCCESS.ToString(),
                            Status = (int)Status.SUCCESS,
                            TotalCount = data.Count
                        };
                    }
                }
            }
            catch(Exception ex)
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

        public async Task<OldResponse<Idm_Right>> Update(UserRightUpdateRequestModel model)
        {
            try
            {
                using (var unitOfWork = new UnitOfWork())
                {
                    var data = unitOfWork.GetRepository<Idm_Right>().Get(x => x.RightId == model.RightId).FirstOrDefault();
                    data.RightName = model.RightName;
                    data.Description = model.Description;
                    data.Status = model.Status;
                    data.Order = model.Order;
                    data.GroupId = model.GroupId;

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
