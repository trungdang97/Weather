using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Weather.Data.V1;

namespace Weather.Business.V1
{
    public interface INewsCategoryHandler
    {
        Task<OldResponse<List<CMS_NewsCategory>>> GetFilter(NewsCategoryFilterModel filter);
        Task<OldResponse<CMS_NewsCategory>> Create(NewsCategoryCreateRequestModel model);
        Task<OldResponse<CMS_NewsCategory>> Update(NewsCategoryUpdateRequestModel model);
        Task<OldResponse<NewsCategoryDeleteResponseModel>> Delete(Guid id);
        Task<OldResponse<List<NewsCategoryDeleteResponseModel>>> DeleteMany(List<Guid> listId);
    }
}
