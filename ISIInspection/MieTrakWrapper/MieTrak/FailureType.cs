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
    
    public partial class FailureType
    {
        public FailureType()
        {
            this.MachineMaintenanceScheduleRequests = new HashSet<MachineMaintenanceScheduleRequest>();
            this.MachineMaintenanceScheduleWorkOrders = new HashSet<MachineMaintenanceScheduleWorkOrder>();
            this.QualityControls = new HashSet<QualityControl>();
            this.QualityControls1 = new HashSet<QualityControl>();
            this.QualityControls2 = new HashSet<QualityControl>();
        }
    
        public int FailureTypePK { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public string Notes { get; set; }
        public byte[] LastAccess { get; set; }
    
        public virtual ICollection<MachineMaintenanceScheduleRequest> MachineMaintenanceScheduleRequests { get; set; }
        public virtual ICollection<MachineMaintenanceScheduleWorkOrder> MachineMaintenanceScheduleWorkOrders { get; set; }
        public virtual ICollection<QualityControl> QualityControls { get; set; }
        public virtual ICollection<QualityControl> QualityControls1 { get; set; }
        public virtual ICollection<QualityControl> QualityControls2 { get; set; }
    }
}
