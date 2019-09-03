using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Weather.Data.V1
{
    public class NavigationRole
    {
        public Guid NavigationRoleId { get; set; }
        public Guid RoleId { get; set; }
        public Guid NavigationId { get; set; }
        public Guid? FromSubNavigation { get; set; }

        [ForeignKey("NavigationId")]
        [InverseProperty("NavigationRole")]
        public Navigation Navigation { get; set; }
    }
}
