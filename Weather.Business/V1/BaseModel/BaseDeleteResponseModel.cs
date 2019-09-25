using System;
using System.Collections.Generic;
using System.Text;

namespace Weather.Business.V1
{
    public class BaseDeleteResponseModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Message { get; set; }
        public int? Result { get; set; }
    }
}
