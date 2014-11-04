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
    
    public partial class Term
    {
        public Term()
        {
            this.Bills = new HashSet<Bill>();
            this.CustomerAgings = new HashSet<CustomerAging>();
            this.ElectronicSalesOrderLines = new HashSet<ElectronicSalesOrderLine>();
            this.Invoices = new HashSet<Invoice>();
            this.Parties = new HashSet<Party>();
            this.Parties1 = new HashSet<Party>();
            this.PurchaseOrders = new HashSet<PurchaseOrder>();
            this.PurchaseOrderReceivings = new HashSet<PurchaseOrderReceiving>();
            this.RequestForQuotes = new HashSet<RequestForQuote>();
            this.SalesOrders = new HashSet<SalesOrder>();
            this.SupplierAgings = new HashSet<SupplierAging>();
        }
    
        public int TermPK { get; set; }
        public Nullable<int> DiscountTypeFK { get; set; }
        public Nullable<int> DueTypeFK { get; set; }
        public Nullable<bool> MultipleDueDates { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public string ExternalReferenceNumber { get; set; }
        public Nullable<int> DueDays { get; set; }
        public Nullable<int> DueMonths { get; set; }
        public Nullable<int> DiscountDays { get; set; }
        public Nullable<int> DiscountMonths { get; set; }
        public Nullable<decimal> DiscountPercentage { get; set; }
        public Nullable<bool> ShowPopupAtShipping { get; set; }
        public string PopupShippingComments { get; set; }
        public byte[] LastAccess { get; set; }
    
        public virtual ICollection<Bill> Bills { get; set; }
        public virtual ICollection<CustomerAging> CustomerAgings { get; set; }
        public virtual ICollection<ElectronicSalesOrderLine> ElectronicSalesOrderLines { get; set; }
        public virtual ICollection<Invoice> Invoices { get; set; }
        public virtual ICollection<Party> Parties { get; set; }
        public virtual ICollection<Party> Parties1 { get; set; }
        public virtual ICollection<PurchaseOrder> PurchaseOrders { get; set; }
        public virtual ICollection<PurchaseOrderReceiving> PurchaseOrderReceivings { get; set; }
        public virtual ICollection<RequestForQuote> RequestForQuotes { get; set; }
        public virtual ICollection<SalesOrder> SalesOrders { get; set; }
        public virtual ICollection<SupplierAging> SupplierAgings { get; set; }
        public virtual TermType TermType { get; set; }
        public virtual TermType TermType1 { get; set; }
    }
}