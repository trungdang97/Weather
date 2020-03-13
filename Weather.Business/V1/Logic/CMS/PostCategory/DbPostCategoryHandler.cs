using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Weather.Data.V1;

namespace Weather.Business.V1
{
    public class DbPostCategoryHandler : IPostCategoryHandler
    {
        public async Task<OldResponse<CMS_PostCategory>> Create(PostCategoryCreateRequestModel model)
        {
            using (var unitOfWork = new UnitOfWork())
            {
                try
                {
                    var createModel = AutoMapperUtils.AutoMap<PostCategoryCreateRequestModel, CMS_PostCategory>(model);
                    createModel.PostCategoryId = Guid.NewGuid();
                    unitOfWork.GetRepository<CMS_PostCategory>().Add(createModel);

                    if (await unitOfWork.SaveAsync() >= 1)
                    {
                        return new OldResponse<CMS_PostCategory>(1, "SUCCESS", createModel);
                    }
                    else
                    {
                        return new OldResponse<CMS_PostCategory>(-1, "Failed to save", null);
                    }
                }
                catch (Exception ex)
                {
                    return new OldResponse<CMS_PostCategory>(-1, ex.Message, null);
                }
            }
        }

        public async Task<OldResponse<PostCategoryDeleteResponseModel>> Delete(Guid id)
        {
            using (var unitOfWork = new UnitOfWork())
            {
                try
                {
                    var deleteModel = unitOfWork.GetRepository<CMS_PostCategory>().Get(x => x.PostCategoryId == id).FirstOrDefault();
                    unitOfWork.GetRepository<CMS_PostCategory>().Delete(deleteModel);
                    if (await unitOfWork.SaveAsync() >= 1)
                    {
                        return new OldResponse<PostCategoryDeleteResponseModel>(1, "SUCCESS", new PostCategoryDeleteResponseModel()
                        {
                            Id = id,
                            Message = "Deleted",
                            Name = deleteModel.Name,
                            Result = 1
                        });
                    }
                    else
                    {
                        return new OldResponse<PostCategoryDeleteResponseModel>(1, "SUCCESS", new PostCategoryDeleteResponseModel()
                        {
                            Id = id,
                            Message = "Record have dependencies",
                            Name = deleteModel.Name,
                            Result = -1
                        });
                    }
                }
                catch (Exception ex)
                {
                    return new OldResponse<PostCategoryDeleteResponseModel>(-1, ex.Message, null);
                }
            }
        }

        public async Task<OldResponse<List<PostCategoryDeleteResponseModel>>> DeleteMany(List<Guid> listId)
        {
            try
            {
                List<PostCategoryDeleteResponseModel> listResult = new List<PostCategoryDeleteResponseModel>();
                foreach (var id in listId)
                {
                    var result = await Delete(id);
                    listResult.Add(result.Data);
                }
                return new OldResponse<List<PostCategoryDeleteResponseModel>>(1, "SUCCESS", listResult);
            }
            catch (Exception ex)
            {
                return new OldResponse<List<PostCategoryDeleteResponseModel>>(-1, ex.Message, null);
            }
        }

        public async Task<OldResponse<List<CMS_PostCategory>>> GetFilter(PostCategoryFilterModel filter)
        {
            using (var unitOfWork = new UnitOfWork())
            {
                try
                {
                    var result = new List<CMS_PostCategory>();
                    var datas = unitOfWork.GetRepository<CMS_PostCategory>().GetAll();
                    var totalCount = datas.Count();

                    if (filter.Id.HasValue)
                    {
                        result = await datas.Where(x => x.PostCategoryId == filter.Id).ToListAsync();
                        return new OldResponse<List<CMS_PostCategory>>(1, "SUCCESS", result);
                    }

                    if (!string.IsNullOrEmpty(filter.FilterText))
                    {
                        datas = datas.Where(x => x.Name.Contains(filter.FilterText)
                                            && x.Description.Contains(filter.FilterText));
                    }

                    int excludedRows = (filter.PageNumber - 1) * filter.PageSize;
                    datas = datas.Skip(excludedRows).Take(filter.PageNumber);

                    result = await datas.ToListAsync();

                    return new OldResponse<List<CMS_PostCategory>>(1, "SUCCESS", result) {
                        DataCount = result.Count,
                        TotalCount = totalCount
                    };
                }
                catch (Exception ex)
                {
                    return new OldResponse<List<CMS_PostCategory>>(-1, ex.Message, null);
                }
            }
        }

        public async Task<OldResponse<CMS_PostCategory>> Update(PostCategoryUpdateRequestModel model)
        {
            using (var unitOfWork = new UnitOfWork())
            {
                try
                {
                    var updateModel = unitOfWork.GetRepository<CMS_PostCategory>().Get(x => x.PostCategoryId == model.Id).FirstOrDefault();
                    updateModel.Name = model.Name;
                    updateModel.Description = model.Description;

                    if (await unitOfWork.SaveAsync() >= 1)
                    {
                        return new OldResponse<CMS_PostCategory>(1, "SUCCESS", updateModel);
                    }
                    else
                    {
                        return new OldResponse<CMS_PostCategory>(-1, "Failed to update", null);
                    }
                }
                catch (Exception ex)
                {
                    return new OldResponse<CMS_PostCategory>(-1, ex.Message, null);
                }
            }
        }
    }
}
