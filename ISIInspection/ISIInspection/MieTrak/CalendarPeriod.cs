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
    
    public partial class CalendarPeriod
    {
        public CalendarPeriod()
        {
            this.DivisionParameters = new HashSet<DivisionParameter>();
            this.ItemMasterProductionSchedules = new HashSet<ItemMasterProductionSchedule>();
        }
    
        public int CalenderPeriodPK { get; set; }
        public string Description { get; set; }
        public Nullable<int> Period1 { get; set; }
        public Nullable<int> Period2 { get; set; }
        public Nullable<int> Period3 { get; set; }
        public Nullable<int> Period4 { get; set; }
        public Nullable<int> Period5 { get; set; }
        public Nullable<int> Period6 { get; set; }
        public Nullable<int> Period7 { get; set; }
        public Nullable<int> Period8 { get; set; }
        public Nullable<int> Period9 { get; set; }
        public Nullable<int> Period10 { get; set; }
        public Nullable<int> Period11 { get; set; }
        public Nullable<int> Period12 { get; set; }
        public Nullable<int> Period13 { get; set; }
        public Nullable<int> Period14 { get; set; }
        public Nullable<int> Period15 { get; set; }
        public Nullable<int> Period16 { get; set; }
        public Nullable<int> Period17 { get; set; }
        public Nullable<int> Period18 { get; set; }
        public Nullable<int> Period19 { get; set; }
        public Nullable<int> Period20 { get; set; }
        public Nullable<int> Period21 { get; set; }
        public Nullable<int> Period22 { get; set; }
        public Nullable<int> Period23 { get; set; }
        public Nullable<int> Period24 { get; set; }
        public Nullable<int> Period25 { get; set; }
        public Nullable<int> Period26 { get; set; }
        public byte[] LastAccess { get; set; }
    
        public virtual ICollection<DivisionParameter> DivisionParameters { get; set; }
        public virtual ICollection<ItemMasterProductionSchedule> ItemMasterProductionSchedules { get; set; }
    }
}