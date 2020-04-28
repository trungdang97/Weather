using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Weather.Data.V1;

namespace Weather.Business.V1
{
    public interface IUserHandler
    {
        Task<OldResponse<List<AspnetMembership>>> GetFilter(UserFilterModel filter);
        Task<OldResponse<AspnetMembership>> Create(UserCreateRequestModel model);
        Task<OldResponse<AspnetMembership>> Update(UserUpdateRequestModel model);
        Task<OldResponse<AspnetMembership>> Lock(Guid id);
        Task<OldResponse<AspnetMembership>> Ban(Guid id);
        Task<OldResponse<AspnetMembership>> Suspense(Guid id);
        Task<OldResponse<UserRightDeleteResponseModel>> Delete(Guid id);
    }
}
