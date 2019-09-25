using System;
using System.Collections.Generic;
using System.Text;

namespace Weather.Business.V1
{
    public class NewsFilterModel : BaseQueryFilterModel
    {
        public Guid? Id { get; set; }
        public Guid? NewsCategoryId { get; set; }
        
        //public DateTime FinishedDate { get; set; }

        public Guid? CreatedByUserId { get; set; }
        
        //public string Thumbnail { get; set; }
        public bool? IsHidden { get; set; }
    }

    public class NewsCreateRequestModel
    {
        public Guid NewsCategoryId { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public DateTime FinishedDate { get; set; }
        public string Body { get; set; }
        public Guid CreatedByUserId { get; set; }
        public string CreatedByUserName { get; set; }
        public string Thumbnail { get; set; }
        public bool IsHidden { get; set; } = false;
    }

    public class NewsUpdateRequestModel
    {
        public Guid Id { get; set; }
        public Guid NewsCategoryId { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public DateTime FinishedDate { get; set; }
        public string Body { get; set; }
        public Guid CreatedByUserId { get; set; }
        public string CreatedByUserName { get; set; }
        public string Thumbnail { get; set; }
        public bool? IsHidden { get; set; }
    }

    public class NewsDeleteResponseModel : BaseDeleteResponseModel
    {
        
    }
}
