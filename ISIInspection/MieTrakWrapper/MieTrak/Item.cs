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
    
    public partial class Item
    {
        public Item()
        {
            this.BillLines = new HashSet<BillLine>();
            this.BusinessProcessResults = new HashSet<BusinessProcessResult>();
            this.Documents = new HashSet<Document>();
            this.ElectronicRequestForQuoteLines = new HashSet<ElectronicRequestForQuoteLine>();
            this.ElectronicSalesOrderLines = new HashSet<ElectronicSalesOrderLine>();
            this.EngineeringChangeRequests = new HashSet<EngineeringChangeRequest>();
            this.EngineeringChangeRequestParts = new HashSet<EngineeringChangeRequestPart>();
            this.ImportElectronicBOMItems = new HashSet<ImportElectronicBOMItem>();
            this.InvoiceLines = new HashSet<InvoiceLine>();
            this.ItemCatalogCategories = new HashSet<ItemCatalogCategory>();
            this.ItemDivisions = new HashSet<ItemDivision>();
            this.ItemInventoryLocations = new HashSet<ItemInventoryLocation>();
            this.ItemInventoryTransactions = new HashSet<ItemInventoryTransaction>();
            this.ItemInventoryWorkInProcessTransactions = new HashSet<ItemInventoryWorkInProcessTransaction>();
            this.ItemInventoryWorkSheetItems = new HashSet<ItemInventoryWorkSheetItem>();
            this.ItemKits = new HashSet<ItemKit>();
            this.ItemKits1 = new HashSet<ItemKit>();
            this.ItemMachines = new HashSet<ItemMachine>();
            this.ItemMasterProductionSchedules = new HashSet<ItemMasterProductionSchedule>();
            this.ItemMPSForecasts = new HashSet<ItemMPSForecast>();
            this.ItemSerialNumbers = new HashSet<ItemSerialNumber>();
            this.ItemSubstitutions = new HashSet<ItemSubstitution>();
            this.ItemSubstitutions1 = new HashSet<ItemSubstitution>();
            this.ItemUsageReadings = new HashSet<ItemUsageReading>();
            this.ItemVendors = new HashSet<ItemVendor>();
            this.Kits = new HashSet<Kit>();
            this.Kits1 = new HashSet<Kit>();
            this.Kits2 = new HashSet<Kit>();
            this.MachineMaintenanceRequiredItems = new HashSet<MachineMaintenanceRequiredItem>();
            this.ManifestLines = new HashSet<ManifestLine>();
            this.MRPDetails = new HashSet<MRPDetail>();
            this.PickListItems = new HashSet<PickListItem>();
            this.PurchaseOrderLines = new HashSet<PurchaseOrderLine>();
            this.PurchaseOrderLineRequirements = new HashSet<PurchaseOrderLineRequirement>();
            this.PurchaseOrderReceivingLines = new HashSet<PurchaseOrderReceivingLine>();
            this.PurchaseOrderReceivingLineRequirements = new HashSet<PurchaseOrderReceivingLineRequirement>();
            this.PurchaseOrderRequests = new HashSet<PurchaseOrderRequest>();
            this.PurchaseRFQLines = new HashSet<PurchaseRFQLine>();
            this.PurchaseRFQSupplierLines = new HashSet<PurchaseRFQSupplierLine>();
            this.QualityControls = new HashSet<QualityControl>();
            this.Quotes = new HashSet<Quote>();
            this.QuoteAssemblies = new HashSet<QuoteAssembly>();
            this.RequestForQuoteLines = new HashSet<RequestForQuoteLine>();
            this.Routers = new HashSet<Router>();
            this.RouterWorkCenters = new HashSet<RouterWorkCenter>();
            this.SalesOrderExplodedBillOfMaterials = new HashSet<SalesOrderExplodedBillOfMaterial>();
            this.SalesOrderLines = new HashSet<SalesOrderLine>();
            this.SalesOrderLineItemInventoryLocations = new HashSet<SalesOrderLineItemInventoryLocation>();
            this.ScheduleDetailMaterials = new HashSet<ScheduleDetailMaterial>();
            this.SpareParts = new HashSet<SparePart>();
            this.TaskActivities = new HashSet<TaskActivity>();
            this.WorkOrders = new HashSet<WorkOrder>();
            this.WorkOrderAssemblies = new HashSet<WorkOrderAssembly>();
            this.WorkOrderAssemblies1 = new HashSet<WorkOrderAssembly>();
            this.WorkOrderAssemblies2 = new HashSet<WorkOrderAssembly>();
            this.WorkOrderAssemblies3 = new HashSet<WorkOrderAssembly>();
            this.WorkOrderCollections = new HashSet<WorkOrderCollection>();
            this.WorkOrderCompletions = new HashSet<WorkOrderCompletion>();
            this.WorkOrderIssuings = new HashSet<WorkOrderIssuing>();
            this.WorkOrderIssuings1 = new HashSet<WorkOrderIssuing>();
            this.WorkOrderNestJobs = new HashSet<WorkOrderNestJob>();
            this.WorkOrderNestJobs1 = new HashSet<WorkOrderNestJob>();
            this.WorkOrderPrograms = new HashSet<WorkOrderProgram>();
            this.WorkOrderProgramLayoutWorkOrders = new HashSet<WorkOrderProgramLayoutWorkOrder>();
            this.WorkOrderProgramWorkOrders = new HashSet<WorkOrderProgramWorkOrder>();
            this.WorkOrderReleases = new HashSet<WorkOrderRelease>();
            this.WorkOrderReleases1 = new HashSet<WorkOrderRelease>();
            this.WorkOrderReleases2 = new HashSet<WorkOrderRelease>();
            this.WorkOrderReleases3 = new HashSet<WorkOrderRelease>();
        }
    
        public int ItemPK { get; set; }
        public Nullable<int> CalculationTypeFK { get; set; }
        public Nullable<int> CommodityFK { get; set; }
        public Nullable<int> DefaultRequestForQuotePriceTypeFK { get; set; }
        public Nullable<int> GeneralLedgerAccountFK { get; set; }
        public Nullable<int> PurchaseGeneralLedgerAccountFK { get; set; }
        public Nullable<int> ItemClassFK { get; set; }
        public Nullable<int> ItemInventoryFK { get; set; }
        public Nullable<int> ItemNumberFK { get; set; }
        public Nullable<int> ItemPackagingFK { get; set; }
        public Nullable<int> ItemTypeFK { get; set; }
        public Nullable<int> MachineSetupFK { get; set; }
        public Nullable<int> MinimumWeeksSafetyStock { get; set; }
        public Nullable<int> PlannerFK { get; set; }
        public Nullable<int> PartyFK { get; set; }
        public Nullable<int> ReorderPolicyFK { get; set; }
        public Nullable<int> UnitOfMeasureSetFK { get; set; }
        public Nullable<int> LayoutFK { get; set; }
        public Nullable<int> PictureLargeFK { get; set; }
        public Nullable<int> PictureFK { get; set; }
        public Nullable<int> LayoutPartQuantity { get; set; }
        public Nullable<int> ExpectReleaseDays { get; set; }
        public Nullable<int> LeadTime { get; set; }
        public Nullable<int> NumberOfDaysBetweenCycleCounts { get; set; }
        public Nullable<int> Pierces { get; set; }
        public Nullable<int> ProjectedDays { get; set; }
        public Nullable<int> ProductDays { get; set; }
        public Nullable<int> SheetPriority { get; set; }
        public Nullable<int> Tools { get; set; }
        public Nullable<int> TurrentChanges { get; set; }
        public Nullable<bool> AllowNegativeInventory { get; set; }
        public Nullable<bool> Backflush { get; set; }
        public Nullable<bool> Commissionable { get; set; }
        public Nullable<bool> DoNotPrintWithWO { get; set; }
        public Nullable<bool> GrainDirection { get; set; }
        public Nullable<bool> Inventoriable { get; set; }
        public Nullable<bool> IsIntegrateItem { get; set; }
        public Nullable<bool> MakeFromItem { get; set; }
        public Nullable<bool> MakeToStock { get; set; }
        public Nullable<bool> ManufacturedItem { get; set; }
        public Nullable<bool> Metric { get; set; }
        public Nullable<bool> MPSItem { get; set; }
        public Nullable<bool> NewRevisedFlag { get; set; }
        public Nullable<bool> NonNestable { get; set; }
        public Nullable<bool> OnHold { get; set; }
        public Nullable<bool> OnDockInspectionRequired { get; set; }
        public Nullable<bool> PopupNotify { get; set; }
        public Nullable<bool> Pull { get; set; }
        public Nullable<bool> Purchase { get; set; }
        public Nullable<bool> PurchaseToJob { get; set; }
        public Nullable<bool> QuoteItem { get; set; }
        public Nullable<bool> SerialNumberTracking { get; set; }
        public Nullable<bool> Taxable { get; set; }
        public Nullable<bool> StockInventory { get; set; }
        public Nullable<bool> NonROHSCompliant { get; set; }
        public Nullable<bool> Remnant { get; set; }
        public Nullable<System.DateTime> CreateDate { get; set; }
        public Nullable<System.DateTime> InactiveDate { get; set; }
        public Nullable<System.DateTime> LastCycleCountDate { get; set; }
        public Nullable<System.DateTime> PriceGoodUntil { get; set; }
        public Nullable<decimal> CommissionOverridePercentage { get; set; }
        public Nullable<decimal> CommodityUnits { get; set; }
        public Nullable<decimal> MaximumQuantityOnHand { get; set; }
        public Nullable<decimal> MinimumQuantityOrder { get; set; }
        public Nullable<decimal> ReorderPoint { get; set; }
        public Nullable<decimal> Weight { get; set; }
        public Nullable<decimal> BuildBufferPercentage { get; set; }
        public Nullable<decimal> CutLength { get; set; }
        public Nullable<decimal> EstimatedAnnualUsage { get; set; }
        public Nullable<decimal> LayoutRunTime { get; set; }
        public Nullable<decimal> LayoutStockLength { get; set; }
        public Nullable<decimal> LayoutStockWidth { get; set; }
        public Nullable<decimal> LayoutUtilizationPercentage { get; set; }
        public Nullable<decimal> OptimumBuildQuantity { get; set; }
        public Nullable<decimal> PartPerContainer { get; set; }
        public Nullable<decimal> PartLength { get; set; }
        public Nullable<decimal> PartWidth { get; set; }
        public Nullable<decimal> StockLength { get; set; }
        public Nullable<decimal> StockWidth { get; set; }
        public Nullable<decimal> Thickness { get; set; }
        public Nullable<decimal> Tolerance { get; set; }
        public Nullable<decimal> WeightFactor { get; set; }
        public Nullable<decimal> SquareFootPerPound { get; set; }
        public Nullable<decimal> FixedPrice { get; set; }
        public Nullable<decimal> HistoricGrossWeight { get; set; }
        public Nullable<decimal> MinimumCharge { get; set; }
        public Nullable<decimal> SetupCharge { get; set; }
        public Nullable<decimal> PartArea { get; set; }
        public Nullable<decimal> CutTime { get; set; }
        public Nullable<decimal> BridgeGap { get; set; }
        public Nullable<decimal> VendorUnit { get; set; }
        public Nullable<decimal> VendorUnitInventoryConversion { get; set; }
        public string DrawingRevision { get; set; }
        public string Revision { get; set; }
        public string ItemField { get; set; }
        public string Color { get; set; }
        public string ExternalReferenceID { get; set; }
        public string ProgramNumber { get; set; }
        public string CadReferenceID { get; set; }
        public string SerialNumber { get; set; }
        public string BuyerIDNumber { get; set; }
        public string DrawingNumber { get; set; }
        public string PartNumber { get; set; }
        public string VendorPartNumber { get; set; }
        public string ProductCode { get; set; }
        public string UPCComsumerPackagingCode { get; set; }
        public string Description { get; set; }
        public string CadFile { get; set; }
        public string OtherDescription { get; set; }
        public string LayoutFilename { get; set; }
        public string CadSpecifications { get; set; }
        public string Comment { get; set; }
        public string ShippingNotes { get; set; }
        public string PopupComment { get; set; }
        public Nullable<System.DateTime> UserDefinedDate1 { get; set; }
        public Nullable<System.DateTime> UserDefinedDate2 { get; set; }
        public Nullable<System.DateTime> UserDefinedDate3 { get; set; }
        public Nullable<System.DateTime> UserDefinedDate4 { get; set; }
        public string UserDefinedChar1 { get; set; }
        public string UserDefinedChar2 { get; set; }
        public string UserDefinedChar3 { get; set; }
        public string UserDefinedChar4 { get; set; }
        public Nullable<decimal> UserDefinedDecimal1 { get; set; }
        public Nullable<decimal> UserDefinedDecimal2 { get; set; }
        public Nullable<decimal> UserDefinedDecimal3 { get; set; }
        public Nullable<decimal> UserDefinedDecimal4 { get; set; }
        public Nullable<decimal> CommodityCost { get; set; }
        public Nullable<decimal> CommodityPercentage { get; set; }
        public Nullable<decimal> CommodityPrice { get; set; }
        public Nullable<decimal> Quantity1 { get; set; }
        public Nullable<decimal> Price1 { get; set; }
        public Nullable<decimal> MarkupPercentage1 { get; set; }
        public Nullable<decimal> SellPrice1 { get; set; }
        public Nullable<decimal> MSRP1 { get; set; }
        public Nullable<decimal> Quantity2 { get; set; }
        public Nullable<decimal> Price2 { get; set; }
        public Nullable<decimal> MarkupPercentage2 { get; set; }
        public Nullable<decimal> SellPrice2 { get; set; }
        public Nullable<decimal> MSRP2 { get; set; }
        public Nullable<decimal> Quantity3 { get; set; }
        public Nullable<decimal> Price3 { get; set; }
        public Nullable<decimal> MarkupPercentage3 { get; set; }
        public Nullable<decimal> SellPrice3 { get; set; }
        public Nullable<decimal> MSRP3 { get; set; }
        public Nullable<decimal> Quantity4 { get; set; }
        public Nullable<decimal> Price4 { get; set; }
        public Nullable<decimal> MarkupPercentage4 { get; set; }
        public Nullable<decimal> SellPrice4 { get; set; }
        public Nullable<decimal> MSRP4 { get; set; }
        public Nullable<decimal> Quantity5 { get; set; }
        public Nullable<decimal> Price5 { get; set; }
        public Nullable<decimal> MarkupPercentage5 { get; set; }
        public Nullable<decimal> SellPrice5 { get; set; }
        public Nullable<decimal> MSRP5 { get; set; }
        public Nullable<decimal> Quantity6 { get; set; }
        public Nullable<decimal> Price6 { get; set; }
        public Nullable<decimal> MarkupPercentage6 { get; set; }
        public Nullable<decimal> SellPrice6 { get; set; }
        public Nullable<decimal> MSRP6 { get; set; }
        public Nullable<decimal> Quantity7 { get; set; }
        public Nullable<decimal> Price7 { get; set; }
        public Nullable<decimal> MarkupPercentage7 { get; set; }
        public Nullable<decimal> SellPrice7 { get; set; }
        public Nullable<decimal> MSRP7 { get; set; }
        public Nullable<decimal> Quantity8 { get; set; }
        public Nullable<decimal> Price8 { get; set; }
        public Nullable<decimal> MarkupPercentage8 { get; set; }
        public Nullable<decimal> SellPrice8 { get; set; }
        public Nullable<decimal> MSRP8 { get; set; }
        public byte[] LastAccess { get; set; }
        public string CadFile3d { get; set; }
        public Nullable<int> ItemCycleFK { get; set; }
        public Nullable<int> ProductDaysExploded { get; set; }
        public Nullable<bool> CertificationsRequiredBySupplier { get; set; }
        public string VendorRevision { get; set; }
        public Nullable<int> ItemCycleRank { get; set; }
        public Nullable<bool> ForecastOnMRP { get; set; }
        public Nullable<bool> MPSOnMRP { get; set; }
        public Nullable<bool> NonCommissionable { get; set; }
        public Nullable<bool> UserDefinedBit1 { get; set; }
        public Nullable<bool> UserDefinedBit2 { get; set; }
        public Nullable<bool> UserDefinedBit3 { get; set; }
        public Nullable<bool> UserDefinedBit4 { get; set; }
        public Nullable<int> CurrencyCodeFK { get; set; }
        public Nullable<bool> POAutoCreateLotNumber { get; set; }
        public Nullable<bool> WOAutoCreateLotNumber { get; set; }
        public Nullable<bool> QCHoldPPAP { get; set; }
        public Nullable<decimal> Kerf { get; set; }
        public Nullable<decimal> IssuingUnitOfMeasureValue { get; set; }
        public Nullable<System.DateTime> UserDefinedDate5 { get; set; }
        public Nullable<System.DateTime> UserDefinedDate6 { get; set; }
        public string UserDefinedChar5 { get; set; }
        public string UserDefinedChar6 { get; set; }
        public Nullable<decimal> UserDefinedDecimal5 { get; set; }
        public Nullable<decimal> UserDefinedDecimal6 { get; set; }
        public string PriceComment1 { get; set; }
        public string PriceComment2 { get; set; }
        public string PriceComment3 { get; set; }
        public string PriceComment4 { get; set; }
        public string PriceComment5 { get; set; }
        public string PriceComment6 { get; set; }
        public string PriceComment7 { get; set; }
        public string PriceComment8 { get; set; }
        public Nullable<decimal> DemandPercentageOverride { get; set; }
    
        public virtual ICollection<BillLine> BillLines { get; set; }
        public virtual ICollection<BusinessProcessResult> BusinessProcessResults { get; set; }
        public virtual CalculationType CalculationType { get; set; }
        public virtual Commodity Commodity { get; set; }
        public virtual CurrencyCode CurrencyCode { get; set; }
        public virtual ICollection<Document> Documents { get; set; }
        public virtual ICollection<ElectronicRequestForQuoteLine> ElectronicRequestForQuoteLines { get; set; }
        public virtual ICollection<ElectronicSalesOrderLine> ElectronicSalesOrderLines { get; set; }
        public virtual ICollection<EngineeringChangeRequest> EngineeringChangeRequests { get; set; }
        public virtual ICollection<EngineeringChangeRequestPart> EngineeringChangeRequestParts { get; set; }
        public virtual GeneralLedgerAccount GeneralLedgerAccount { get; set; }
        public virtual GeneralLedgerAccount GeneralLedgerAccount1 { get; set; }
        public virtual ICollection<ImportElectronicBOMItem> ImportElectronicBOMItems { get; set; }
        public virtual ICollection<InvoiceLine> InvoiceLines { get; set; }
        public virtual PriceType PriceType { get; set; }
        public virtual ItemClass ItemClass { get; set; }
        public virtual ItemCycle ItemCycle { get; set; }
        public virtual ItemInventory ItemInventory { get; set; }
        public virtual ItemNumber ItemNumber { get; set; }
        public virtual ItemPackaging ItemPackaging { get; set; }
        public virtual ItemType ItemType { get; set; }
        public virtual Picture Picture { get; set; }
        public virtual MachineSetup MachineSetup { get; set; }
        public virtual Party Party { get; set; }
        public virtual Picture Picture1 { get; set; }
        public virtual Picture Picture2 { get; set; }
        public virtual User User { get; set; }
        public virtual ReorderPolicy ReorderPolicy { get; set; }
        public virtual UnitOfMeasureSet UnitOfMeasureSet { get; set; }
        public virtual ICollection<ItemCatalogCategory> ItemCatalogCategories { get; set; }
        public virtual ICollection<ItemDivision> ItemDivisions { get; set; }
        public virtual ICollection<ItemInventoryLocation> ItemInventoryLocations { get; set; }
        public virtual ICollection<ItemInventoryTransaction> ItemInventoryTransactions { get; set; }
        public virtual ICollection<ItemInventoryWorkInProcessTransaction> ItemInventoryWorkInProcessTransactions { get; set; }
        public virtual ICollection<ItemInventoryWorkSheetItem> ItemInventoryWorkSheetItems { get; set; }
        public virtual ICollection<ItemKit> ItemKits { get; set; }
        public virtual ICollection<ItemKit> ItemKits1 { get; set; }
        public virtual ICollection<ItemMachine> ItemMachines { get; set; }
        public virtual ICollection<ItemMasterProductionSchedule> ItemMasterProductionSchedules { get; set; }
        public virtual ICollection<ItemMPSForecast> ItemMPSForecasts { get; set; }
        public virtual ICollection<ItemSerialNumber> ItemSerialNumbers { get; set; }
        public virtual ICollection<ItemSubstitution> ItemSubstitutions { get; set; }
        public virtual ICollection<ItemSubstitution> ItemSubstitutions1 { get; set; }
        public virtual ICollection<ItemUsageReading> ItemUsageReadings { get; set; }
        public virtual ICollection<ItemVendor> ItemVendors { get; set; }
        public virtual ICollection<Kit> Kits { get; set; }
        public virtual ICollection<Kit> Kits1 { get; set; }
        public virtual ICollection<Kit> Kits2 { get; set; }
        public virtual ICollection<MachineMaintenanceRequiredItem> MachineMaintenanceRequiredItems { get; set; }
        public virtual ICollection<ManifestLine> ManifestLines { get; set; }
        public virtual ICollection<MRPDetail> MRPDetails { get; set; }
        public virtual ICollection<PickListItem> PickListItems { get; set; }
        public virtual ICollection<PurchaseOrderLine> PurchaseOrderLines { get; set; }
        public virtual ICollection<PurchaseOrderLineRequirement> PurchaseOrderLineRequirements { get; set; }
        public virtual ICollection<PurchaseOrderReceivingLine> PurchaseOrderReceivingLines { get; set; }
        public virtual ICollection<PurchaseOrderReceivingLineRequirement> PurchaseOrderReceivingLineRequirements { get; set; }
        public virtual ICollection<PurchaseOrderRequest> PurchaseOrderRequests { get; set; }
        public virtual ICollection<PurchaseRFQLine> PurchaseRFQLines { get; set; }
        public virtual ICollection<PurchaseRFQSupplierLine> PurchaseRFQSupplierLines { get; set; }
        public virtual ICollection<QualityControl> QualityControls { get; set; }
        public virtual ICollection<Quote> Quotes { get; set; }
        public virtual ICollection<QuoteAssembly> QuoteAssemblies { get; set; }
        public virtual ICollection<RequestForQuoteLine> RequestForQuoteLines { get; set; }
        public virtual ICollection<Router> Routers { get; set; }
        public virtual ICollection<RouterWorkCenter> RouterWorkCenters { get; set; }
        public virtual ICollection<SalesOrderExplodedBillOfMaterial> SalesOrderExplodedBillOfMaterials { get; set; }
        public virtual ICollection<SalesOrderLine> SalesOrderLines { get; set; }
        public virtual ICollection<SalesOrderLineItemInventoryLocation> SalesOrderLineItemInventoryLocations { get; set; }
        public virtual ICollection<ScheduleDetailMaterial> ScheduleDetailMaterials { get; set; }
        public virtual ICollection<SparePart> SpareParts { get; set; }
        public virtual ICollection<TaskActivity> TaskActivities { get; set; }
        public virtual ICollection<WorkOrder> WorkOrders { get; set; }
        public virtual ICollection<WorkOrderAssembly> WorkOrderAssemblies { get; set; }
        public virtual ICollection<WorkOrderAssembly> WorkOrderAssemblies1 { get; set; }
        public virtual ICollection<WorkOrderAssembly> WorkOrderAssemblies2 { get; set; }
        public virtual ICollection<WorkOrderAssembly> WorkOrderAssemblies3 { get; set; }
        public virtual ICollection<WorkOrderCollection> WorkOrderCollections { get; set; }
        public virtual ICollection<WorkOrderCompletion> WorkOrderCompletions { get; set; }
        public virtual ICollection<WorkOrderIssuing> WorkOrderIssuings { get; set; }
        public virtual ICollection<WorkOrderIssuing> WorkOrderIssuings1 { get; set; }
        public virtual ICollection<WorkOrderNestJob> WorkOrderNestJobs { get; set; }
        public virtual ICollection<WorkOrderNestJob> WorkOrderNestJobs1 { get; set; }
        public virtual ICollection<WorkOrderProgram> WorkOrderPrograms { get; set; }
        public virtual ICollection<WorkOrderProgramLayoutWorkOrder> WorkOrderProgramLayoutWorkOrders { get; set; }
        public virtual ICollection<WorkOrderProgramWorkOrder> WorkOrderProgramWorkOrders { get; set; }
        public virtual ICollection<WorkOrderRelease> WorkOrderReleases { get; set; }
        public virtual ICollection<WorkOrderRelease> WorkOrderReleases1 { get; set; }
        public virtual ICollection<WorkOrderRelease> WorkOrderReleases2 { get; set; }
        public virtual ICollection<WorkOrderRelease> WorkOrderReleases3 { get; set; }
    }
}