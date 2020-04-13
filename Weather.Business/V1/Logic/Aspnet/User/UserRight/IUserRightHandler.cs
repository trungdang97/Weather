using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Weather.Data.V1;

namespace Weather.Business.V1
{
    public interface IUserRightHandler
    {
        Task<OldResponse<List<Idm_Right>>> GetFilter(UserRightFilterModel filter);
        Task<OldResponse<Idm_Right>> Create(UserRightCreateRequestModel model);
        Task<OldResponse<Idm_Right>> Update(UserRightUpdateRequestModel model);
        Task<OldResponse<UserRightDeleteResponseModel>> Delete(Guid id);
        Task<OldResponse<List<UserRightDeleteResponseModel>>> DeleteMany(List<Guid> listId);
    }
}
