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
    
    public partial class ObjectDetail
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ObjectDetail()
        {
            this.ObjectDetailAttachments = new HashSet<ObjectDetailAttachment>();
        }
    
        public int ObjectDetailId { get; set; }
        public int ReportableEventId { get; set; }
        public string DetailsofObject { get; set; }
        public Nullable<bool> IsSuppressed { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedDt { get; set; }
        public string UpdatedBy { get; set; }
        public Nullable<System.DateTime> UpdatedDt { get; set; }
    
        public virtual ReportableEvent ReportableEvent { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ObjectDetailAttachment> ObjectDetailAttachments { get; set; }
    }
}