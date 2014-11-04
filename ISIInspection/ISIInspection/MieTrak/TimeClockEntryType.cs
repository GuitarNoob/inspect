//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ISIInspection.MieTrak
{
    using System;
    using System.Collections.Generic;
    
    public partial class TimeClockEntryType
    {
        public TimeClockEntryType()
        {
            this.TimeCardTotals = new HashSet<TimeCardTotal>();
            this.TimeClockAccruals = new HashSet<TimeClockAccrual>();
            this.TimeClockEntries = new HashSet<TimeClockEntry>();
        }
    
        public int TimeClockEntryTypePK { get; set; }
        public Nullable<int> TimeClockAccrualFK { get; set; }
        public string Name { get; set; }
        public bool PaidHours { get; set; }
        public bool CalculateTowardsOverTimeHours { get; set; }
        public bool CalculateTowardsAccruals { get; set; }
        public bool RegularHours { get; set; }
        public bool Overtime1 { get; set; }
        public bool Overtime2 { get; set; }
        public bool Overtime3 { get; set; }
        public byte[] LastAccess { get; set; }
    
        public virtual ICollection<TimeCardTotal> TimeCardTotals { get; set; }
        public virtual ICollection<TimeClockAccrual> TimeClockAccruals { get; set; }
        public virtual TimeClockAccrual TimeClockAccrual { get; set; }
        public virtual ICollection<TimeClockEntry> TimeClockEntries { get; set; }
        public virtual TimeClockEntryType TimeClockEntryType1 { get; set; }
        public virtual TimeClockEntryType TimeClockEntryType2 { get; set; }
    }
}