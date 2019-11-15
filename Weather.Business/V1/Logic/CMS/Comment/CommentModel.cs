using System;
using System.Collections.Generic;
using System.Text;

namespace Weather.Business.V1
{
    public class CommentFilterModel :BaseQueryFilterModel
    {
        public Guid? Id { get; set; }       
        public DateTime? CreatedOnDate { get; set; }
        public DateTime? LastUpdatedOnDate { get; set; }
        public Guid? CreatedByUserId { get; set; }
        public bool? IsApprove { get; set; }
        public Guid? ParentCommentId { get; set; }
        public Guid? ThreadId { get; set; }
    }

    public class CommentCreateModel
    {
        //public Guid Id { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        //public DateTime CreatedOnDate { get; set; }
        //public DateTime LastUpdatedOnDate { get; set; }
        public Guid CreatedByUserId { get; set; }
        public bool IsApprove { get; set; } = false;

        public string Email { get; set; }
        public Guid? ParentCommentId { get; set; }

        public string Type { get; set; }
        public Guid? ThreadId { get; set; }
    }

    public class CommentUpdateModel
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        //public DateTime CreatedOnDate { get; set; }
        //public DateTime LastUpdatedOnDate { get; set; }
        //public Guid CreatedByUserId { get; set; }
        public Guid LastEditedByUserId { get; set; }
        public bool IsApprove { get; set; }

        public string Email { get; set; }
        public Guid ParentCommentId { get; set; }

        public string Type { get; set; }
        public Guid ThreadId { get; set; }
    }

    public class CommentDeleteResponseModel : BaseDeleteResponseModel
    {
        
    }
}
