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
    
    public partial class BirthDetail
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public BirthDetail()
        {
            this.BirthDetailAttachments = new HashSet<BirthDetailAttachment>();
        }
    
        public int BirthDetailId { get; set; }
        public int ReportableEventId { get; set; }
        public string NewBornName { get; set; }
        public string NewBornGender { get; set; }
        public string OtherGender { get; set; }
        public System.DateTime NewBornDateofBirth { get; set; }
        public string NewBornBirthTime { get; set; }
        public int NewBornBirthTimeZone { get; set; }
        public string NewBornWeight { get; set; }
        public string MotherName { get; set; }
        public int MotherAge { get; set; }
        public int MotherNationalityId { get; set; }
        public string MotherPassportNumer { get; set; }
        public string MotherOccupation { get; set; }
        public string MotherUsualAddress { get; set; }
        public string FatherName { get; set; }
        public int FatherAge { get; set; }
        public int FatherNationalityId { get; set; }
        public string FatherPassportNumer { get; set; }
        public string FatherOccupation { get; set; }
        public string FatherUsualAddress { get; set; }
        public string MotherSignature { get; set; }
        public string FatherSignature { get; set; }
        public bool OfficialLogBookEntry { get; set; }
        public bool DoctorReport { get; set; }
        public bool CopyofMotherPassport { get; set; }
        public bool CopyofFatherPassport { get; set; }
        public string SignatureByMaster { get; set; }
        public System.DateTime DateSigned { get; set; }
        public Nullable<bool> IsSuppressed { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedDt { get; set; }
        public string UpdatedBy { get; set; }
        public Nullable<System.DateTime> UpdatedDt { get; set; }
    
        public virtual ReportableEvent ReportableEvent { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BirthDetailAttachment> BirthDetailAttachments { get; set; }
    }
}
