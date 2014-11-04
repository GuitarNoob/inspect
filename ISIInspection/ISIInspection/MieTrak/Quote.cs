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
    
    public partial class Quote
    {
        public Quote()
        {
            this.Documents = new HashSet<Document>();
            this.ElectronicRequestForQuoteLines = new HashSet<ElectronicRequestForQuoteLine>();
            this.InvoiceLines = new HashSet<InvoiceLine>();
            this.QuoteAssemblies = new HashSet<QuoteAssembly>();
            this.QuoteAssemblies1 = new HashSet<QuoteAssembly>();
            this.QuoteAssemblies2 = new HashSet<QuoteAssembly>();
            this.QuoteBuyers = new HashSet<QuoteBuyer>();
            this.QuoteQuantities = new HashSet<QuoteQuantity>();
            this.QuoteSalespersons = new HashSet<QuoteSalesperson>();
            this.RequestForQuoteLines = new HashSet<RequestForQuoteLine>();
            this.SalesOrderLines = new HashSet<SalesOrderLine>();
            this.TaskActivities = new HashSet<TaskActivity>();
        }
    
        public int QuotePK { get; set; }
        public Nullable<int> CustomerFK { get; set; }
        public Nullable<int> CurrencyCodeFK { get; set; }
        public Nullable<int> DivisionFK { get; set; }
        public Nullable<int> ItemFK { get; set; }
        public Nullable<int> QuoteStatusFK { get; set; }
        public Nullable<int> OverheadRateFK { get; set; }
        public Nullable<int> SalespersonFK { get; set; }
        public Nullable<int> UserFK { get; set; }
        public Nullable<int> CreatorFK { get; set; }
        public Nullable<byte> QuoteType { get; set; }
        public Nullable<bool> Lock { get; set; }
        public Nullable<System.DateTime> DateStamp { get; set; }
        public Nullable<System.DateTime> LastUpdateDateStamp { get; set; }
        public string PartNumber { get; set; }
        public string Revision { get; set; }
        public string QuoteNumber { get; set; }
        public string ExternalReferenceNumber { get; set; }
        public Nullable<decimal> SalespersonCommissionPercentage { get; set; }
        public Nullable<decimal> QuoteWeight { get; set; }
        public string QuotePurpose { get; set; }
        public string Comment { get; set; }
        public byte[] LastAccess { get; set; }
        public Nullable<bool> PopupNotifyComment { get; set; }
        public string NotifyComment { get; set; }
        public Nullable<System.DateTime> LastReviewedDate { get; set; }
        public string RouterNumber { get; set; }
    
        public virtual CurrencyCode CurrencyCode { get; set; }
        public virtual Division Division { get; set; }
        public virtual ICollection<Document> Documents { get; set; }
        public virtual ICollection<ElectronicRequestForQuoteLine> ElectronicRequestForQuoteLines { get; set; }
        public virtual ICollection<InvoiceLine> InvoiceLines { get; set; }
        public virtual Item Item { get; set; }
        public virtual OverheadRateType OverheadRateType { get; set; }
        public virtual Party Party { get; set; }
        public virtual Party Party1 { get; set; }
        public virtual QuoteStatu QuoteStatu { get; set; }
        public virtual User User { get; set; }
        public virtual User User1 { get; set; }
        public virtual ICollection<QuoteAssembly> QuoteAssemblies { get; set; }
        public virtual ICollection<QuoteAssembly> QuoteAssemblies1 { get; set; }
        public virtual ICollection<QuoteAssembly> QuoteAssemblies2 { get; set; }
        public virtual ICollection<QuoteBuyer> QuoteBuyers { get; set; }
        public virtual ICollection<QuoteQuantity> QuoteQuantities { get; set; }
        public virtual ICollection<QuoteSalesperson> QuoteSalespersons { get; set; }
        public virtual ICollection<RequestForQuoteLine> RequestForQuoteLines { get; set; }
        public virtual ICollection<SalesOrderLine> SalesOrderLines { get; set; }
        public virtual ICollection<TaskActivity> TaskActivities { get; set; }
    }
}