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
                    data.NewsCategoryId = Guid.NewGuid();
                    data.CreatedOnDate = DateTime.Now;
                    //data.LastEditedOnDate = DateTime.Now;
                    //data.LastEditedByUserId = data.CreatedByUserId;

                    unitOfWork.GetRepository<CMS_NewsCategory>().Add(data);

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

        public async Task<OldResponse<NewsCategoryDeleteResponseModel>> Delete(Guid id)
        {
            try
            {
                using (var unitOfWork = new UnitOfWork())
                {
                    var data = unitOfWork.GetRepository<CMS_NewsCategory>().Get(x => x.NewsCategoryId == id).FirstOrDefault();
                    unitOfWork.GetRepository<CMS_NewsCategory>().Delete(data);

                    if (await unitOfWork.SaveAsync() >= 1)
                    {
                        return new OldResponse<NewsCategoryDeleteResponseModel>(1, "SUCCESS", new NewsCategoryDeleteResponseModel()
                        {
                            Id = id,
                            Message = "SUCCESS",
                            Name = data.Name,
                            Result = 1
                        });
                    }
                    else
                    {
                        return new OldResponse<NewsCategoryDeleteResponseModel>(-1, "FAIL", new NewsCategoryDeleteResponseModel()
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
                return new OldResponse<NewsCategoryDeleteResponseModel>(-1, "FAIL", new NewsCategoryDeleteResponseModel()
                {
                    Message = ex.Message,
                    Result = -1
                });
            }
        }

        public async Task<OldResponse<List<NewsCategoryDeleteResponseModel>>> DeleteMany(List<Guid> listId)
        {
            try
            {
                if(listId.Count == 0)
                {
                    return new OldResponse<List<NewsCategoryDeleteResponseModel>>(-1, "List doesn't contain any Ids", null);
                }
                List<NewsCategoryDeleteResponseModel> deleted = new List<NewsCategoryDeleteResponseModel>();
                foreach (var id in listId)
                {
                    var result = await Delete(id);
                    deleted.Add(result.Data);
                }
                return new OldResponse<List<NewsCategoryDeleteResponseModel>>(1, "SUCCESS", deleted);
            }
            catch (Exception ex)
            {
                return new OldResponse<List<NewsCategoryDeleteResponseModel>>(-1, ex.Message, null);
            }
        }

        public async Task<OldResponse<List<CMS_NewsCategory>>> GetFilter(NewsCategoryFilterModel filter)
        {
            try
            {
                using (var unitOfWork = new UnitOfWork())
                {
                    var results = new List<CMS_NewsCategory>();
                    var data = unitOfWork.GetRepository<CMS_NewsCategory>().GetAll();

                    if (filter.NewsCategoryId.HasValue && filter.NewsCategoryId != Guid.Empty)
                    {
                        var result = data.Where(x => x.NewsCategoryId == filter.NewsCategoryId).FirstOrDefault();
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

                    data = data.OrderBy(x => x.Type).ThenBy(x => x.Order);

                    int excludedRows = (filter.PageNumber - 1) * filter.PageSize;
                    int totalCount = data.Count();
                    data = data.Skip(excludedRows).Take(filter.PageSize);

                    var datas = await data.ToListAsync();
                    return new OldResponse<List<CMS_NewsCategory>>(1, "SUCCESS", datas)
                    {
                        DataCount = datas.Count,
                        TotalCount = totalCount
                    };
                }
            }
            catch (Exception ex)
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
                    var data = unitOfWork.GetRepository<CMS_NewsCategory>().Get(x => x.NewsCategoryId == model.NewsCategoryId).FirstOrDefault();
                    data.Description = model.Description;
                    data.Name = model.Name;
                    data.Order = model.Order;
                    data.Type = model.Type;
                    data.LastEditedByUserId = model.LastEditedByUserId;
                    data.LastEditedOnDate = DateTime.Now;

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
