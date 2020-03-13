using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Weather.Data.V1;

namespace Weather.Business.V1
{
    public class DbNewsHandler : INewsHandler
    {
        public async Task<OldResponse<CMS_News>> Create(NewsCreateRequestModel model)
        {
            try
            {
                using (var unitOfWork = new UnitOfWork())
                {
                    var newModel = AutoMapperUtils.AutoMap<NewsCreateRequestModel, CMS_News>(model);
                    newModel.NewsId = Guid.NewGuid();

                    unitOfWork.GetRepository<CMS_News>().Add(newModel);
                    if (await unitOfWork.SaveAsync() >= 1)
                    {
                        return new OldResponse<CMS_News>(1, "SUCCESS", newModel)
                        {
                            DataCount = 1,
                            TotalCount = 1
                        };
                    }
                    else
                    {
                        return new OldResponse<CMS_News>(-1, "Failed to save", null);
                    }
                }
            }
            catch (Exception ex)
            {
                return new OldResponse<CMS_News>(-1, ex.Message, null);
            }
        }

        public async Task<OldResponse<NewsDeleteResponseModel>> Delete(Guid id)
        {
            try
            {
                using (var unitOfWork = new UnitOfWork())
                {
                    var model = unitOfWork.GetRepository<CMS_News>().Get(x => x.NewsId == id).FirstOrDefault();
                    unitOfWork.GetRepository<CMS_News>().Delete(model);

                    if (await unitOfWork.SaveAsync() >= 1)
                    {
                        return new OldResponse<NewsDeleteResponseModel>()
                        {
                            Data = new NewsDeleteResponseModel()
                            {
                                Id = id,
                                Name = model.Name,
                                Message = "Deleted",
                                Result = 1
                            },
                            Message = "SUCCESS",
                            Status = 1
                        };
                    }
                    else
                    {
                        return new OldResponse<NewsDeleteResponseModel>()
                        {
                            Data = new NewsDeleteResponseModel()
                            {
                                Id = id,
                                Name = model.Name,
                                Message = "Record have dependencies",
                                Result = -1
                            },
                            Message = "SUCCESS",
                            Status = 1
                        };
                    }
                }
            }
            catch (Exception ex)
            {
                return new OldResponse<NewsDeleteResponseModel>(-1, ex.Message, null);
            }
        }

        public async Task<OldResponse<List<NewsDeleteResponseModel>>> DeleteMany(List<Guid> listId)
        {
            try
            {
                List<NewsDeleteResponseModel> results = new List<NewsDeleteResponseModel>();
                foreach (var id in listId)
                {
                    var result = await Delete(id);
                    results.Add(result.Data);
                }
                return new OldResponse<List<NewsDeleteResponseModel>>(1, "SUCCESS", results);
            }
            catch (Exception ex)
            {
                return new OldResponse<List<NewsDeleteResponseModel>>(-1, ex.Message, null);
            }
        }

        public async Task<OldResponse<List<CMS_News>>> GetFilter(NewsFilterModel filter)
        {
            try
            {
                using (var unitOfWork = new UnitOfWork())
                {
                    var result = new List<CMS_News>();
                    var data = unitOfWork.GetRepository<CMS_News>().GetAllIncluding(x => x.Comments);

                    if (filter.Id.HasValue)
                    {
                        result = data.Where(x => x.NewsId == filter.Id).ToList();
                        return new OldResponse<List<CMS_News>>(1, "SUCCESS", result);
                    }

                    if (filter.NewsCategoryId.HasValue)
                    {
                        data = data.Where(x => x.NewsCategoryId == filter.NewsCategoryId);
                    }

                    if (filter.CreatedByUserId.HasValue)
                    {
                        data = data.Where(x => x.CreatedByUserId == filter.CreatedByUserId);
                    }

                    if (filter.IsHidden.HasValue)
                    {
                        data = data.Where(x => x.IsHidden == filter.IsHidden);
                    }

                    if (filter.FromDate != null && filter.ToDate != null)
                    {
                        data = data.Where(x => filter.FromDate <= x.FinishedDate && x.FinishedDate <= filter.ToDate);
                    }

                    if (!string.IsNullOrEmpty(filter.FilterText))
                    {
                        data = data.Where(x => x.Name.Contains(filter.FilterText)
                                            || x.Location.Contains(filter.FilterText)
                                            || x.Body.Contains(filter.FilterText)
                                            || x.CreatedByUserName.Contains(filter.FilterText)
                                            );
                    }

                    int excludedRows = (filter.PageNumber - 1) * filter.PageSize;
                    int totalCount = data.Count();
                    data = data.Skip(excludedRows).Take(filter.PageSize);

                    result = await data.ToListAsync();

                    return new OldResponse<List<CMS_News>>(1, "SUCCESS", result) {
                        DataCount = result.Count,
                        TotalCount = totalCount
                    };
                }
            }
            catch (Exception ex)
            {
                return new OldResponse<List<CMS_News>>(-1, ex.Message, null);
            }
        }

        public async Task<OldResponse<CMS_News>> Update(NewsUpdateRequestModel model)
        {
            try
            {
                using (var unitOfWork = new UnitOfWork())
                {
                    var data = unitOfWork.GetRepository<CMS_News>().Get(x => x.NewsId == model.Id).FirstOrDefault();
                    data.IsHidden = data.IsHidden;
                    data.Location = data.Location;
                    data.Name = data.Name;
                    data.NewsCategoryId = data.NewsCategoryId;
                    data.Thumbnail = data.Thumbnail;
                    data.Body = data.Body;
                    data.FinishedDate = data.FinishedDate;
                    
                    if(await unitOfWork.SaveAsync() >= 1)
                    {
                        return new OldResponse<CMS_News>(1, "SUCCESS", data);
                    }
                    else
                    {
                        return new OldResponse<CMS_News>(-1, "Failed to save", null);
                    }
                }
            }
            catch (Exception ex)
            {
                return new OldResponse<CMS_News>(-1, ex.Message, null);
            }
        }
    }
}
