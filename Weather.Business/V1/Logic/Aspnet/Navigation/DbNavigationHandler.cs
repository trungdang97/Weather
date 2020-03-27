using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Weather.Data.V1;

namespace Weather.Business.V1
{
    public class DbNavigationHandler : INavigationHandler
    {
        public async Task<OldResponse<Navigation>> Create(NavigationCreateRequestModel model)
        {
            try
            {
                using (var unitOfWork = new UnitOfWork())
                {
                    var data = AutoMapperUtils.AutoMap<NavigationCreateRequestModel, Navigation>(model);
                    data.CreatedOnDate = DateTime.Now;
                    unitOfWork.GetRepository<Navigation>().Add(data);
                    if (await unitOfWork.SaveAsync() >= 1)
                    {
                        return new OldResponse<Navigation>()
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
                        return new OldResponse<Navigation>()
                        {
                            Data = data,
                            DataCount = 1,
                            Message = Status.FAILED.ToString(),
                            Status = (int)Status.FAILED,
                            TotalCount = 1
                        };
                    }
                }
            }
            catch (Exception ex)
            {
                return new OldResponse<Navigation>()
                {
                    Data = null,
                    DataCount = 0,
                    Message = ex.Message,
                    Status = (int)Status.FAILED,
                    TotalCount = 0
                };
            }
        }

        public async Task<OldResponse<NavigationDeleteResponseModel>> Delete(Guid id)
        {
            try
            {
                using (var unitOfWork = new UnitOfWork())
                {
                    var data = unitOfWork.GetRepository<Navigation>().Get(x => x.NavigationId == id).FirstOrDefault();
                    unitOfWork.GetRepository<Navigation>().Delete(data);
                    if (await unitOfWork.SaveAsync() >= 1)
                    {
                        return new OldResponse<NavigationDeleteResponseModel>()
                        {
                            Data = new NavigationDeleteResponseModel()
                            {
                                Id = id,
                                Message = Status.SUCCESS.ToString(),
                                Name = data.Name,
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
                        return new OldResponse<NavigationDeleteResponseModel>()
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
                return new OldResponse<NavigationDeleteResponseModel>()
                {
                    Data = null,
                    DataCount = 0,
                    Message = ex.Message,
                    Status = (int)Status.FAILED,
                    TotalCount = 0
                };
            }
        }

        public async Task<OldResponse<List<NavigationDeleteResponseModel>>> DeleteMany(List<Guid> listId)
        {
            try
            {
                using (var unitOfWork = new UnitOfWork())
                {
                    List<NavigationDeleteResponseModel> results = new List<NavigationDeleteResponseModel>();
                    foreach (var id in listId)
                    {
                        var result = await Delete(id);
                        results.Add(result.Data);
                    }
                    return new OldResponse<List<NavigationDeleteResponseModel>>()
                    {
                        Data = results,
                        DataCount = results.Count,
                        TotalCount = listId.Count,
                        Message = Status.SUCCESS.ToString(),
                        Status = (int)Status.SUCCESS
                    };
                }
            }
            catch (Exception ex)
            {
                return new OldResponse<List<NavigationDeleteResponseModel>>()
                {
                    Data = null,
                    DataCount = 0,
                    Message = ex.Message,
                    Status = (int)Status.FAILED,
                    TotalCount = 0
                };
            }
        }

        public async Task<OldResponse<List<Navigation>>> GetFilter(NavigationFilterModel filter)
        {
            try
            {
                using (var unitOfWork = new UnitOfWork())
                {
                    var results = new List<Navigation>();
                    var data = unitOfWork.GetRepository<Navigation>().GetAll();
                    if (filter.NavigationId.HasValue && filter.NavigationId != Guid.Empty)
                    {
                        var result = data.Where(x => x.NavigationId == filter.NavigationId).FirstOrDefault();
                        results.Add(result);
                        return new OldResponse<List<Navigation>>()
                        {
                            Data = results,
                            DataCount = 1,
                            Message = Status.SUCCESS.ToString(),
                            Status = (int)Status.SUCCESS,
                            TotalCount = 1
                        };
                    }
                    else
                    {
                        results = await data.ToListAsync();
                        return new OldResponse<List<Navigation>>()
                        {
                            Data = results,
                            DataCount = results.Count,
                            Message = Status.SUCCESS.ToString(),
                            Status = (int)Status.SUCCESS,
                            TotalCount = results.Count
                        };
                    }
                }
            }
            catch (Exception ex)
            {
                return new OldResponse<List<Navigation>>()
                {
                    Data = null,
                    DataCount = 0,
                    Message = ex.Message,
                    Status = (int)Status.FAILED,
                    TotalCount = 0
                };
            }
        }

        public async Task<OldResponse<Navigation>> Update(NavigationUpdateRequestModel model)
        {
            try
            {
                using (var unitOfWork = new UnitOfWork())
                {
                    var data = unitOfWork.GetRepository<Navigation>().Get(x => x.NavigationId == model.NavigationId).FirstOrDefault();
                    data.ParentId = model.ParentId;
                    data.Code = model.Code;
                    data.Name = model.Name;
                    data.Status = model.Status;
                    data.Order = model.Order;
                    data.HasChild = model.HasChild;
                    data.UrlRewrite = model.UrlRewrite;
                    data.IconClass = model.IconClass;
                    data.NavigationNameEn = model.NavigationNameEn;
                    data.LastModifiedByUserId = model.LastModifiedByUserId;
                    data.LastModifiedOnDate = DateTime.Now;
                    data.Level = model.Level;

                    if(await unitOfWork.SaveAsync() >= 1)
                    {
                        return new OldResponse<Navigation>()
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
                        return new OldResponse<Navigation>()
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
                return new OldResponse<Navigation>()
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
