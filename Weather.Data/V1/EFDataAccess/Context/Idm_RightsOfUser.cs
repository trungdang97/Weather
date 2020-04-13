﻿using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Weather.Data.V1
{
    public class Idm_RightsOfUser
    {
        public long Id { get; set; }
        public Guid UserId { get; set; }
        [Required]
        //[StringLength(256)]
        //public string RightCode { get; set; }
        public Guid RightId { get; set; }
        public string InheritedFromRoles { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime CreatedOnDate { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime ModifiedOnDate { get; set; }
        public bool Inherited { get; set; }
        public bool Enable { get; set; }

        //[ForeignKey("RightCode")]
        [ForeignKey("RightId")]
        [InverseProperty("IdmRightsOfUser")]
        public Idm_Right RightIdNavigation { get; set; }
        [ForeignKey("UserId")]
        [InverseProperty("IdmRightsOfUser")]
        public AspnetUsers User { get; set; }
    }
}
