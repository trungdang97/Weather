using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Weather.Data.V1
{ 
    public class CMS_NewsCategory
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public int Order { get; set; }

        public Guid CreatedByUserId { get; set; }
        public Guid LastEditedByUserId { get; set; }

        [ForeignKey("CreatedByUserId")]
        public AspnetMembership CreatedByUser { get; set; }
        [ForeignKey("LastEditedByUserId")]
        public AspnetMembership LastEditedByUser { get; set; }
    }
}
