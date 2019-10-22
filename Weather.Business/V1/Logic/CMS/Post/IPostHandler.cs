using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Weather.Data.V1;

namespace Weather.Business.V1
{
    public interface IPostHandler
    {
        Task<OldResponse<List<CMS_Post>>> GetFilter(PostFilterModel filter);
        Task<OldResponse<CMS_Post>> Create(PostCreateRequestModel model);
        Task<OldResponse<CMS_Post>> Update(PostUpdateRequestModel model);
        Task<OldResponse<PostDeleteResponseModel>> Delete(Guid id);
        Task<OldResponse<List<PostDeleteResponseModel>>> DeleteMany(List<Guid> listId);
    }
}
