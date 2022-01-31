using System;

namespace jQueryDataTable.Models
{
    public class ReportableEventGrid
    {
        public string Event { get; set; }
        public int ReportableEventId { get; set; }
        public int VesselDetailId { get; set; }
        public string VesselName { get; set; }
        public string VesselType { get; set; }
        public string EventType { get; set; }
        public DateTime EventDate { get; set; }
        public string Severity { get; set; }
        public string Status { get; set; }
        public string Assignee { get; set; }
        public string BriefDescription { get; set; }
    }
}