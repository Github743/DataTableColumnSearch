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
    
    public partial class ReportableEventDetailHistory
    {
        public int ReportableEventDetailHistoryId { get; set; }
        public int ReportableEventId { get; set; }
        public Nullable<int> AssigneeId { get; set; }
        public Nullable<int> EventSeverityId { get; set; }
        public Nullable<int> EventStatusId { get; set; }
        public Nullable<int> EventActionId { get; set; }
        public string TechnicalManager { get; set; }
        public string DpaEmail { get; set; }
        public Nullable<bool> IsPassport { get; set; }
        public Nullable<bool> IsDeath { get; set; }
        public Nullable<bool> IsDoctorReport { get; set; }
        public Nullable<bool> IsOfficial { get; set; }
        public Nullable<bool> IsPhoto { get; set; }
        public Nullable<bool> IsWitnessStatement { get; set; }
        public Nullable<bool> NeedMoreInfo { get; set; }
        public string EmailId { get; set; }
        public Nullable<bool> IsRecomended { get; set; }
        public string Recommendation { get; set; }
        public Nullable<bool> IsRemarks { get; set; }
        public string Remarks { get; set; }
        public Nullable<System.DateTime> PublishedDt { get; set; }
        public Nullable<System.DateTime> ClosedDt { get; set; }
        public Nullable<bool> IsClosure { get; set; }
        public string ClosureBody { get; set; }
        public string NmiEmailBody { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedDt { get; set; }
    }
}