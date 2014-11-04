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
    
    public partial class PurchaseOrderReceiving
    {
        public PurchaseOrderReceiving()
        {
            this.BusinessProcessResults = new HashSet<BusinessProcessResult>();
            this.Documents = new HashSet<Document>();
            this.GeneralLedgerDetails = new HashSet<GeneralLedgerDetail>();
            this.PurchaseOrderReceivingLines = new HashSet<PurchaseOrderReceivingLine>();
            this.QualityControls = new HashSet<QualityControl>();
            this.SupplierAgings = new HashSet<SupplierAging>();
            this.TaskActivities = new HashSet<TaskActivity>();
        }
    
        public int PurchaseOrderReceivingPK { get; set; }
        public Nullable<int> DivisionFK { get; set; }
        public Nullable<int> SupplierFK { get; set; }
        public Nullable<int> BillingAddressFK { get; set; }
        public Nullable<int> TermFK { get; set; }
        public Nullable<int> CurrencyCodeFK { get; set; }
        public Nullable<int> PurchaseOrderReceivingStatusFK { get; set; }
        public Nullable<int> MiscellaneousGeneralLedgerAccount1FK { get; set; }
        public Nullable<int> MiscellaneousGeneralLedgerAccount2FK { get; set; }
        public Nullable<int> MiscellaneousGeneralLedgerAccount3FK { get; set; }
        public Nullable<int> PurchaseOrderReceivingNumber { get; set; }
        public Nullable<int> PurchaseOrderNumber { get; set; }
        public Nullable<bool> Approved { get; set; }
        public Nullable<bool> CertificationsReceived { get; set; }
        public Nullable<bool> Exported { get; set; }
        public Nullable<bool> Rejected { get; set; }
        public Nullable<bool> PaidInFull { get; set; }
        public Nullable<bool> Posted { get; set; }
        public Nullable<bool> ShowByHomeCurrency { get; set; }
        public Nullable<System.DateTime> CreateDate { get; set; }
        public Nullable<System.DateTime> ReceiveDate { get; set; }
        public Nullable<System.DateTime> DueDate { get; set; }
        public Nullable<System.DateTime> DiscountDate { get; set; }
        public Nullable<System.DateTime> SchedulePaymentDate { get; set; }
        public string InvoiceNumber { get; set; }
        public Nullable<System.DateTime> InvoiceDate { get; set; }
        public string ShipperNumber { get; set; }
        public Nullable<System.DateTime> ConfirmDate { get; set; }
        public Nullable<System.DateTime> PostDate { get; set; }
        public string ExternalReferenceNumber { get; set; }
        public string Voucher { get; set; }
        public string AccountReceivable { get; set; }
        public string BillingAddressName { get; set; }
        public string BillingAddress1 { get; set; }
        public string BillingAddress2 { get; set; }
        public string BillingAddressAlt { get; set; }
        public string BillingAddressCity { get; set; }
        public string BillingAddressZipCode { get; set; }
        public string SalesTax1Name { get; set; }
        public Nullable<decimal> SalesTax1Rate { get; set; }
        public string SalesTaxType1Description { get; set; }
        public string SalesTax2Name { get; set; }
        public Nullable<decimal> SalesTax2Rate { get; set; }
        public string SalesTaxType2Description { get; set; }
        public string SalesTax3Name { get; set; }
        public Nullable<decimal> SalesTax3Rate { get; set; }
        public string SalesTaxType3Description { get; set; }
        public string SalesTax4Name { get; set; }
        public Nullable<decimal> SalesTax4Rate { get; set; }
        public string SalesTaxType4Description { get; set; }
        public Nullable<decimal> ConversionValue { get; set; }
        public Nullable<decimal> DiscountAmount { get; set; }
        public Nullable<decimal> TaxableAmount { get; set; }
        public Nullable<decimal> NonTaxableAmount { get; set; }
        public Nullable<decimal> MiscellaneousAmount { get; set; }
        public Nullable<decimal> SalesTax1Amount { get; set; }
        public Nullable<decimal> SalesTax2Amount { get; set; }
        public Nullable<decimal> SalesTax3Amount { get; set; }
        public Nullable<decimal> SalesTax4Amount { get; set; }
        public Nullable<decimal> FreightCharge { get; set; }
        public Nullable<decimal> TotalAmount { get; set; }
        public Nullable<decimal> ForeignCurrencyDiscountAmount { get; set; }
        public Nullable<decimal> ForeignCurrencyTaxableAmount { get; set; }
        public Nullable<decimal> ForeignCurrencyNonTaxableAmount { get; set; }
        public Nullable<decimal> ForeignCurrencyMiscellaneousAmount { get; set; }
        public Nullable<decimal> ForeignCurrencySalesTax1Amount { get; set; }
        public Nullable<decimal> ForeignCurrencySalesTax2Amount { get; set; }
        public Nullable<decimal> ForeignCurrencySalesTax3Amount { get; set; }
        public Nullable<decimal> ForeignCurrencySalesTax4Amount { get; set; }
        public Nullable<decimal> ForeignCurrencyFreightCharge { get; set; }
        public Nullable<decimal> ForeignCurrencyTotalAmount { get; set; }
        public Nullable<decimal> MiscellaneousAmount1 { get; set; }
        public Nullable<decimal> MiscellaneousAmount2 { get; set; }
        public Nullable<decimal> MiscellaneousAmount3 { get; set; }
        public string Comment { get; set; }
        public byte[] LastAccess { get; set; }
        public Nullable<bool> SalesTaxOnFreight { get; set; }
        public string ShippingNumber { get; set; }
        public Nullable<decimal> TareWeight { get; set; }
        public Nullable<decimal> GrossWeight { get; set; }
        public Nullable<decimal> LoadWeight { get; set; }
    
        public virtual Address Address { get; set; }
        public virtual ICollection<BusinessProcessResult> BusinessProcessResults { get; set; }
        public virtual CurrencyCode CurrencyCode { get; set; }
        public virtual Division Division { get; set; }
        public virtual ICollection<Document> Documents { get; set; }
        public virtual GeneralLedgerAccount GeneralLedgerAccount { get; set; }
        public virtual GeneralLedgerAccount GeneralLedgerAccount1 { get; set; }
        public virtual GeneralLedgerAccount GeneralLedgerAccount2 { get; set; }
        public virtual ICollection<GeneralLedgerDetail> GeneralLedgerDetails { get; set; }
        public virtual Party Party { get; set; }
        public virtual PurchaseOrderReceivingStatu PurchaseOrderReceivingStatu { get; set; }
        public virtual Term Term { get; set; }
        public virtual ICollection<PurchaseOrderReceivingLine> PurchaseOrderReceivingLines { get; set; }
        public virtual ICollection<QualityControl> QualityControls { get; set; }
        public virtual ICollection<SupplierAging> SupplierAgings { get; set; }
        public virtual ICollection<TaskActivity> TaskActivities { get; set; }
    }
}