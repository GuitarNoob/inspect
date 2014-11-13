//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MieTrakWrapper.MieTrak
{
    using System;
    using System.Collections.Generic;
    
    public partial class TimeClockEntry
    {
        public int TimeClockEntryPK { get; set; }
        public int TimeClockEntryTypeFK { get; set; }
        public int ShiftFK { get; set; }
        public Nullable<int> TimeCardFK { get; set; }
        public int UserFK { get; set; }
        public Nullable<System.DateTime> ClockIn { get; set; }
        public Nullable<System.DateTime> ScanIn { get; set; }
        public Nullable<System.DateTime> ClockOut { get; set; }
        public Nullable<System.DateTime> ScanOut { get; set; }
        public Nullable<System.DateTime> LunchOut { get; set; }
        public Nullable<System.DateTime> LunchIn { get; set; }
        public Nullable<System.DateTime> ScanLunchOut { get; set; }
        public Nullable<System.DateTime> ScanLunchIn { get; set; }
        public string Comment { get; set; }
        public bool ReviewRequired { get; set; }
        public bool ManagerReviewed { get; set; }
        public Nullable<bool> IssueResolved { get; set; }
        public string ManagerReviewComment { get; set; }
        public string EmployeeComment { get; set; }
        public Nullable<bool> Posted { get; set; }
        public Nullable<System.DateTime> PostedDate { get; set; }
        public Nullable<decimal> TotalHours { get; set; }
        public Nullable<decimal> LunchHours { get; set; }
        public Nullable<decimal> RegularHours { get; set; }
        public Nullable<decimal> Overtime1Hours { get; set; }
        public Nullable<decimal> Overtime2Hours { get; set; }
        public Nullable<decimal> Overtime3Hours { get; set; }
        public Nullable<decimal> UnpaidHours { get; set; }
        public bool ManuallySetLunch { get; set; }
        public Nullable<bool> PostOverrided { get; set; }
        public Nullable<bool> IsCurrent { get; set; }
        public byte[] LastAccess { get; set; }
    
        public virtual Shift Shift { get; set; }
        public virtual TimeCard TimeCard { get; set; }
        public virtual TimeClockEntryType TimeClockEntryType { get; set; }
        public virtual User User { get; set; }
    }
}