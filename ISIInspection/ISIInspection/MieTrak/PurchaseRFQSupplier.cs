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
    
    public partial class PurchaseRFQSupplier
    {
        public PurchaseRFQSupplier()
        {
            this.PurchaseRFQSupplierLines = new HashSet<PurchaseRFQSupplierLine>();
        }
    
        public int PurchaseRFQSupplierPK { get; set; }
        public Nullable<int> ContactFK { get; set; }
        public Nullable<int> PurchaseOrderBidStatusFK { get; set; }
        public Nullable<int> SupplierFK { get; set; }
        public Nullable<bool> IsUsed { get; set; }
        public Nullable<System.DateTime> DateResponded { get; set; }
        public Nullable<System.DateTime> DateSubmitted { get; set; }
        public string Comment { get; set; }
        public byte[] LastAccess { get; set; }
    
        public virtual Party Party { get; set; }
        public virtual Party Party1 { get; set; }
        public virtual PurchaseOrderBidStatu PurchaseOrderBidStatu { get; set; }
        public virtual ICollection<PurchaseRFQSupplierLine> PurchaseRFQSupplierLines { get; set; }
    }
}
