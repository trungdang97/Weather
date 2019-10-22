using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Weather.Data.V1;

namespace Weather.Business.V1
{
    public class DbCommentHandler : ICommentHandler
    {
        public async Task<OldResponse<CMS_Comment>> Create(CommentCreateModel model)
        {
            using (var unitOfWork = new UnitOfWork())
            {
                try
                {
                    var createModel = AutoMapperUtils.AutoMap<CommentCreateModel, CMS_Comment>(model);
                    createModel.Id = Guid.NewGuid();
                    createModel.CreatedOnDate = DateTime.Now;
                    createModel.LastUpdatedOnDate = DateTime.Now;

                    unitOfWork.GetRepository<CMS_Comment>().Add(createModel);

                    if (await unitOfWork.SaveAsync() >= 1)
                    {
                        return new OldResponse<CMS_Comment>(1, "SUCCESS", createModel);
                    }
                    else
                    {
                        return new OldResponse<CMS_Comment>(-1, "Failed to save", null);
                    }
                }
                catch (Exception ex)
                {
                    return new OldResponse<CMS_Comment>(-1, ex.Message, null);
                }
            }
        }

        public async Task<OldResponse<CommentDeleteResponseModel>> Delete(Guid id)
        {
            using (var unitOfWork = new UnitOfWork())
            {
                try
                {
                    var deleteModel = unitOfWork.GetRepository<CMS_Comment>().Get(x => x.Id == id).FirstOrDefault();
                    unitOfWork.GetRepository<CMS_Comment>().Delete(deleteModel);
                    if (await unitOfWork.SaveAsync() >= 1)
                    {
                        return new OldResponse<CommentDeleteResponseModel>(1, "SUCCESS", new CommentDeleteResponseModel()
                        {
                            Id = id,
                            Name = deleteModel.Title,
                            Message = "Deleted",
                            Result = 1
                        });
                    }
                    else
                    {
                        return new OldResponse<CommentDeleteResponseModel>(1, "SUCCESS", new CommentDeleteResponseModel()
                        {
                            Id = id,
                            Name = deleteModel.Title,
                            Message = "Record have dependencies",
                            Result = -1
                        });
                    }
                }
                catch (Exception ex)
                {
                    return new OldResponse<CommentDeleteResponseModel>(-1, ex.Message, null);
                }
            }
        }

        public async Task<OldResponse<List<CommentDeleteResponseModel>>> DeleteMany(List<Guid> listId)
        {

            try
            {
                var responses = new List<CommentDeleteResponseModel>();
                foreach (var id in listId)
                {
                    var response = await Delete(id);
                    responses.Add(response.Data);
                }

                return new OldResponse<List<CommentDeleteResponseModel>>(1, "SUCCESS", responses);
            }
            catch (Exception ex)
            {
                return new OldResponse<List<CommentDeleteResponseModel>>(-1, ex.Message, null);
            }
        }

        public async Task<OldResponse<List<CMS_Comment>>> GetByThreadId(Guid threadId)
        {
            using (var unitOfWork = new UnitOfWork())
            {
                try
                {
                    var datas = unitOfWork.GetRepository<CMS_Comment>().GetAllIncluding(x => x.CreatedByUser);
                    datas = datas.Where(x => x.ThreadId == threadId);

                    var results = await datas.ToListAsync();
                    return new OldResponse<List<CMS_Comment>>(1, "SUCCESS", results);
                }
                catch (Exception ex)
                {
                    return new OldResponse<List<CMS_Comment>>(-1, ex.Message, null);
                }
            }
        }

        public async Task<OldResponse<List<CMS_Comment>>> GetFilter(CommentFilterModel filter)
        {
            throw new NotImplementedException();
        }

        public async Task<OldResponse<CMS_Comment>> Update(CommentUpdateModel model)
        {
            using (var unitOfWork = new UnitOfWork())
            {
                try
                {
                    var updateModel = unitOfWork.GetRepository<CMS_Comment>().Get(x => x.Id == model.Id).FirstOrDefault();
                    updateModel.Body = model.Body;
                    //updateModel.Email = model.Email;
                    updateModel.IsApprove = model.IsApprove;
                    updateModel.LastUpdatedOnDate = DateTime.Now;
                    //updateModel.
                    unitOfWork.GetRepository<CMS_Comment>().Update(updateModel);

                    if (await unitOfWork.SaveAsync() >= 1)
                    {
                        return new OldResponse<CMS_Comment>(1, "SUCCESS", updateModel);
                    }
                    else
                    {
                        return new OldResponse<CMS_Comment>(-1, "Failed to update", null);
                    }
                }
                catch (Exception ex)
                {
                    return new OldResponse<CMS_Comment>(-1, ex.Message, null);
                }
            }
        }
    }
}
