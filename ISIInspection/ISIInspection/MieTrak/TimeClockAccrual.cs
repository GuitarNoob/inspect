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
    
    public partial class TimeClockAccrual
    {
        public TimeClockAccrual()
        {
            this.EmploymentTypeAccruals = new HashSet<EmploymentTypeAccrual>();
            this.TimeClockEntryTypes = new HashSet<TimeClockEntryType>();
            this.UserAccruals = new HashSet<UserAccrual>();
        }
    
        public int TimeClockAccrualPK { get; set; }
        public Nullable<int> TimClockEntryTypeFK { get; set; }
        public string Name { get; set; }
        public byte[] LastAccess { get; set; }
    
        public virtual ICollection<EmploymentTypeAccrual> EmploymentTypeAccruals { get; set; }
        public virtual TimeClockEntryType TimeClockEntryType { get; set; }
        public virtual ICollection<TimeClockEntryType> TimeClockEntryTypes { get; set; }
        public virtual ICollection<UserAccrual> UserAccruals { get; set; }
    }
}
