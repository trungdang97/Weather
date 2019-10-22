using System;
using System.Collections.Generic;
using System.Text;
using Weather.Data.V1;

namespace Weather.Business.V1
{
    public class PostFilterModel : BaseQueryFilterModel
    {
        public Guid? Id { get; set; }
        public Guid? PostCategoryId { get; set; }        
        public DateTime? CreatedOnDate { get; set; }
        public DateTime? LastUpdatedOnDate { get; set; }
        public Guid? CreatedByUserId { get; set; }
        public bool? IsApprove { get; set; }
    }

    public class PostCreateRequestModel
    {
        //public Guid Id { get; set; }
        public Guid PostCategoryId { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public DateTime CreatedOnDate { get; set; }
        public DateTime LastUpdatedOnDate { get; set; }
        public Guid CreatedByUserId { get; set; }
        public bool IsApprove { get; set; }
    }

    public class PostUpdateRequestModel
    {
        public Guid Id { get; set; }
        public Guid PostCategoryId { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        //public DateTime CreatedOnDate { get; set; }
        public DateTime LastUpdatedOnDate { get; set; }
        public Guid CreatedByUserId { get; set; }
        public bool IsApprove { get; set; }

        //public AspnetMembership CreatedByUser { get; set; }
        //public CMS_PostCategory PostCategory { get; set; }
        //public List<CMS_Comment> Comments { get; set; }
    }

    public class PostDeleteResponseModel : BaseDeleteResponseModel
    {

    }
}
