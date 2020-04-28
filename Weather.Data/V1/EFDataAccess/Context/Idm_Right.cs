using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Weather.Data.V1
{
    public class Idm_Right
    {
        [Key]
        public Guid RightId { get; set; }
        [StringLength(256)]
        public string RightCode { get; set; }
        [Required]
        [StringLength(1024)]
        public string RightName { get; set; }
        [Required]
        public string Description { get; set; }
        public bool? Status { get; set; }
        public int? Order { get; set; }
        public bool IsGroup { get; set; }
        public int Level { get; set; }
        //[StringLength(256)]
        //public string GroupCode { get; set; }
        public Guid? GroupId { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime CreatedOnDate { get; set; }
        [Column(TypeName = "datetime2")]
        public DateTime ModifiedOnDate { get; set; }

        public Guid CreatedByUserId { get; set; }
        public Guid LastModifiedByUserId { get; set; }

        [ForeignKey("GroupId")]
        [InverseProperty("InverseGroupIdNavigation")]
        public Idm_Right GroupIdNavigation { get; set; }
        [InverseProperty("RightIdNavigation")]
        public ICollection<Idm_RightsInRole> IdmRightsInRole { get; set; }
        [InverseProperty("RightIdNavigation")]
        public ICollection<Idm_RightsOfUser> IdmRightsOfUser { get; set; }
        [InverseProperty("GroupIdNavigation")]
        public ICollection<Idm_Right> InverseGroupIdNavigation { get; set; }
    }
}
