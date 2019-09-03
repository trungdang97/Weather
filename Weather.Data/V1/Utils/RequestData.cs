using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Weather.Data.V1
{
   
    public class PaginationRequest
    {
        public string Sort { get; set; } = "+Id";
        public string Fields { get; set; }  

        [Range(1, int.MaxValue)] public int? Page { get; set; } = 1;

        [Range(1, int.MaxValue)] public int? Size { get; set; } = 20;

        public string Filter { get; set; } = "{}";
        public string FullTextSearch { get; set; }
        public Guid? Id { get; set; }
        public List<Guid> ListId   { get; set; }
    }

}