using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Weather.Data.V1
{
    public class CMS_Post
    {
        [Key]
        public Guid PostId { get; set; }
        public Guid PostCategoryId { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }

        public DateTime CreatedOnDate { get; set; }
        public DateTime LastEditedOnDate { get; set; }

        public Guid CreatedByUserId { get; set; }
        public Guid LastEditedByUserId { get; set; }

        public bool IsApprove { get; set; }

        [ForeignKey("CreatedByUserId")]
        public AspnetMembership CreatedByUser { get; set; }
        [ForeignKey("LastEditedByUserId")]
        public AspnetMembership LastEditedByUser { get; set; }

        public CMS_PostCategory PostCategory { get; set; }
        public List<CMS_Comment> Comments { get; set; }
    }
}
