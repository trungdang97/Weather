using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Weather.Data.V1;

namespace Weather.Business.V1.Logic
{
    public interface IUserRoleHandler
    {
        Task<OldResponse<List<AspnetRoles>>> GetFilter(UserRoleFilterModel filter);
        Task<OldResponse<AspnetRoles>> Create(UserRoleCreateRequestModel model);
        Task<OldResponse<AspnetRoles>> Update(UserRoleUpdateRequestModel model);
        Task<OldResponse<UserRoleDeleteResponseModel>> Delete(Guid id);
        Task<OldResponse<List<UserRoleDeleteResponseModel>>> DeleteMany(List<Guid> listId);
    }
}
