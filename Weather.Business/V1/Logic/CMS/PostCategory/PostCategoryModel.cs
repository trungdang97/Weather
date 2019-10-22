using System;
using System.Collections.Generic;
using System.Text;

namespace Weather.Business.V1
{
    public class PostCategoryFilterModel : BaseQueryFilterModel
    {
        public Guid? Id { get; set; }
        //public string Name { get; set; }
        //public string Description { get; set; }
    }
    public class PostCategoryCreateRequestModel
    {
        //public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
    public class PostCategoryUpdateRequestModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
    public class PostCategoryDeleteResponseModel : BaseDeleteResponseModel
    {

    }
}
