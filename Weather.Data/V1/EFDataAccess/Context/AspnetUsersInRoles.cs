using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Weather.Data.V1
{
    public class AspnetUsersInRoles
    {
        [Key]
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid RoleId { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? CreateDate { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DeleteDate { get; set; }

        [ForeignKey("RoleId")]
        [InverseProperty("AspnetUsersInRoles")]
        public AspnetRoles Role { get; set; }
        [ForeignKey("UserId")]
        [InverseProperty("AspnetUsersInRoles")]
        public AspnetUsers User { get; set; }
    }
}
