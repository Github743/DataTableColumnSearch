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
    
    public partial class CrewDetail
    {
        public int CrewId { get; set; }
        public int PersonalDetailId { get; set; }
        public string CrewName { get; set; }
        public string CrewGender { get; set; }
        public string CrewGenderOther { get; set; }
        public int CrewNationalityId { get; set; }
        public int CrewAge { get; set; }
        public string CrewPassPortNumber { get; set; }
        public string CrewRoleOnBoard { get; set; }
        public string CrewOnDuty { get; set; }
        public string CrewHourOfWork { get; set; }
        public string CrewHourOfRest { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedDt { get; set; }
        public string UpdatedBy { get; set; }
        public Nullable<System.DateTime> UpdatedDt { get; set; }
        public Nullable<bool> IsSuppressed { get; set; }
    
        public virtual PersonalDetail PersonalDetail { get; set; }
    }
}
