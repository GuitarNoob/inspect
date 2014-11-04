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
    
    public partial class PayrollCycle
    {
        public PayrollCycle()
        {
            this.PayPeriods = new HashSet<PayPeriod>();
            this.TimeCards = new HashSet<TimeCard>();
            this.Users = new HashSet<User>();
        }
    
        public int PayrollCyclePK { get; set; }
        public string Name { get; set; }
        public Nullable<bool> UserDefined { get; set; }
        public Nullable<System.DateTime> FirstStartDate { get; set; }
        public Nullable<bool> Monthly { get; set; }
        public Nullable<int> FirstMonthDay { get; set; }
        public Nullable<int> SecondMonthDay { get; set; }
        public Nullable<int> ThirdMonthDay { get; set; }
        public Nullable<int> ForthMonthDay { get; set; }
        public Nullable<bool> Weekly { get; set; }
        public Nullable<int> WeekIntervals { get; set; }
        public Nullable<int> FirstDayOfWeek { get; set; }
        public Nullable<System.DateTime> LastPayPeriodDate { get; set; }
        public byte[] LastAccess { get; set; }
    
        public virtual ICollection<PayPeriod> PayPeriods { get; set; }
        public virtual ICollection<TimeCard> TimeCards { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}
