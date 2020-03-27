using System;
using System.Collections.Generic;
using System.Text;

namespace Weather.Business.V1
{
    public class UserRoleFilterModel : BaseQueryFilterModel
    {
        public Guid? RoleId { get; set; }
    }
    public class UserRoleCreateRequestModel
    {
        public string RoleName { get; set; }
        public string RoleCode { get; set; }
        public string Description { get; set; }

        public Guid CreatedByUserId { get; set; }
    }
    public class UserRoleUpdateRequestModel
    {
        public string RoleName { get; set; }
        public string RoleCode { get; set; }
        public string Description { get; set; }

        public Guid LastModifiedByUserId { get; set; }
    }
    public class UserRoleDeleteResponseModel : BaseDeleteResponseModel
    {

    }
}
