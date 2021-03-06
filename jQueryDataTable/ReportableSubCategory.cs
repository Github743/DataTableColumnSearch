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
    
    public partial class ReportableSubCategory
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ReportableSubCategory()
        {
            this.NearMissReports = new HashSet<NearMissReport>();
            this.ReportableEvents = new HashSet<ReportableEvent>();
        }
    
        public int ReportableSubCategoryId { get; set; }
        public Nullable<int> CategoryId { get; set; }
        public string ReportableSubCategoryName { get; set; }
        public Nullable<bool> IsSuppressed { get; set; }
        public Nullable<System.DateTime> CreatedDt { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<NearMissReport> NearMissReports { get; set; }
        public virtual ReportableCategory ReportableCategory { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ReportableEvent> ReportableEvents { get; set; }
        public virtual ReportableSubSubCategory ReportableSubSubCategory { get; set; }
    }
}
