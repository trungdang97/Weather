using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace cms_Weather.Models
{
    public class User
    {
        public Guid UserId { get; set; }
        public string Name { get; set; }
        public string ShortName { get; set; }
        public string NickName { get; set; }
        public Guid Role { get; set; }
    }
}