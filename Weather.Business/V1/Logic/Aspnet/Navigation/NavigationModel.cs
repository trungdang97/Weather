using System;
using System.Collections.Generic;
using System.Text;

namespace Weather.Business.V1
{
    public class NavigationFilterModel : BaseQueryFilterModel
    {
        public Guid? NavigationId { get; set; }
    }

    public class NavigationCreateRequestModel
    {
        public Guid NavigationId { get; set; }
        public Guid? ParentId { get; set; }        
        public string Code { get; set; }        
        public string Name { get; set; }
        public bool? Status { get; set; }
        public int? Order { get; set; }
        public bool HasChild { get; set; }       
        public string UrlRewrite { get; set; }       
        public string IconClass { get; set; }
        public string NavigationNameEn { get; set; }

        public Guid? CreatedByUserId { get; set; }
        //public DateTime? CreatedOnDate { get; set; }

        //public string IdPath { get; set; }
        //public string Path { get; set; }
        public int Level { get; set; }
        //public string SubUrl { get; set; }
    }
    public class NavigationUpdateRequestModel
    {
        public Guid NavigationId { get; set; }
        public Guid? ParentId { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public bool? Status { get; set; }
        public int? Order { get; set; }
        public bool HasChild { get; set; }
        public string UrlRewrite { get; set; }
        public string IconClass { get; set; }
        public string NavigationNameEn { get; set; }

        public Guid? LastModifiedByUserId { get; set; }
        //public DateTime? LastModifiedOnDate { get; set; }

        //public string IdPath { get; set; }
        //public string Path { get; set; }
        public int Level { get; set; }
        //public string SubUrl { get; set; }
    }
    public class NavigationDeleteResponseModel : BaseDeleteResponseModel
    {

    }
}
