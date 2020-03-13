using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Weather.Data.V1
{
    public class CMS_Comment
    {
        [Key]
        public Guid CommentId { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }

        public Guid CreatedByUserId { get; set; }
        public Guid? LastEditedByUserId { get; set;}

        public DateTime CreatedOnDate { get; set; }
        public DateTime? LastEditedOnDate { get; set; }

        public bool IsApprove { get; set; } = false;
        
        public string Email { get; set; }
        public Guid? ParentCommentId { get; set; }

        public string Type { get; set; }
        public Guid ThreadId { get; set; }

        [ForeignKey("CreatedByUserId")]
        public AspnetMembership CreatedByUser { get; set; }
        [ForeignKey("LastEditedByUserId")]
        public AspnetMembership LastEditedByUser { get; set; }
    }
}
