using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Weather.Controllers
{
    public class BaseQueryFilter
    {
        public string FilterText { get; set; }
        public int PageSize { get; set; } = 10;
        public int PageNumber { get; set; } = 0;
        
    }
}