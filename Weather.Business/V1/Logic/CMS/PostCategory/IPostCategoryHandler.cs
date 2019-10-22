using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Weather.Data.V1;

namespace Weather.Business.V1
{
    public interface IPostCategoryHandler
    {
        Task<OldResponse<List<CMS_PostCategory>>> GetFilter(PostCategoryFilterModel filter);
        Task<OldResponse<CMS_PostCategory>> Create(PostCategoryCreateRequestModel model);
        Task<OldResponse<CMS_PostCategory>> Update(PostCategoryUpdateRequestModel model);
        Task<OldResponse<PostCategoryDeleteResponseModel>> Delete(Guid id);
        Task<OldResponse<List<PostCategoryDeleteResponseModel>>> DeleteMany(List<Guid> listId);
    }
}
