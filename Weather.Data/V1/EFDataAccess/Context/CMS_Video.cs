using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Weather.Data.V1.EFDataAccess.Context
{
    public class CMS_Video
    {
        [Key]
        public Guid VideoId { get; set; }

        //Metadata
        public string Host { get; set; }
        public string Path { get; set; }
        public string AbsolutePath { get; set; }

        public string Title { get; set; }

        public DateTime CreatedOnDate { get; set; }
        public DateTime LastEditedOnDate { get; set; }

        public Guid CreatedByUserId { get; set; }
        public Guid LastEditedByUserId { get; set; }
        [ForeignKey("CreatedByUserId")]
        public AspnetMembership CreatedByUser { get; set; }
        [ForeignKey("LastEditedByUserId")]
        public AspnetMembership LastEditedByUser { get; set; }
        //public string Body { get; set; }

    }
}
