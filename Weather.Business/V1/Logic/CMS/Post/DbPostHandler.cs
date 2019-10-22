using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Weather.Data.V1;

namespace Weather.Business.V1
{
    public class DbPostHandler : IPostHandler
    {
        public async Task<OldResponse<CMS_Post>> Create(PostCreateRequestModel model)
        {
            using (var unitOfWork = new UnitOfWork())
            {
                try
                {
                    var createModel = AutoMapperUtils.AutoMap<PostCreateRequestModel, CMS_Post>(model);
                    createModel.Id = Guid.NewGuid();
                    unitOfWork.GetRepository<CMS_Post>().Add(createModel);

                    if (await unitOfWork.SaveAsync() >= 1)
                    {
                        return new OldResponse<CMS_Post>(1, "SUCCESS", createModel);
                    }
                    else
                    {
                        return new OldResponse<CMS_Post>(1, "Failed to save", createModel);
                    }
                }
                catch (Exception ex)
                {
                    return new OldResponse<CMS_Post>(-1, ex.Message, null);
                }
            }
        }

        public async Task<OldResponse<PostDeleteResponseModel>> Delete(Guid id)
        {
            using (var unitOfWork = new UnitOfWork())
            {
                try
                {
                    var deleteModel = unitOfWork.GetRepository<CMS_PostCategory>().Get(x => x.Id == id).FirstOrDefault();
                    unitOfWork.GetRepository<CMS_PostCategory>().Delete(deleteModel);
                    if (await unitOfWork.SaveAsync() >= 1)
                    {
                        return new OldResponse<PostDeleteResponseModel>(1, "SUCCESS", new PostDeleteResponseModel()
                        {
                            Id = id,
                            Message = "Deleted",
                            Name = deleteModel.Name,
                            Result = 1
                        });
                    }
                    else
                    {
                        return new OldResponse<PostDeleteResponseModel>(1, "SUCCESS", new PostDeleteResponseModel()
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
                    return new OldResponse<PostDeleteResponseModel>(-1, ex.Message, null);
                }
            }
        }

        public async Task<OldResponse<List<PostDeleteResponseModel>>> DeleteMany(List<Guid> listId)
        {
            try
            {
                var responses = new List<PostDeleteResponseModel>();
                foreach (var id in listId)
                {
                    var delete = await Delete(id);
                    responses.Add(delete.Data);
                }
                return new OldResponse<List<PostDeleteResponseModel>>(1, "SUCCESS", responses);
            }
            catch(Exception ex)
            {
                return new OldResponse<List<PostDeleteResponseModel>>(-1, ex.Message, null);
            }
        }

        public async Task<OldResponse<List<CMS_Post>>> GetFilter(PostFilterModel filter)
        {
            using(var unitOfWork = new UnitOfWork())
            {
                try
                {
                    List<CMS_Post> result = new List<CMS_Post>();
                    var datas = unitOfWork.GetRepository<CMS_Post>().GetAllIncluding(x => x.Comments, x => x.CreatedByUser, x => x.PostCategory);
                    var totalCount = datas.Count();

                    if (filter.Id.HasValue)
                    {
                        result = await datas.Where(x => x.Id == filter.Id).ToListAsync();
                        return new OldResponse<List<CMS_Post>>(1, "SUCCESS", result);
                    }

                    if (filter.IsApprove.HasValue)
                    {
                        datas = datas.Where(x => x.IsApprove == filter.IsApprove);
                    }

                    if (filter.PostCategoryId.HasValue)
                    {
                        datas = datas.Where(x => x.IsApprove == filter.IsApprove);
                    }

                    if (filter.LastUpdatedOnDate.HasValue)
                    {
                        datas = datas.Where(x => x.LastUpdatedOnDate == filter.LastUpdatedOnDate);
                    }

                    if(filter.FromDate.HasValue && filter.ToDate.HasValue)
                    {
                        datas = datas.Where(x => x.CreatedOnDate >= filter.FromDate && x.CreatedOnDate <= filter.ToDate);
                    }

                    if (!string.IsNullOrEmpty(filter.FilterText))
                    {
                        datas = datas.Where(x => x.Body.Contains(filter.FilterText)
                                            && x.Comments.Any(y => y.Body.Contains(filter.FilterText))
                                            && x.Title.Contains(filter.FilterText));
                    }

                    int excludedRows = (filter.PageNumber - 1) * filter.PageSize;
                    datas = datas.Skip(excludedRows).Take(filter.PageNumber);

                    result = await datas.ToListAsync();

                    return new OldResponse<List<CMS_Post>>(1, "SUCCESS", result) {
                        DataCount = result.Count,
                        TotalCount = totalCount
                    };
                }
                catch(Exception ex)
                {
                    return new OldResponse<List<CMS_Post>>(-1, ex.Message, null);
                }
            }
        }

        public async Task<OldResponse<CMS_Post>> Update(PostUpdateRequestModel model)
        {
            using (var unitOfWork = new UnitOfWork())
            {
                try
                {
                    var updateModel = unitOfWork.GetRepository<CMS_Post>().Get(x=>x.Id == model.Id).FirstOrDefault();
                    updateModel.LastUpdatedOnDate = DateTime.Now;
                    unitOfWork.GetRepository<CMS_Post>().Update(updateModel);

                    if (await unitOfWork.SaveAsync() >= 1)
                    {
                        return new OldResponse<CMS_Post>(1, "SUCCESS", updateModel);
                    }
                    else
                    {
                        return new OldResponse<CMS_Post>(1, "Failed to update", updateModel);
                    }
                }
                catch (Exception ex)
                {
                    return new OldResponse<CMS_Post>(-1, ex.Message, null);
                }
            }
        }
    }
}
