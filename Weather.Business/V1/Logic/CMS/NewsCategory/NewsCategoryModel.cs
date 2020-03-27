using System;
using System.Collections.Generic;
using System.Text;

namespace Weather.Business.V1
{
    public class NewsCategoryFilterModel : BaseQueryFilterModel
    {
        public Guid? NewsCategoryId { get; set; }
        public string Type { get; set; }
    }

    public class NewsCategoryCreateRequestModel
    {
        //public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public int Order { get; set; }

        public Guid CreatedByUserId { get; set; }
    }

    public class NewsCategoryUpdateRequestModel
    {
        public Guid NewsCategoryId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public int Order { get; set; }

        public Guid LastEditedByUserId { get; set; }
    }

    public class NewsCategoryDeleteResponseModel : BaseDeleteResponseModel
    {
    }
}
