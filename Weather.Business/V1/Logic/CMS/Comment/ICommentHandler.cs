using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Weather.Data.V1;

namespace Weather.Business.V1
{
    public interface ICommentHandler
    {
        Task<OldResponse<List<CMS_Comment>>> GetFilter(CommentFilterModel filter);
        Task<OldResponse<List<CMS_Comment>>> GetByThreadId(Guid threadId);
        Task<OldResponse<CMS_Comment>> Create(CommentCreateModel model);
        Task<OldResponse<CMS_Comment>> Update(CommentUpdateModel model);
        Task<OldResponse<CommentDeleteResponseModel>> Delete(Guid id);
        Task<OldResponse<List<CommentDeleteResponseModel>>> DeleteMany(List<Guid> listId);
    }
}
