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
    
    public partial class Bill
    {
        public Bill()
        {
            this.BillLines = new HashSet<BillLine>();
            this.Documents = new HashSet<Document>();
            this.GeneralLedgerDetails = new HashSet<GeneralLedgerDetail>();
            this.SupplierAgings = new HashSet<SupplierAging>();
        }
    
        public int BillPK { get; set; }
        public Nullable<int> DivisionFK { get; set; }
        public Nullable<int> SupplierFK { get; set; }
        public Nullable<int> TermFK { get; set; }
        public Nullable<int> BillStatusFK { get; set; }
        public Nullable<int> BillNumber { get; set; }
        public Nullable<System.DateTime> CreateDate { get; set; }
        public Nullable<System.DateTime> DueDate { get; set; }
        public Nullable<System.DateTime> DiscountDate { get; set; }
        public Nullable<System.DateTime> InvoiceDate { get; set; }
        public Nullable<System.DateTime> PostDate { get; set; }
        public string InvoiceNumber { get; set; }
        public string ExternalReferenceNumber { get; set; }
        public Nullable<bool> Taxable { get; set; }
        public Nullable<bool> TaxIncluded { get; set; }
        public Nullable<decimal> SalesTaxRate { get; set; }
        public Nullable<decimal> SalesTaxAmount { get; set; }
        public Nullable<decimal> TotalAmount { get; set; }
        public string Memo { get; set; }
        public byte[] LastAccess { get; set; }
    
        public virtual BillStatu BillStatu { get; set; }
        public virtual Division Division { get; set; }
        public virtual Party Party { get; set; }
        public virtual Term Term { get; set; }
        public virtual ICollection<BillLine> BillLines { get; set; }
        public virtual ICollection<Document> Documents { get; set; }
        public virtual ICollection<GeneralLedgerDetail> GeneralLedgerDetails { get; set; }
        public virtual ICollection<SupplierAging> SupplierAgings { get; set; }
    }
}