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
    
    public partial class cms_API
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public cms_API()
        {
            this.cms_API_Membership_Relationship = new HashSet<cms_API_Membership_Relationship>();
            this.cms_Bill_API = new HashSet<cms_Bill_API>();
        }
    
        public System.Guid APIId { get; set; }
        public string Name { get; set; }
        public Nullable<int> Duration { get; set; }
        public System.Guid APITypeId { get; set; }
        public string Body { get; set; }
        public string Documentation { get; set; }
        public string DocumentationLink { get; set; }
        public Nullable<int> Price { get; set; }
        public string DurationText { get; set; }
        public string APICode { get; set; }
        public bool IsActive { get; set; }
    
        public virtual cms_APIType cms_APIType { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<cms_API_Membership_Relationship> cms_API_Membership_Relationship { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<cms_Bill_API> cms_Bill_API { get; set; }
    }
}
