using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Weather.Data.V1
{
    public class AspnetMembership
    {
        [Key]
        public Guid UserId { get; set; }
        [Required]
        [StringLength(128)]
        public string Password { get; set; }
        public int PasswordFormat { get; set; }
        [Required]
        [StringLength(128)]
        public string PasswordSalt { get; set; }
        [Column("MobilePIN")]
        [StringLength(16)]
        public string MobilePin { get; set; }
        [StringLength(256)]
        public string Email { get; set; }
        [StringLength(256)]
        public string LoweredEmail { get; set; }
        [StringLength(256)]
        public string PasswordQuestion { get; set; }
        [StringLength(128)]
        public string PasswordAnswer { get; set; }
        public bool IsApproved { get; set; }
        public bool IsLockedOut { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime CreateDate { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime LastLoginDate { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime LastPasswordChangedDate { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime LastLockoutDate { get; set; }
        public int FailedPasswordAttemptCount { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime FailedPasswordAttemptWindowStart { get; set; }
        public int FailedPasswordAnswerAttemptCount { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime FailedPasswordAnswerAttemptWindowStart { get; set; }
        [Column(TypeName = "ntext")]
        public string Comment { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DeleteDate { get; set; }
        public Guid CreatedByUserId { get; set; }
        public Guid LastModifiedByUserId { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime LastModifiedOnDate { get; set; }
        [StringLength(512)]
        public string FullName { get; set; }
        [StringLength(512)]
        public string NickName { get; set; }
        [StringLength(256)]
        public string ShortName { get; set; }
        [StringLength(256)]
        public string OtherEmail { get; set; }
        [StringLength(50)]
        public string MobilePhone { get; set; }
        [StringLength(50)]
        public string HomePhone { get; set; }

        [ForeignKey("UserId")]
        [InverseProperty("AspnetMembership")]
        public AspnetUsers User { get; set; }
    }
}
