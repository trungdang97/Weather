using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Weather.Data.V1;

namespace Weather.Business.V1
{
    public interface INavigationHandler
    {
        Task<OldResponse<List<Navigation>>> GetFilter(NavigationFilterModel filter);
        Task<OldResponse<Navigation>> Create(NavigationCreateRequestModel model);
        Task<OldResponse<Navigation>> Update(NavigationUpdateRequestModel model);
        Task<OldResponse<NavigationDeleteResponseModel>> Delete(Guid id);
        Task<OldResponse<List<NavigationDeleteResponseModel>>> DeleteMany(List<Guid> listId);
    }
}
