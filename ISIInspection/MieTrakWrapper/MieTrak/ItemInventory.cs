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
    
    public partial class ItemInventory
    {
        public ItemInventory()
        {
            this.Items = new HashSet<Item>();
        }
    
        public int ItemInventoryPK { get; set; }
        public Nullable<decimal> QuantityOnHand { get; set; }
        public Nullable<decimal> QuantityReserved { get; set; }
        public Nullable<decimal> QuantityDemand { get; set; }
        public Nullable<decimal> QuantityWorkInProcess { get; set; }
        public Nullable<decimal> QuantityPull { get; set; }
        public Nullable<decimal> QuantityOrdered { get; set; }
        public Nullable<decimal> QuantityOnDock { get; set; }
        public Nullable<decimal> StandardCost { get; set; }
        public Nullable<decimal> LandedCost { get; set; }
        public Nullable<decimal> LastCost { get; set; }
        public Nullable<decimal> AverageCost { get; set; }
        public Nullable<decimal> FIFOCost { get; set; }
        public Nullable<System.DateTime> LastOrderDate { get; set; }
        public Nullable<System.DateTime> LastTransactionDate { get; set; }
        public Nullable<System.DateTime> LastCostDate { get; set; }
        public byte[] LastAccess { get; set; }
        public Nullable<decimal> StandardQuantity { get; set; }
        public Nullable<decimal> StandardHoursEstimate { get; set; }
        public Nullable<decimal> StandardDirectLabor { get; set; }
        public Nullable<decimal> StandardEmployeeOverhead { get; set; }
        public Nullable<decimal> StandardWorkCenterOverhead { get; set; }
        public Nullable<decimal> StandardMaterialCosts { get; set; }
        public Nullable<decimal> StandardHardwareCosts { get; set; }
        public Nullable<decimal> StandardOutsideProcessingCosts { get; set; }
        public Nullable<decimal> StandardProductCosts { get; set; }
        public Nullable<System.DateTime> LastUpdatedDate { get; set; }
        public Nullable<System.DateTime> LastStandardCostUpdateDate { get; set; }
        public Nullable<decimal> QuantitySubcomponentWorkInProgress { get; set; }
        public Nullable<decimal> MRPDemand { get; set; }
        public Nullable<System.DateTime> DateCalculated { get; set; }
    
        public virtual ICollection<Item> Items { get; set; }
    }
}
