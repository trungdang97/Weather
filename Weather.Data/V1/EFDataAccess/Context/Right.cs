using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Weather.Data.V1
{
    public class Right
    {
        [Key]
        public Guid RightId { get; set; }
        public Guid? ParentRightId { get; set; }       
        [Required]
        [StringLength(256)]
        public string RightCode { get; set; }
        [Required]
        [StringLength(256)]
        public string RightName { get; set; }
        public bool? Status { get; set; }
        public int? Order { get; set; }
        public bool HasChild { get; set; }
        [StringLength(512)]
        public string UrlRewrite { get; set; }
        [StringLength(512)]
        public string IconClass { get; set; }

        [ForeignKey("ParentRightId")]
        [InverseProperty("InverseParentRight")]
        public Right ParentRight { get; set; }
        [InverseProperty("ParentRight")]
        public ICollection<Right> InverseParentRight { get; set; }
        [InverseProperty("Right")]
        public ICollection<RightRole> RightRole { get; set; }
    }
}
