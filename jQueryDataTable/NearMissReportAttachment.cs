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
    
    public partial class NearMissReportAttachment
    {
        public int NearMissReportAttachmentId { get; set; }
        public int NearMissReportId { get; set; }
        public string AttachmentName { get; set; }
        public string AttachmentType { get; set; }
        public string AttachmentData { get; set; }
        public Nullable<bool> IsSuppressed { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedDt { get; set; }
        public string UpdatedBy { get; set; }
        public Nullable<System.DateTime> UpdatedDt { get; set; }
    
        public virtual NearMissReport NearMissReport { get; set; }
    }
}
