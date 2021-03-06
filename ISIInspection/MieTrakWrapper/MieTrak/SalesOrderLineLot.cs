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
    
    public partial class SalesOrderLineLot
    {
        public SalesOrderLineLot()
        {
            this.InvoiceLines = new HashSet<InvoiceLine>();
            this.MRPDetails = new HashSet<MRPDetail>();
            this.WorkOrderJobs = new HashSet<WorkOrderJob>();
        }
    
        public int SalesOrderLineLotPK { get; set; }
        public Nullable<int> SalesOrderLineFK { get; set; }
        public Nullable<int> SalesOrderLineLotStatusFK { get; set; }
        public string UserDefined { get; set; }
        public Nullable<System.DateTime> DateStamp { get; set; }
        public Nullable<System.DateTime> DueDate { get; set; }
        public Nullable<System.DateTime> PromiseDate { get; set; }
        public Nullable<System.DateTime> OriginalDueDate { get; set; }
        public Nullable<System.DateTime> ExpectedReleaseDate { get; set; }
        public string PurchaseOrderNumber { get; set; }
        public string WorkOrderNumber { get; set; }
        public Nullable<System.DateTime> ReleaseDate { get; set; }
        public Nullable<decimal> QuantityDue { get; set; }
        public Nullable<decimal> QuantityShipped { get; set; }
        public Nullable<decimal> OriginalQuantity { get; set; }
        public Nullable<decimal> QuantityToFabricate { get; set; }
        public Nullable<decimal> QuantityToPull { get; set; }
        public string Notes { get; set; }
        public Nullable<bool> PlannedFlag { get; set; }
        public byte[] LastAccess { get; set; }
        public Nullable<System.DateTime> ScheduledShipDate { get; set; }
    
        public virtual ICollection<InvoiceLine> InvoiceLines { get; set; }
        public virtual ICollection<MRPDetail> MRPDetails { get; set; }
        public virtual SalesOrderLine SalesOrderLine { get; set; }
        public virtual SalesOrderLineLotStatu SalesOrderLineLotStatu { get; set; }
        public virtual ICollection<WorkOrderJob> WorkOrderJobs { get; set; }
    }
}
