//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace jQueryDataTable
{
    using System;
    using System.Collections.Generic;
    
    public partial class ContactDetail
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ContactDetail()
        {
            this.ContactDetailAttachments = new HashSet<ContactDetailAttachment>();
        }
    
        public int ContactDetailId { get; set; }
        public int ReportableEventId { get; set; }
        public string PersonName { get; set; }
        public string PersonRole { get; set; }
        public System.DateTime PersonDate { get; set; }
        public string PersonEmail { get; set; }
        public string DPAName { get; set; }
        public string DPAEmail { get; set; }
        public long DPAPhoneNumber { get; set; }
        public string MasterName { get; set; }
        public long MasterPhoneNumber { get; set; }
        public string MasterEmail { get; set; }
        public Nullable<bool> IsSuppressed { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedDt { get; set; }
        public string UpdatedBy { get; set; }
        public Nullable<System.DateTime> UpdatedDt { get; set; }
    
        public virtual ReportableEvent ReportableEvent { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ContactDetailAttachment> ContactDetailAttachments { get; set; }
    }
}