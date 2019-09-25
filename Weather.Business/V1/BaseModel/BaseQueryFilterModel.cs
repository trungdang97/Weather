using System;
using System.Collections.Generic;
using System.Text;

namespace Weather.Business.V1
{
    public class BaseQueryFilterModel
    {
        public int PageSize { get; set; } = 10;
        public int PageNumber { get; set; } = 1;

        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }

        public string FilterText { get; set; }
    }
}
