using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Weather.Data.V1
{
    public class Idm_RightsInRole
    {
        public long Id { get; set; }
        public Guid RoleId { get; set; }
        [Required]
        [StringLength(256)]
        public string RightCode { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime CreatedOnDate { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime ModifiedOnDate { get; set; }

        [ForeignKey("RightCode")]
        [InverseProperty("IdmRightsInRole")]
        public Idm_Right RightCodeNavigation { get; set; }
        [ForeignKey("RoleId")]
        [InverseProperty("IdmRightsInRole")]
        public AspnetRoles Role { get; set; }
    }
}
