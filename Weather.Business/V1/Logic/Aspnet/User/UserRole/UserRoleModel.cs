using System;
using System.Collections.Generic;
using System.Text;
using Weather.Data.V1;

namespace Weather.Business.V1
{
    public class UserRoleFilterModel : BaseQueryFilterModel
    {
        public Guid? RoleId { get; set; }
    }
    public class UserRoleCreateRequestModel
    {
        public string RoleName { get; set; }
        public string Description { get; set; }
        public bool EnableDelete { get; set; } // Lock role
        public Guid CreatedByUserId { get; set; }
        //public DateTime CreatedOnDate { get; set; }
        public List<Guid> RightList { get; set; }
    }
    public class UserRoleUpdateRequestModel
    {
        public Guid RoleId { get; set; }

        public string RoleName { get; set; }
        public string Description { get; set; }
        //public bool EnableDelete { get; set; } // Lock role

        public Guid LastModifiedByUserId { get; set; }
        //public DateTime LastModifiedOnDate { get; set; }
        public List<Guid> RightList { get; set; }
    }
    public class UserRoleDeleteResponseModel : BaseDeleteResponseModel
    {

    }
}
