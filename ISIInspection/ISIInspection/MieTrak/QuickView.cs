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
    
    public partial class QuickView
    {
        public QuickView()
        {
            this.QuickViewParameters = new HashSet<QuickViewParameter>();
            this.QuickViewUsers = new HashSet<QuickViewUser>();
            this.ReportDivisions = new HashSet<ReportDivision>();
            this.UserStartupWidgets = new HashSet<UserStartupWidget>();
        }
    
        public int QuickViewPK { get; set; }
        public Nullable<int> CreatorFK { get; set; }
        public string Description { get; set; }
        public Nullable<bool> Executable { get; set; }
        public Nullable<bool> Email { get; set; }
        public string Path { get; set; }
        public string Arguments { get; set; }
        public string SQLCommand { get; set; }
        public Nullable<bool> UseDefaultValue { get; set; }
        public Nullable<bool> TotalQuickView { get; set; }
        public Nullable<bool> Enabled { get; set; }
        public Nullable<bool> UseInterval { get; set; }
        public Nullable<int> IntervalMinutes { get; set; }
        public Nullable<System.DateTime> StartTime { get; set; }
        public Nullable<System.DateTime> EndTime { get; set; }
        public Nullable<System.DateTime> SpecifiedTime { get; set; }
        public Nullable<bool> Sunday { get; set; }
        public Nullable<bool> Monday { get; set; }
        public Nullable<bool> Tuesday { get; set; }
        public Nullable<bool> Wednesday { get; set; }
        public Nullable<bool> Thursday { get; set; }
        public Nullable<bool> Friday { get; set; }
        public Nullable<bool> Saturday { get; set; }
        public Nullable<bool> FirstOfTheMonth { get; set; }
        public Nullable<bool> EndOfTheMonth { get; set; }
        public Nullable<int> RunOn { get; set; }
        public Nullable<System.DateTime> LastRunTime { get; set; }
        public Nullable<System.DateTime> NextRunTime { get; set; }
        public string EmailAddress { get; set; }
        public string Subject { get; set; }
        public string EmailBody { get; set; }
        public string PostSQLScript { get; set; }
        public byte[] LastAccess { get; set; }
        public string QuickViewGroup { get; set; }
        public Nullable<bool> StoredProcedure { get; set; }
        public Nullable<bool> Import { get; set; }
    
        public virtual User User { get; set; }
        public virtual ICollection<QuickViewParameter> QuickViewParameters { get; set; }
        public virtual ICollection<QuickViewUser> QuickViewUsers { get; set; }
        public virtual ICollection<ReportDivision> ReportDivisions { get; set; }
        public virtual ICollection<UserStartupWidget> UserStartupWidgets { get; set; }
    }
}