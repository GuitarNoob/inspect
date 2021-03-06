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
    
    public partial class Kit
    {
        public int KitPK { get; set; }
        public Nullable<int> KitTypeFK { get; set; }
        public Nullable<int> RequestForQuoteLineFK { get; set; }
        public Nullable<int> SalesOrderLineFK { get; set; }
        public Nullable<int> InvoiceLineFK { get; set; }
        public Nullable<int> KitFK { get; set; }
        public Nullable<int> ComponentFK { get; set; }
        public Nullable<int> OriginalComponentFK { get; set; }
        public Nullable<decimal> ComponentQuantity { get; set; }
        public Nullable<decimal> ComponentCost { get; set; }
        public Nullable<decimal> ComponentPrice { get; set; }
        public Nullable<bool> IncludeComponent { get; set; }
        public Nullable<bool> ComponentOptional { get; set; }
        public Nullable<bool> ComponentSubstitutable { get; set; }
        public Nullable<bool> ComponentSubstituted { get; set; }
        public byte[] LastAccess { get; set; }
        public string OtherDescription { get; set; }
    
        public virtual InvoiceLine InvoiceLine { get; set; }
        public virtual Item Item { get; set; }
        public virtual Item Item1 { get; set; }
        public virtual Item Item2 { get; set; }
        public virtual KitType KitType { get; set; }
        public virtual RequestForQuoteLine RequestForQuoteLine { get; set; }
        public virtual SalesOrderLine SalesOrderLine { get; set; }
    }
}
