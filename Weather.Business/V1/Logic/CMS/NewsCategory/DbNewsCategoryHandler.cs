using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Weather.Data.V1;

namespace Weather.Business.V1
{
    public class DbNewsCategoryHandler : INewsCategoryHandler
    {
        public async Task<OldResponse<CMS_NewsCategory>> Create(NewsCategoryCreateRequestModel model)
        {
            try
            {
                using (var unitOfWork = new UnitOfWork())
                {
                    var data = AutoMapperUtils.AutoMap<NewsCategoryCreateRequestModel, CMS_NewsCategory>(model);
                    data.Id = Guid.NewGuid();

                    if (await unitOfWork.SaveAsync() >= 1)
                    {
                        return new OldResponse<CMS_NewsCategory>(1, "SUCCESS", data);
                    }
                    else
                    {
                        return new OldResponse<CMS_NewsCategory>(-1, "Fail to save", null);
                    }
                }
            }
            catch (Exception ex)
            {
                return new OldResponse<CMS_NewsCategory>(-1, ex.Message, null);
            }
        }

        public async Task<OldResponse<NewsDeleteResponseModel>> Delete(Guid id)
        {
            try
            {
                using (var unitOfWork = new UnitOfWork())
                {
                    var data = unitOfWork.GetRepository<CMS_NewsCategory>().Get(x => x.Id == id).FirstOrDefault();
                    unitOfWork.GetRepository<CMS_NewsCategory>().Delete(data);

                    if (await unitOfWork.SaveAsync() >= 1)
                    {
                        return new OldResponse<NewsDeleteResponseModel>(1, "SUCCESS", new NewsDeleteResponseModel() {
                            Id = data.Id,
                            Message = "SUCCESS",
                            Name = data.Name,
                            Result = 1
                        });
                    }
                    else
                    {
                        return new OldResponse<NewsDeleteResponseModel>(-1, "Fail to delete", new NewsDeleteResponseModel()
                        {
                            Id = id,
                            Name = data.Name,
                            Message = "Record have dependencies",
                            Result = -1
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                return new OldResponse<NewsDeleteResponseModel>(1, "SUCCESS", new NewsDeleteResponseModel()
                {                    
                    Message = ex.Message,
                    Result = -1
                });
            }
        }

        public async Task<OldResponse<List<NewsDeleteResponseModel>>> DeleteMany(List<Guid> listId)
        {
            try
            {
                List<NewsDeleteResponseModel> deleted = new List<NewsDeleteResponseModel>();
                foreach(var id in listId)
                {
                    var result = await Delete(id);
                    deleted.Add(result.Data);
                }
                return new OldResponse<List<NewsDeleteResponseModel>>(1, "SUCCESS", deleted);
            }
            catch(Exception ex)
            {
                return new OldResponse<List<NewsDeleteResponseModel>>(-1, ex.Message, null);
            }
        }

        public async Task<OldResponse<List<CMS_NewsCategory>>> GetFilter(NewsCategoryFilterModel filter)
        {
            try
            {
                using(var unitOfWork = new UnitOfWork())
                {
                    var results = new List<CMS_NewsCategory>();
                    var data = unitOfWork.GetRepository<CMS_NewsCategory>().GetAll();

                    if (filter.Id.HasValue)
                    {
                        var result = data.Where(x => x.Id == filter.Id).FirstOrDefault();
                        results.Add(result);
                        return new OldResponse<List<CMS_NewsCategory>>(1, "SUCCESS", results);
                    }

                    if (!string.IsNullOrEmpty(filter.Type))
                    {
                        data = data.Where(x => x.Type == filter.Type);
                    }

                    if (!string.IsNullOrEmpty(filter.FilterText))
                    {
                        data = data.Where(x => x.Name.Contains(filter.FilterText) || x.Name.Contains(filter.FilterText));
                    }

                    int excludedRows = (filter.PageNumber - 1) * filter.PageSize;
                    int totalCount = data.Count();
                    data = data.Skip(excludedRows).Take(filter.PageSize);

                    var datas = await data.ToListAsync();
                    return new OldResponse<List<CMS_NewsCategory>>(1, "SUCCESS", datas) {
                        DataCount = datas.Count,
                        TotalCount = totalCount
                    };
                }
            }
            catch(Exception ex)
            {
                return new OldResponse<List<CMS_NewsCategory>>(-1, ex.Message, null);
            }
        }

        public async Task<OldResponse<CMS_NewsCategory>> Update(NewsCategoryUpdateRequestModel model)
        {
            try
            {
                using (var unitOfWork = new UnitOfWork())
                {
                    var data = unitOfWork.GetRepository<CMS_NewsCategory>().Get(x => x.Id == model.Id).FirstOrDefault();
                    data.Description = data.Description;
                    data.Name = data.Name;
                    data.Order = data.Order;
                    data.Type = data.Type;

                    if (await unitOfWork.SaveAsync() >= 1)
                    {
                        return new OldResponse<CMS_NewsCategory>(1, "SUCCESS", data);
                    }
                    else
                    {
                        return new OldResponse<CMS_NewsCategory>(-1, "Fail to save", null);
                    }
                }
            }
            catch (Exception ex)
            {
                return new OldResponse<CMS_NewsCategory>(-1, ex.Message, null);
            }
        }
    }
}
