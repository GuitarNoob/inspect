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
    
    public partial class WorkOrderProgramWorkOrder
    {
        public int WorkOrderProgramWorkOrderPK { get; set; }
        public Nullable<int> WorkOrderProgramFK { get; set; }
        public Nullable<int> ItemFK { get; set; }
        public Nullable<int> WorkOrderAssemblyNumber { get; set; }
        public Nullable<int> WorkOrderNumber { get; set; }
        public Nullable<bool> DropFlag { get; set; }
        public string PartNumber { get; set; }
        public Nullable<decimal> ActualHours { get; set; }
        public Nullable<decimal> ActualPartQuantityProduced { get; set; }
        public Nullable<decimal> ActualPartQuantityScrap { get; set; }
        public Nullable<decimal> EstimatedHours { get; set; }
        public Nullable<decimal> PartQuantity { get; set; }
        public Nullable<decimal> MaterialQuantityIssued { get; set; }
        public Nullable<decimal> MaterialQuantityRequired { get; set; }
        public Nullable<decimal> MaterialQuantityScrapped { get; set; }
        public byte[] LastAccess { get; set; }
        public Nullable<decimal> PartLength { get; set; }
        public Nullable<decimal> PartWidth { get; set; }
        public Nullable<decimal> BlankLength { get; set; }
        public Nullable<decimal> BlankWidth { get; set; }
    
        public virtual Item Item { get; set; }
        public virtual WorkOrderProgram WorkOrderProgram { get; set; }
    }
}