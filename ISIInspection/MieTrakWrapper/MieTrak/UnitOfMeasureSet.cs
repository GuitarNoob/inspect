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
    
    public partial class UnitOfMeasureSet
    {
        public UnitOfMeasureSet()
        {
            this.DivisionParameters = new HashSet<DivisionParameter>();
            this.DivisionParameters1 = new HashSet<DivisionParameter>();
            this.DivisionParameters2 = new HashSet<DivisionParameter>();
            this.DivisionParameters3 = new HashSet<DivisionParameter>();
            this.DivisionParameters4 = new HashSet<DivisionParameter>();
            this.DivisionParameters5 = new HashSet<DivisionParameter>();
            this.InvoiceLines = new HashSet<InvoiceLine>();
            this.InvoiceLines1 = new HashSet<InvoiceLine>();
            this.Items = new HashSet<Item>();
            this.ManifestLines = new HashSet<ManifestLine>();
            this.PurchaseOrderLines = new HashSet<PurchaseOrderLine>();
            this.PurchaseOrderReceivingLines = new HashSet<PurchaseOrderReceivingLine>();
            this.QuoteAssemblies = new HashSet<QuoteAssembly>();
            this.RequestForQuoteLines = new HashSet<RequestForQuoteLine>();
            this.RequestForQuoteLines1 = new HashSet<RequestForQuoteLine>();
            this.RequestForQuoteLineQuantities = new HashSet<RequestForQuoteLineQuantity>();
            this.RouterWorkCenters = new HashSet<RouterWorkCenter>();
            this.SalesOrderLines = new HashSet<SalesOrderLine>();
            this.SalesOrderLines1 = new HashSet<SalesOrderLine>();
            this.WorkOrderAssemblies = new HashSet<WorkOrderAssembly>();
        }
    
        public int UnitOfMeasureSetPK { get; set; }
        public int BaseUnitOfMeasureFK { get; set; }
        public Nullable<int> InventoryUnitOfMeasureFK { get; set; }
        public int PurchaseUnitOfMeasureFK { get; set; }
        public int ShippingUnitOfMeasureFK { get; set; }
        public int QuotingUnitOfMeasureFK { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public Nullable<decimal> BaseUnitOfMeasureValue { get; set; }
        public Nullable<bool> PurchaseUnitOfMeasureOverride { get; set; }
        public Nullable<decimal> PurchaseUnitOfMeasureValue { get; set; }
        public Nullable<bool> ShippingUnitOfMeasureOverride { get; set; }
        public Nullable<decimal> ShippingUnitOfMeasureValue { get; set; }
        public Nullable<bool> QuotingUnitOfMeasureOverride { get; set; }
        public Nullable<decimal> QuotingUnitOfMeasureValue { get; set; }
        public byte[] LastAccess { get; set; }
        public Nullable<decimal> VendorUnitInvConversion { get; set; }
    
        public virtual ICollection<DivisionParameter> DivisionParameters { get; set; }
        public virtual ICollection<DivisionParameter> DivisionParameters1 { get; set; }
        public virtual ICollection<DivisionParameter> DivisionParameters2 { get; set; }
        public virtual ICollection<DivisionParameter> DivisionParameters3 { get; set; }
        public virtual ICollection<DivisionParameter> DivisionParameters4 { get; set; }
        public virtual ICollection<DivisionParameter> DivisionParameters5 { get; set; }
        public virtual ICollection<InvoiceLine> InvoiceLines { get; set; }
        public virtual ICollection<InvoiceLine> InvoiceLines1 { get; set; }
        public virtual ICollection<Item> Items { get; set; }
        public virtual ICollection<ManifestLine> ManifestLines { get; set; }
        public virtual ICollection<PurchaseOrderLine> PurchaseOrderLines { get; set; }
        public virtual ICollection<PurchaseOrderReceivingLine> PurchaseOrderReceivingLines { get; set; }
        public virtual ICollection<QuoteAssembly> QuoteAssemblies { get; set; }
        public virtual ICollection<RequestForQuoteLine> RequestForQuoteLines { get; set; }
        public virtual ICollection<RequestForQuoteLine> RequestForQuoteLines1 { get; set; }
        public virtual ICollection<RequestForQuoteLineQuantity> RequestForQuoteLineQuantities { get; set; }
        public virtual ICollection<RouterWorkCenter> RouterWorkCenters { get; set; }
        public virtual ICollection<SalesOrderLine> SalesOrderLines { get; set; }
        public virtual ICollection<SalesOrderLine> SalesOrderLines1 { get; set; }
        public virtual UnitOfMeasure UnitOfMeasure { get; set; }
        public virtual UnitOfMeasure UnitOfMeasure1 { get; set; }
        public virtual UnitOfMeasure UnitOfMeasure2 { get; set; }
        public virtual UnitOfMeasure UnitOfMeasure3 { get; set; }
        public virtual UnitOfMeasure UnitOfMeasure4 { get; set; }
        public virtual ICollection<WorkOrderAssembly> WorkOrderAssemblies { get; set; }
    }
}
