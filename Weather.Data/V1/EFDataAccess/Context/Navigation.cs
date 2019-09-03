using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Weather.Data.V1
{
    public class Navigation
    {
        public Guid NavigationId { get; set; }
        public Guid? ParentId { get; set; }
        [StringLength(256)]
        public string Code { get; set; }
        [Required]
        [StringLength(256)]
        public string Name { get; set; }
        public bool? Status { get; set; }
        public int? Order { get; set; }
        public bool HasChild { get; set; }
        [StringLength(512)]
        public string UrlRewrite { get; set; }
        [StringLength(50)]
        public string IconClass { get; set; }
        [Column("NavigationName_En")]
        [StringLength(256)]
        public string NavigationNameEn { get; set; }
        public Guid? CreatedByUserId { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? CreatedOnDate { get; set; }
        public Guid? LastModifiedByUserId { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? LastModifiedOnDate { get; set; }
        [StringLength(450)]
        public string IdPath { get; set; }
        [StringLength(900)]
        public string Path { get; set; }
        public int Level { get; set; }
        public string SubUrl { get; set; }

        [ForeignKey("ParentId")]
        [InverseProperty("InverseParent")]
        public Navigation Parent { get; set; }
        [InverseProperty("Parent")]
        public ICollection<Navigation> InverseParent { get; set; }
        [InverseProperty("Navigation")]
        public ICollection<NavigationRole> NavigationRole { get; set; }
    }
}
