using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Weather.Data.V1
{
    public class Idm_RightsInRole
    {
        [Key]
        public Guid Id { get; set; }
        public Guid RoleId { get; set; }
        [Required]
        //[StringLength(256)]
        //public string RightCode { get; set; }
        public Guid RightId { get; set; }
        [Column(TypeName = "datetime2")]
        public DateTime CreatedOnDate { get; set; }
        public Guid CreatedByUserId { get; set; }
        [Column(TypeName = "datetime2")]
        public DateTime ModifiedOnDate { get; set; }
        public Guid ModifiedByUserId { get; set; }

        //[ForeignKey("RightCode")]
        [ForeignKey("RightId")]
        [InverseProperty("IdmRightsInRole")]
        public Idm_Right RightIdNavigation { get; set; }
        [ForeignKey("RoleId")]
        [InverseProperty("IdmRightsInRole")]
        public AspnetRoles Role { get; set; }
    }
}
