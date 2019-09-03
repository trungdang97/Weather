﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Weather.Data.V1
{
    public class AspnetRoles
    {
        [Key]
        public Guid RoleId { get; set; }
        [Required]
        [StringLength(256)]
        public string RoleName { get; set; }
        [Required]
        [StringLength(256)]
        public string LoweredRoleName { get; set; }
        [StringLength(256)]
        public string Description { get; set; }
        public bool EnableDelete { get; set; }
        public Guid CreatedByUserId { get; set; }
        public DateTime CreatedOnDate { get; set; }
        public Guid LastModifiedByUserId { get; set; }
        public DateTime LastModifiedOnDate { get; set; }
        [StringLength(256)]
        public string RoleCode { get; set; }
       
        [InverseProperty("Role")]
        public ICollection<AspnetUsersInRoles> AspnetUsersInRoles { get; set; }
        [InverseProperty("Role")]
        public ICollection<Idm_RightsInRole> IdmRightsInRole { get; set; }
        [InverseProperty("Role")]
        public ICollection<RightRole> RightRole { get; set; }
    }
}