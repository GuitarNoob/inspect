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
    
    public partial class TaskWorkFlow
    {
        public int TaskWorkFlowPK { get; set; }
        public Nullable<int> AssignedToFK { get; set; }
        public Nullable<int> TaskActivityFK { get; set; }
        public Nullable<int> OrderIndex { get; set; }
        public Nullable<int> Days { get; set; }
        public Nullable<System.DateTime> DeadlineDate { get; set; }
        public Nullable<System.DateTime> CompletedDate { get; set; }
        public Nullable<bool> Complete { get; set; }
        public Nullable<bool> EmailAssignedTo { get; set; }
        public string Description { get; set; }
        public string Comment { get; set; }
        public string Notes { get; set; }
        public byte[] LastAccess { get; set; }
    
        public virtual TaskActivity TaskActivity { get; set; }
        public virtual User User { get; set; }
    }
}
