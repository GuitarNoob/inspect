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
    
    public partial class ItemInventoryTransaction
    {
        public int ItemInventoryTransactionPK { get; set; }
        public Nullable<int> ItemFK { get; set; }
        public Nullable<int> LocationFK { get; set; }
        public Nullable<int> InvoiceFK { get; set; }
        public Nullable<int> WorkOrderFK { get; set; }
        public Nullable<int> WorkOrderNestFK { get; set; }
        public Nullable<int> PurchaseOrderReceivingFK { get; set; }
        public Nullable<int> UserFK { get; set; }
        public Nullable<int> ItemInventoryTransactionTypeFK { get; set; }
        public string PartNumber { get; set; }
        public string Revision { get; set; }
        public Nullable<decimal> Quantity { get; set; }
        public Nullable<decimal> QuantityOnHand { get; set; }
        public Nullable<decimal> Cost { get; set; }
        public Nullable<decimal> StandardCost { get; set; }
        public Nullable<decimal> AverageCost { get; set; }
        public Nullable<decimal> LastCost { get; set; }
        public Nullable<decimal> QuantityUsed { get; set; }
        public Nullable<decimal> FIFOCost { get; set; }
        public Nullable<bool> SetAsStandardCost { get; set; }
        public Nullable<bool> SetAsLastCost { get; set; }
        public string LocationDescription { get; set; }
        public string Container { get; set; }
        public string LotNumber { get; set; }
        public string Comment { get; set; }
        public Nullable<System.DateTime> TransactionDate { get; set; }
        public byte[] LastAccess { get; set; }
        public string BatchNumber { get; set; }
        public Nullable<int> DivisionNumber { get; set; }
        public Nullable<System.DateTime> ExpirationDate { get; set; }
        public Nullable<int> ScrapReasonFK { get; set; }
    
        public virtual Invoice Invoice { get; set; }
        public virtual Item Item { get; set; }
        public virtual ItemInventoryTransactionType ItemInventoryTransactionType { get; set; }
        public virtual Location Location { get; set; }
        public virtual ScrapReason ScrapReason { get; set; }
        public virtual User User { get; set; }
    }
}
