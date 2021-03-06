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
    
    public partial class SalesOrderLine
    {
        public SalesOrderLine()
        {
            this.Kits = new HashSet<Kit>();
            this.MRPDetails = new HashSet<MRPDetail>();
            this.QualityControls = new HashSet<QualityControl>();
            this.SalesOrderLine1 = new HashSet<SalesOrderLine>();
            this.SalesOrderLineItemInventoryLocations = new HashSet<SalesOrderLineItemInventoryLocation>();
            this.SalesOrderLineLots = new HashSet<SalesOrderLineLot>();
            this.TaskJournals = new HashSet<TaskJournal>();
            this.WorkOrderJobs = new HashSet<WorkOrderJob>();
        }
    
        public int SalesOrderLinePK { get; set; }
        public Nullable<int> AlternativeUnitOfMeasureSetFK { get; set; }
        public Nullable<int> CustomerFK { get; set; }
        public Nullable<int> ExplodedFromSOLineFK { get; set; }
        public Nullable<int> GeneralLedgerFK { get; set; }
        public Nullable<int> HardwareCertificationFK { get; set; }
        public Nullable<int> ItemFK { get; set; }
        public Nullable<int> KitComponentsShowTypeFK { get; set; }
        public Nullable<int> MaterialCertificationFK { get; set; }
        public Nullable<int> OutsideProcessingCertificationFK { get; set; }
        public Nullable<int> ParentSalesOrderLineFK { get; set; }
        public Nullable<int> QuoteFK { get; set; }
        public Nullable<int> SalesOrderFK { get; set; }
        public Nullable<int> SalesOrderLineItemTypeFK { get; set; }
        public Nullable<int> SalesOrderLineStatusFK { get; set; }
        public Nullable<int> ShippingAddressFK { get; set; }
        public Nullable<int> UnitOfMeasureSetFK { get; set; }
        public Nullable<int> Expeditor { get; set; }
        public Nullable<int> JobNumber { get; set; }
        public Nullable<int> LineReferenceNumber { get; set; }
        public Nullable<int> Priority { get; set; }
        public Nullable<bool> BlanketOrderFlag { get; set; }
        public Nullable<bool> CertificationOfPerformanceRequired { get; set; }
        public Nullable<bool> CertificationsRequired { get; set; }
        public Nullable<bool> Exploded { get; set; }
        public Nullable<bool> HardwareApprovedSupplierRequired { get; set; }
        public Nullable<bool> LotPrice { get; set; }
        public Nullable<bool> MaterialApprovedSupplierRequired { get; set; }
        public Nullable<bool> NewOrderFlag { get; set; }
        public Nullable<bool> NonCommissionable { get; set; }
        public Nullable<bool> OutsideProcessingApprovedSupplierRequired { get; set; }
        public Nullable<bool> PurchaseOrderReceivedFlag { get; set; }
        public Nullable<bool> RequiresSource { get; set; }
        public Nullable<bool> ReadyToShipFlag { get; set; }
        public Nullable<bool> ShipOnEveryShipmentOneItemFlag { get; set; }
        public Nullable<bool> ShipOnFirstSalesOrderShipmentOnly { get; set; }
        public Nullable<bool> Taxable { get; set; }
        public Nullable<bool> Resale { get; set; }
        public Nullable<bool> TimeAndMaterialJob { get; set; }
        public Nullable<bool> UserDefinedFlag { get; set; }
        public Nullable<System.DateTime> CreateDate { get; set; }
        public Nullable<System.DateTime> CloseDate { get; set; }
        public string CustomerLineNumber { get; set; }
        public string PartNumber { get; set; }
        public string Revision { get; set; }
        public string RMANumber { get; set; }
        public string REMNumber { get; set; }
        public string InternalReferenceNumber { get; set; }
        public Nullable<decimal> CommissionOverridePercentage { get; set; }
        public Nullable<decimal> AlternativeQuantity { get; set; }
        public Nullable<decimal> BlanketQuantityOrdered { get; set; }
        public Nullable<decimal> StockLength { get; set; }
        public Nullable<decimal> StockWidth { get; set; }
        public Nullable<decimal> Thickness { get; set; }
        public Nullable<decimal> VendorUnit { get; set; }
        public Nullable<decimal> Cost { get; set; }
        public Nullable<decimal> MarkupPercentage { get; set; }
        public Nullable<decimal> MSRP { get; set; }
        public Nullable<decimal> AlternativePrice { get; set; }
        public Nullable<decimal> Price { get; set; }
        public Nullable<decimal> ExtendedAmount { get; set; }
        public Nullable<decimal> OpenAmount { get; set; }
        public Nullable<decimal> QuantityOrdered { get; set; }
        public Nullable<decimal> QuantityShipped { get; set; }
        public Nullable<decimal> ReleasedQuantity { get; set; }
        public Nullable<decimal> ShippedAmount { get; set; }
        public string ShippingAddressName { get; set; }
        public string ShippingAddress1 { get; set; }
        public string ShippingAddress2 { get; set; }
        public string ShippingAddressAlt { get; set; }
        public string ShippingAddressCity { get; set; }
        public string ShippingAddressZipCode { get; set; }
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
        public string CertificateOfComplianceDescription { get; set; }
        public Nullable<decimal> RMAQuantityReceived { get; set; }
        public Nullable<System.DateTime> RMAReturnDate { get; set; }
        public Nullable<System.DateTime> RMAReceivedDate { get; set; }
        public string CustomDescription { get; set; }
        public string Notes { get; set; }
        public string ShippingNotes { get; set; }
        public string ManufacturingNotes { get; set; }
        public byte[] LastAccess { get; set; }
        public Nullable<int> ProjectNumber { get; set; }
        public Nullable<decimal> ForeignCurrencyPrice { get; set; }
        public Nullable<decimal> CutWidth { get; set; }
        public Nullable<decimal> CutLength { get; set; }
        public Nullable<bool> FirstArticleRequired { get; set; }
        public Nullable<bool> Fair { get; set; }
        public Nullable<System.DateTime> ConfirmedDate { get; set; }
        public string UserDefinedChar1 { get; set; }
        public string UserDefinedChar2 { get; set; }
        public Nullable<System.DateTime> NextDueDate { get; set; }
    
        public virtual Address Address { get; set; }
        public virtual CertificationType CertificationType { get; set; }
        public virtual CertificationType CertificationType1 { get; set; }
        public virtual CertificationType CertificationType2 { get; set; }
        public virtual GeneralLedgerAccount GeneralLedgerAccount { get; set; }
        public virtual Item Item { get; set; }
        public virtual ICollection<Kit> Kits { get; set; }
        public virtual KitComponentsShowType KitComponentsShowType { get; set; }
        public virtual ICollection<MRPDetail> MRPDetails { get; set; }
        public virtual Party Party { get; set; }
        public virtual ICollection<QualityControl> QualityControls { get; set; }
        public virtual Quote Quote { get; set; }
        public virtual SalesOrder SalesOrder { get; set; }
        public virtual UnitOfMeasureSet UnitOfMeasureSet { get; set; }
        public virtual ICollection<SalesOrderLine> SalesOrderLine1 { get; set; }
        public virtual SalesOrderLine SalesOrderLine2 { get; set; }
        public virtual SalesOrderLineItemType SalesOrderLineItemType { get; set; }
        public virtual SalesOrderStatu SalesOrderStatu { get; set; }
        public virtual UnitOfMeasureSet UnitOfMeasureSet1 { get; set; }
        public virtual ICollection<SalesOrderLineItemInventoryLocation> SalesOrderLineItemInventoryLocations { get; set; }
        public virtual ICollection<SalesOrderLineLot> SalesOrderLineLots { get; set; }
        public virtual ICollection<TaskJournal> TaskJournals { get; set; }
        public virtual ICollection<WorkOrderJob> WorkOrderJobs { get; set; }
    }
}
