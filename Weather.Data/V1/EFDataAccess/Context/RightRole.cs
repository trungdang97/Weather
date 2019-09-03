using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Weather.Data.V1
{
    public class RightRole
    {
        public Guid RightRoleId { get; set; }
        public Guid RoleId { get; set; }
        public Guid RightId { get; set; }
        [StringLength(256)]
        public string RightName { get; set; }
        [StringLength(256)]
        public string RightCode { get; set; }

        [ForeignKey("RightId")]
        [InverseProperty("RightRole")]
        public Right Right { get; set; }
        [ForeignKey("RoleId")]
        [InverseProperty("RightRole")]
        public AspnetRoles Role { get; set; }
    }
}
