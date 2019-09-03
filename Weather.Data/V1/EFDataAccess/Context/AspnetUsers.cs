using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Weather.Data.V1
{
    public class AspnetUsers
    {
        [Key]
        public Guid UserId { get; set; }
        [Required]
        [StringLength(256)]
        public string UserName { get; set; }
        [Required]
        [StringLength(256)]
        public string LoweredUserName { get; set; }
        [StringLength(16)]
        public string MobileAlias { get; set; }
        public bool IsAnonymous { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime LastActivityDate { get; set; }
        [StringLength(256)]
        public string FinanceCode { get; set; }
        public int Type { get; set; }

        [InverseProperty("User")]
        public AspnetMembership AspnetMembership { get; set; }
        [InverseProperty("User")]
        public ICollection<AspnetUsersInRoles> AspnetUsersInRoles { get; set; }
        [InverseProperty("User")]
        public ICollection<Idm_RightsOfUser> IdmRightsOfUser { get; set; }

    }
}
