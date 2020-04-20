using System;
using System.Collections.Generic;
using System.Text;
using Weather.Data.V1;

namespace Weather.Business.V1
{
    public class UserRightFilterModel : BaseQueryFilterModel
    {
        public Guid? RightId { get; set; }
        public bool IsGroup { get; set; }
    }
    public class UserRightCreateRequestModel
    {
        //public string RightCode { get; set; }
        public string RightName { get; set; }
        public string Description { get; set; }
        public bool? Status { get; set; }
        public int? Order { get; set; }
        public bool IsGroup { get; set; }
        //public int Level { get; set; }
        public Guid? GroupId { get; set; }
        public Guid CreatedByUserId { get; set; }
    }
    public class UserRightUpdateRequestModel
    {
        //public string RightCode { get; set; }
        public Guid RightId { get; set; }
        public string RightName { get; set; }
        public string Description { get; set; }
        public bool? Status { get; set; }
        public int? Order { get; set; }
        //public bool IsGroup { get; set; }
        public Guid? GroupId { get; set; }
        public Guid LastModifiedByUserId { get; set; }
    }
    public class UserRightDeleteResponseModel : BaseDeleteResponseModel
    {

    }
}
