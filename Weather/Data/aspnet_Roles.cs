//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Weather.Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class aspnet_Roles
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public aspnet_Roles()
        {
            this.aspnet_Membership = new HashSet<aspnet_Membership>();
            this.aspnet_Roles_Rights_Relationship = new HashSet<aspnet_Roles_Rights_Relationship>();
        }
    
        public System.Guid RoleId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<aspnet_Membership> aspnet_Membership { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<aspnet_Roles_Rights_Relationship> aspnet_Roles_Rights_Relationship { get; set; }
    }
}
