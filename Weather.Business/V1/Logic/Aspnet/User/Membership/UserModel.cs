using System;
using System.Collections.Generic;
using System.Text;

namespace Weather.Business.V1
{
    public class UserFilterModel : BaseQueryFilterModel
    {
        public Guid? UserId { get; set; }
    }
    public class UserCreateRequestModel
    {
        public string Username { get; set; }
        public string PersonalId { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string PasswordQuestion { get; set; }
        public string PasswordAnswer { get; set; }
        public string FullName { get; set; }
        public string NickName { get; set; }
        //public string ShortName { get; set; }
        public string MobilePhone { get; set; }

        public Guid CreatedByUserId { get; set; }
    }
    public class UserUpdateRequestModel
    {
        public Guid UserId { get; set; }
        public string Comment { get; set; }
        public string OldPassword { get; set; }
        public string Password { get; set; }
        public string FullName { get; set; }
        public string NickName { get; set; }
        //public string ShortName { get; set; }
        public string MobilePhone { get; set; }

        public Guid LastModifiedByUserId { get; set; }
    }
    public class UserDeleteResponseModel : BaseDeleteResponseModel
    {

    }
}
