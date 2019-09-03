using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Weather.Data.V1
{
    public class CMS_News
    {
        [Key]
        public Guid Id { get; set; }
        public Guid NewsCategoryId { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public DateTime FinishedDate { get; set; }
        public string Body { get; set; }
        public Guid CreatedByUserId { get; set; }
        public string CreatedByUserName { get; set; }
        public string Thumbnail { get; set; }
        public bool IsHidden { get; set; }

        [ForeignKey("CreatedByUserId")]
        public AspnetMembership CreatedByUser { get; set; }
        public CMS_NewsCategory NewsCategory { get; set; }
        public List<CMS_Comment> Comments { get; set; }
    }
}
