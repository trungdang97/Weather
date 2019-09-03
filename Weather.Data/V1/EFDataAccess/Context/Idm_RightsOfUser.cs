using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Weather.Data.V1
{
    public class Idm_RightsOfUser
    {
        public long Id { get; set; }
        public Guid UserId { get; set; }
        [Required]
        [StringLength(256)]
        public string RightCode { get; set; }
        public string InheritedFromRoles { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime CreatedDate { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime ModifiedDate { get; set; }
        public bool Inherited { get; set; }
        public bool Enable { get; set; }

        [ForeignKey("RightCode")]
        [InverseProperty("IdmRightsOfUser")]
        public Idm_Right RightCodeNavigation { get; set; }
        [ForeignKey("UserId")]
        [InverseProperty("IdmRightsOfUser")]
        public AspnetUsers User { get; set; }
    }
}
