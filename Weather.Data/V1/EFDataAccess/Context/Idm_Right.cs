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
        [StringLength(256)]
        public string GroupCode { get; set; }

        [ForeignKey("GroupCode")]
        [InverseProperty("InverseGroupCodeNavigation")]
        public Idm_Right GroupCodeNavigation { get; set; }
        [InverseProperty("RightCodeNavigation")]
        public ICollection<Idm_RightsInRole> IdmRightsInRole { get; set; }
        [InverseProperty("RightCodeNavigation")]
        public ICollection<Idm_RightsOfUser> IdmRightsOfUser { get; set; }
        [InverseProperty("GroupCodeNavigation")]
        public ICollection<Idm_Right> InverseGroupCodeNavigation { get; set; }
    }
}
