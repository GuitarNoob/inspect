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
    
    public partial class MachineMaintenanceRequiredItem
    {
        public int MachineMaintenanceRequiredItemPK { get; set; }
        public Nullable<int> ItemFK { get; set; }
        public Nullable<int> MachineMaintenanceScheduleFK { get; set; }
        public Nullable<int> MachineMaintenanceScheduleWorkOrderFK { get; set; }
        public Nullable<int> MachineMaintenanceScheduleRequestFK { get; set; }
        public Nullable<int> SupplierFK { get; set; }
        public string Name { get; set; }
        public Nullable<decimal> Quantity { get; set; }
        public Nullable<decimal> ActualQuantity { get; set; }
        public Nullable<decimal> UnitPrice { get; set; }
        public Nullable<decimal> ExtendedPrice { get; set; }
        public string Notes { get; set; }
        public byte[] LastAccess { get; set; }
    
        public virtual Item Item { get; set; }
        public virtual MachineMaintenanceSchedule MachineMaintenanceSchedule { get; set; }
        public virtual MachineMaintenanceScheduleRequest MachineMaintenanceScheduleRequest { get; set; }
        public virtual MachineMaintenanceScheduleWorkOrder MachineMaintenanceScheduleWorkOrder { get; set; }
        public virtual Party Party { get; set; }
    }
}
