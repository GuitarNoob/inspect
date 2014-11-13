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
    
    public partial class BillLine
    {
        public BillLine()
        {
            this.GeneralLedgerDetails = new HashSet<GeneralLedgerDetail>();
        }
    
        public int BillLinePK { get; set; }
        public Nullable<int> BillFK { get; set; }
        public Nullable<int> GeneralLedgerAccountFK { get; set; }
        public Nullable<decimal> Amount { get; set; }
        public string Memo { get; set; }
        public byte[] LastAccess { get; set; }
        public Nullable<int> PurchaseOrderReceivingNumber { get; set; }
        public Nullable<int> PurchaseOrderReceivingLineFK { get; set; }
        public Nullable<int> PurchaseOrderReceivingLineReferenceNumber { get; set; }
        public Nullable<int> PurchaseOrderNumber { get; set; }
        public Nullable<decimal> Quantity { get; set; }
        public Nullable<int> ItemFK { get; set; }
        public string PartNumber { get; set; }
        public string Revision { get; set; }
        public string Description { get; set; }
        public Nullable<decimal> StockWidth { get; set; }
        public Nullable<decimal> StockLength { get; set; }
    
        public virtual Bill Bill { get; set; }
        public virtual GeneralLedgerAccount GeneralLedgerAccount { get; set; }
        public virtual Item Item { get; set; }
        public virtual ICollection<GeneralLedgerDetail> GeneralLedgerDetails { get; set; }
    }
}