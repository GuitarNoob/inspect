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
    
    public partial class DivisionParameter
    {
        public DivisionParameter()
        {
            this.Divisions = new HashSet<Division>();
        }
    
        public int DivisionParameterPK { get; set; }
        public Nullable<int> AccountMethodFK { get; set; }
        public Nullable<int> AccountsPayableAccountFK { get; set; }
        public Nullable<int> AccountsReceivableTradeAccountFK { get; set; }
        public Nullable<int> CalendarPeriodFK { get; set; }
        public Nullable<int> CashAccountFK { get; set; }
        public Nullable<int> CommissionAccruedAccountFK { get; set; }
        public Nullable<int> CommissionExpenseAccountFK { get; set; }
        public Nullable<int> DefaultRequestForQuotePriceTypeFK { get; set; }
        public Nullable<int> DepositToAccountFK { get; set; }
        public Nullable<int> FreightAccountFK { get; set; }
        public Nullable<int> FiscalCalendarFK { get; set; }
        public Nullable<int> HardwareAccountFK { get; set; }
        public Nullable<int> HardwareCalculationTypeFK { get; set; }
        public Nullable<int> HardwareUnitOfMeasureSetFK { get; set; }
        public Nullable<int> InvoiceImportExportScriptFK { get; set; }
        public Nullable<int> POReceivingImportExportScriptFK { get; set; }
        public Nullable<int> InvoiceAddressFK { get; set; }
        public Nullable<int> KitCalculationTypeFK { get; set; }
        public Nullable<int> KitComponentsShowTypeFK { get; set; }
        public Nullable<int> KitUnitOfMeasureSetFK { get; set; }
        public Nullable<int> LocationFK { get; set; }
        public Nullable<int> CurrencyCodeFK { get; set; }
        public Nullable<int> MaterialAccountFK { get; set; }
        public Nullable<int> MaterialCalculationTypeFK { get; set; }
        public Nullable<int> MaterialUnitOfMeasureSetFK { get; set; }
        public Nullable<int> MiscellaneousCalculationTypeFK { get; set; }
        public Nullable<int> MiscellaneousUnitOfMeasureSetFK { get; set; }
        public Nullable<int> OutsideProcessingAccountFK { get; set; }
        public Nullable<int> OutsideProcessingCalculationTypeFK { get; set; }
        public Nullable<int> OutsideProcessingUnitOfMeasureSetFK { get; set; }
        public Nullable<int> PayablesAccrualFK { get; set; }
        public Nullable<int> PaymentMethodFK { get; set; }
        public Nullable<int> PurchaseGeneralLedgerAccountFK { get; set; }
        public Nullable<int> PurchaseOrderAddressFK { get; set; }
        public Nullable<int> QuoteDefaultApprovalByFK { get; set; }
        public Nullable<int> RequestForQuoteAddressFK { get; set; }
        public Nullable<int> RetainedEarningsAccountFK { get; set; }
        public Nullable<int> RevenueGeneralLedgerAccountFK { get; set; }
        public Nullable<int> StandardCalculationTypeFK { get; set; }
        public Nullable<int> StandardUnitOfMeasureSetFK { get; set; }
        public Nullable<int> SalesOrderAddressFK { get; set; }
        public Nullable<int> SalesTaxRoundingTypeFK { get; set; }
        public Nullable<int> StandardAccountFK { get; set; }
        public Nullable<int> SalesTax1AccountFK { get; set; }
        public Nullable<int> SalesTax2AccountFK { get; set; }
        public Nullable<int> SalesTax3AccountFK { get; set; }
        public Nullable<int> SalesTax4AccountFK { get; set; }
        public Nullable<int> UndepositedFundsAccountFK { get; set; }
        public Nullable<int> UnappliedCashAccountFK { get; set; }
        public Nullable<int> RunOperationFormulaFK { get; set; }
        public Nullable<int> SetupOperationFormulaFK { get; set; }
        public Nullable<int> BillPaymentDiscountFK { get; set; }
        public Nullable<int> CustomerPaymentDiscountFK { get; set; }
        public Nullable<int> QualityLevelFK { get; set; }
        public Nullable<int> TaxPaidOutSalesTaxFK { get; set; }
        public Nullable<int> DefaultPartySalesTaxFK { get; set; }
        public Nullable<int> CostDecimalDigits { get; set; }
        public Nullable<int> DaysValid { get; set; }
        public Nullable<int> ExpectReleaseDays { get; set; }
        public Nullable<int> ExtendedAmountDecimalDigits { get; set; }
        public Nullable<int> InventoryQuantityDecimalDigits { get; set; }
        public Nullable<int> InvoiceMaximumResultCount { get; set; }
        public Nullable<int> ItemMaximumResultCount { get; set; }
        public Nullable<int> ItemLastSoldWarning { get; set; }
        public Nullable<int> PurchaseOrderMaximumResultCount { get; set; }
        public Nullable<int> PurchaseOrderReceiverMaximumResultCount { get; set; }
        public Nullable<int> PurchaseRFQMaximumResultCount { get; set; }
        public Nullable<int> OnDockDaysHardware { get; set; }
        public Nullable<int> OnDockDaysMaterial { get; set; }
        public Nullable<int> OnDockDaysOutsideProcessing { get; set; }
        public Nullable<int> ProductDays { get; set; }
        public Nullable<int> PurchaseQuantityDecimalDigits { get; set; }
        public Nullable<int> QuantityDecimalDigits { get; set; }
        public Nullable<int> QuickBookRegion { get; set; }
        public Nullable<int> QuickBookVersion { get; set; }
        public Nullable<int> SalesOrderMaximumResultCount { get; set; }
        public Nullable<int> SmtpPort { get; set; }
        public Nullable<int> SellPriceDecimalDigits { get; set; }
        public Nullable<int> WorkOrderMaximumResultCount { get; set; }
        public Nullable<int> MondayStartTimeMinutes { get; set; }
        public Nullable<int> TuesdayStartTimeMinutes { get; set; }
        public Nullable<int> WednesdayStarTimeMinutes { get; set; }
        public Nullable<int> ThursdayStartTimeMinutes { get; set; }
        public Nullable<int> FridayStartTimeMinutes { get; set; }
        public Nullable<int> SaturdayStartTimeMinutes { get; set; }
        public Nullable<int> SundayStartTimeMinutes { get; set; }
        public Nullable<int> MinimumLength { get; set; }
        public Nullable<int> MinimumUppercaseLetters { get; set; }
        public Nullable<int> MinimumLowercaseLetters { get; set; }
        public Nullable<int> MaximumFailedAttempts { get; set; }
        public Nullable<bool> PasswordComplexityRequirement { get; set; }
        public Nullable<bool> AllocationsNormalIssuingExact { get; set; }
        public Nullable<bool> AutoCloseWorkOrderCompletions { get; set; }
        public Nullable<bool> AutoCheckQuoteItem { get; set; }
        public Nullable<bool> BackFill { get; set; }
        public Nullable<bool> ChangePromiseDate { get; set; }
        public Nullable<bool> ChangeExpectedReleaseDate { get; set; }
        public Nullable<bool> CertificationsRequired { get; set; }
        public Nullable<bool> CheckQualityLevel { get; set; }
        public Nullable<bool> CheckTimeClockWithJobClockIn { get; set; }
        public Nullable<bool> CloseOutDeliversOnPartialShips { get; set; }
        public Nullable<bool> Commissionable { get; set; }
        public Nullable<bool> CopyBOMComments { get; set; }
        public Nullable<bool> CopyBOMPrices { get; set; }
        public Nullable<bool> CopyHeaderComments { get; set; }
        public Nullable<bool> CopyOperationComments { get; set; }
        public Nullable<bool> CopyOutsideProcessingPrices { get; set; }
        public Nullable<bool> CopyWorkCenterComments { get; set; }
        public Nullable<bool> CopyQuoteAttachedDocsToRouter { get; set; }
        public Nullable<bool> CostingUseAveEmployeeOHRate { get; set; }
        public Nullable<bool> CostingUseAveEmployeeRate { get; set; }
        public Nullable<bool> DeleteLocationsZeroInventory { get; set; }
        public Nullable<bool> DoNotCreateNewLocationOnPostingPurchaseOrderReceiving { get; set; }
        public Nullable<bool> DoNotShowMarkupsOnIndividualBOMItems { get; set; }
        public Nullable<bool> ExcludeRevision { get; set; }
        public Nullable<bool> ExportToNewFile { get; set; }
        public Nullable<bool> FigureExactUsingPartSize { get; set; }
        public Nullable<bool> FigureRequirementsExact { get; set; }
        public Nullable<bool> ScheduleOnSaturday { get; set; }
        public Nullable<bool> ScheduleOnSunday { get; set; }
        public Nullable<bool> GroupInvoicesByPOs { get; set; }
        public Nullable<bool> IncludeMIEDocs { get; set; }
        public Nullable<bool> InventoryItem { get; set; }
        public Nullable<bool> KeepProductDaysScheduleOnRelease { get; set; }
        public Nullable<bool> KeypadPopupInactive { get; set; }
        public Nullable<bool> MachineAskWithJobClockIn { get; set; }
        public Nullable<bool> MIESolutionsAccounting { get; set; }
        public Nullable<bool> QuoteExpand { get; set; }
        public Nullable<bool> RouterExpand { get; set; }
        public Nullable<bool> RouterShowOperation { get; set; }
        public Nullable<bool> RouterShowBOM { get; set; }
        public Nullable<bool> ScanWOSeqInOrder { get; set; }
        public Nullable<bool> InvoiceSalesTaxOnFreight { get; set; }
        public Nullable<bool> PurchaseOrdersSalesTaxOnFreight { get; set; }
        public Nullable<bool> UseLastCostForRawMaterial { get; set; }
        public Nullable<bool> KioskRequireLocationToBeSelectedOnIssuing { get; set; }
        public Nullable<bool> POAutoCreateLotNumber { get; set; }
        public Nullable<bool> WOAutoCreateLotNumber { get; set; }
        public Nullable<bool> AutoDelete { get; set; }
        public Nullable<bool> ExportInvoicesAndReceiversBasedOnCurrency { get; set; }
        public Nullable<bool> ShowIssueBOMMessage { get; set; }
        public Nullable<bool> BackflushAtWorkOrderCompletions { get; set; }
        public Nullable<bool> MakeFromComponentsUseInventoryConversionUnit { get; set; }
        public Nullable<System.DateTime> OverallLockDate { get; set; }
        public Nullable<System.DateTime> InvoiceLockDate { get; set; }
        public Nullable<System.DateTime> ReceivePaymentLockDate { get; set; }
        public Nullable<System.DateTime> BillPaymentLockDate { get; set; }
        public Nullable<System.DateTime> PurcahseOrderReceivingLockDate { get; set; }
        public Nullable<System.DateTime> InventoryWorkSheetLockDate { get; set; }
        public Nullable<bool> Metric { get; set; }
        public Nullable<bool> NegativeInventory { get; set; }
        public Nullable<bool> OneLineItemPerInvoice { get; set; }
        public Nullable<bool> PartyTaxable { get; set; }
        public Nullable<bool> PurchaseOrderPromiseDateIsBlank { get; set; }
        public Nullable<bool> QuickBooksIntegrationReceiving { get; set; }
        public Nullable<bool> QuickBooksInvoiceExportGeneralLedgerAccount { get; set; }
        public Nullable<bool> QuickBooksInvoicesToBePrinted { get; set; }
        public Nullable<bool> QuickBooksNewItemsAddedAsInventory { get; set; }
        public Nullable<bool> QuoteApprovalRequired { get; set; }
        public Nullable<bool> RestYearlyAccrualAtHireDate { get; set; }
        public Nullable<bool> RestrictInvoiceToSingleSalesOrder { get; set; }
        public Nullable<bool> ReviewDateRequiresToReleaseWorkOrder { get; set; }
        public Nullable<bool> SageInvoiceIntegration { get; set; }
        public Nullable<bool> SagePurchaseOrdersIntegration { get; set; }
        public Nullable<bool> SalesOrderCertificationsRequired { get; set; }
        public Nullable<bool> SelectPartyOnStandardItem { get; set; }
        public Nullable<bool> SetupChargeInclusiveOfMinimum { get; set; }
        public Nullable<bool> ShowAllItemsAcrossDivisions { get; set; }
        public Nullable<bool> ShowLandedCost { get; set; }
        public Nullable<bool> SmtpEnableSSL { get; set; }
        public Nullable<bool> SmtpRequireAuthentication { get; set; }
        public Nullable<bool> UseMarkup { get; set; }
        public Nullable<bool> UseMargin { get; set; }
        public Nullable<bool> UseQuickBookIntegration { get; set; }
        public Nullable<bool> UseAccruedPayableAccount { get; set; }
        public Nullable<bool> UseKioskId { get; set; }
        public Nullable<bool> WorkDayMonday { get; set; }
        public Nullable<bool> WorkDayTuesday { get; set; }
        public Nullable<bool> WorkDayWednesday { get; set; }
        public Nullable<bool> WorkDayThursday { get; set; }
        public Nullable<bool> WorkDayFriday { get; set; }
        public Nullable<bool> WorkDaySaturday { get; set; }
        public Nullable<bool> WorkDaySunday { get; set; }
        public Nullable<bool> ZipCodeIsNotRequired { get; set; }
        public Nullable<bool> StateIsNotRequired { get; set; }
        public Nullable<bool> PriceBillOfMaterialItemsRoundUp { get; set; }
        public Nullable<bool> ShowAllLaborDetail { get; set; }
        public Nullable<bool> ShowAllBillOfMaterialDetail { get; set; }
        public Nullable<bool> UseMostRecentWorkOrder { get; set; }
        public Nullable<bool> UseExactMaterialCalculation { get; set; }
        public Nullable<bool> RequiredGLAccountOnPurchaseOrder { get; set; }
        public Nullable<bool> UseGeneralLedgerAccountTaxPaidOut { get; set; }
        public Nullable<bool> DefaultPullOnStandardItems { get; set; }
        public Nullable<bool> DisableKitExploded { get; set; }
        public Nullable<bool> DoNotExplodeSOOnMRP { get; set; }
        public Nullable<bool> BackflushToRoundupToWholeNumber { get; set; }
        public Nullable<bool> ExplodeSubComponentsOnStandardCostCalculation { get; set; }
        public Nullable<bool> ScanLocationCode { get; set; }
        public Nullable<bool> SeparateSalesOrderLines { get; set; }
        public Nullable<decimal> MondayHours { get; set; }
        public Nullable<decimal> TuesdayHours { get; set; }
        public Nullable<decimal> WednesdayHours { get; set; }
        public Nullable<decimal> ThursdayHours { get; set; }
        public Nullable<decimal> FridayHours { get; set; }
        public Nullable<decimal> SaturdayHours { get; set; }
        public Nullable<decimal> SundayHours { get; set; }
        public Nullable<decimal> ScheduleHoursPerDay { get; set; }
        public Nullable<decimal> HardwareMarkupPercentage { get; set; }
        public Nullable<decimal> KitMarkupPercentage { get; set; }
        public Nullable<decimal> MaterialMarkupPercentage { get; set; }
        public Nullable<decimal> MiscellaneousMarkupPercentage { get; set; }
        public Nullable<decimal> OutsideProcessingMarkupPercentage { get; set; }
        public Nullable<decimal> StandardMarkupPercentage { get; set; }
        public string ItemSearchType { get; set; }
        public string AdvItemSeachType { get; set; }
        public string Delivery { get; set; }
        public string FreightOnBoard { get; set; }
        public string PrepaidOrCollection { get; set; }
        public string SmtpFromEmail { get; set; }
        public string SmtpPassword { get; set; }
        public string SmtpServer { get; set; }
        public string SmtpUserName { get; set; }
        public Nullable<bool> AutoPayCommission { get; set; }
        public Nullable<bool> BackDatingInvoiceInventoryTransactions { get; set; }
        public Nullable<bool> UseDefaultOperationFormulas { get; set; }
        public Nullable<int> FreightOutAccountFK { get; set; }
        public Nullable<bool> DefaultItemTaxable { get; set; }
        public Nullable<bool> DefaultPartyTaxable { get; set; }
        public Nullable<bool> MRPCreateProposedWorkOrders { get; set; }
        public Nullable<bool> MRPCreateProposedPurchaseOrders { get; set; }
        public Nullable<bool> TierLevelDiscounting { get; set; }
        public Nullable<bool> PrintWOMoveTicket { get; set; }
        public Nullable<bool> QuoteUseCommodityPricing { get; set; }
        public Nullable<bool> KioskDisabledTimeClockInAndOut { get; set; }
        public Nullable<bool> KioskDisableTimeClockLunchInAndOut { get; set; }
        public string MetacamExecutableFolder { get; set; }
        public string DXFLocation { get; set; }
        public string PartLocation { get; set; }
        public string GCodeLocation { get; set; }
        public string NestJobLocation { get; set; }
        public string DefaultInvoiceSubjectLine { get; set; }
        public string DefaultPurchaseOrderSubjectLine { get; set; }
        public string DefaultQuoteSubjectLine { get; set; }
        public string DefaultSalesOrderSubjectLine { get; set; }
        public string SSNOrTaxID { get; set; }
        public string ShippingCarrier { get; set; }
        public Nullable<int> PasswordExpirationDays { get; set; }
        public Nullable<bool> AlertWhenClockingOutCompleteWOQty { get; set; }
        public Nullable<bool> AutoShipWOAtFinalSequence { get; set; }
        public Nullable<bool> AutoShipWOSubCompletionsAtFinalSequence { get; set; }
        public Nullable<bool> AllowNegativeBackFlush { get; set; }
        public Nullable<bool> KioskCreateQC { get; set; }
        public Nullable<bool> DoNotGroupProductionOverview { get; set; }
        public Nullable<bool> EngChangeReqReqToEditRouter { get; set; }
        public Nullable<bool> AllowAdminLoginOnKiosk { get; set; }
        public Nullable<bool> PrintLastSequenceMoveTicket { get; set; }
        public Nullable<bool> RequireCommentOnManualInvAdjustment { get; set; }
        public Nullable<bool> KioskNoQuantitiesOnSetup { get; set; }
        public Nullable<bool> KioskShowInspect { get; set; }
        public Nullable<bool> KioskShowLastLogins { get; set; }
        public Nullable<bool> KioskShowMaintenance { get; set; }
        public Nullable<bool> KioskShowMiscellaneous { get; set; }
        public Nullable<bool> KioskShowRun { get; set; }
        public Nullable<bool> KioskShowSetup { get; set; }
        public Nullable<bool> KioskShowStaging { get; set; }
        public Nullable<bool> KioskShowTearDown { get; set; }
        public Nullable<bool> KioskShowTransit { get; set; }
        public Nullable<bool> MetamationIntegration { get; set; }
        public string MetamationIntegrationString { get; set; }
        public Nullable<bool> BackflushAllProducts { get; set; }
        public Nullable<bool> DocumentsShowAll { get; set; }
        public Nullable<bool> ShowBlanketPOWarning { get; set; }
        public Nullable<bool> CreateSOFromNonApprovedRFQ { get; set; }
        public Nullable<bool> CheckSequencesAtShipment { get; set; }
        public Nullable<bool> EnablePONumberSOLOT { get; set; }
        public Nullable<bool> EnableShipDateSOLOT { get; set; }
        public Nullable<bool> ExcludeERFQRevision { get; set; }
        public Nullable<bool> PrintRollOverCheckStubOnBlankPaper { get; set; }
        public Nullable<bool> PrintMoveTicketOnLastSequenceOnly { get; set; }
        public Nullable<bool> CreateLocationOnDropShipment { get; set; }
        public Nullable<bool> RemoveDemandOnSequenceCompletion { get; set; }
        public Nullable<bool> RequireScrapReason { get; set; }
        public Nullable<bool> SetPostDateToShipDate { get; set; }
        public Nullable<bool> DoNotAllowWorkOrderOverCompletion { get; set; }
        public Nullable<bool> DoNotAllowNegativeInventoryOnBackflushed { get; set; }
        public Nullable<bool> AutoBackflush { get; set; }
        public Nullable<bool> InvoicingAutoSelectDefaultLocation { get; set; }
        public Nullable<bool> IncludeSetupTimeInRunTime { get; set; }
        public Nullable<bool> NegativeInventoryShipCompleteQuantity { get; set; }
        public Nullable<bool> DoNotUpdateTheCycleCountDate { get; set; }
        public Nullable<bool> UseFabQtyForEstimatedHrsIfZeroQtyEntered { get; set; }
        public Nullable<bool> DoNotAllowIssuingFromReceivingLocation { get; set; }
        public Nullable<bool> QuickbooksJobCosting { get; set; }
        public string MenuBackground { get; set; }
        public Nullable<int> RFQDueDateDays { get; set; }
        public byte[] LastAccess { get; set; }
        public Nullable<int> DocumentThumbnailScale { get; set; }
        public Nullable<bool> NoToolingCharges { get; set; }
        public Nullable<bool> SetPostDateToInvoiceDate { get; set; }
        public Nullable<int> LaserQuickQuoteFormingOperationFK { get; set; }
        public Nullable<int> InvoicePostingInventoryAccountFK { get; set; }
        public Nullable<int> InvoicePostingCogsAccountFK { get; set; }
        public Nullable<int> BackwardsScheduleGapProduct { get; set; }
        public Nullable<int> BackwardsScheduleGapBillOfMaterial { get; set; }
        public Nullable<bool> AutoExpenseInventoryAtInvoicePosting { get; set; }
        public Nullable<decimal> GeneralOverheadAdminPercentage { get; set; }
        public Nullable<bool> ShowAllGLAccountsForAllDivisions { get; set; }
        public Nullable<bool> SetTimeOnToLastTimeOutOnWorkOrderCollection { get; set; }
        public Nullable<bool> DoNotExplodeProductDays { get; set; }
        public Nullable<bool> ClearCustomerNameOnCreateNewSalesOrder { get; set; }
        public Nullable<bool> IncludeSequenceNumberOnCurrentLocation { get; set; }
    
        public virtual AccountingMethod AccountingMethod { get; set; }
        public virtual Address Address { get; set; }
        public virtual Address Address1 { get; set; }
        public virtual Address Address2 { get; set; }
        public virtual Address Address3 { get; set; }
        public virtual CalculationType CalculationType { get; set; }
        public virtual CalculationType CalculationType1 { get; set; }
        public virtual CalculationType CalculationType2 { get; set; }
        public virtual CalculationType CalculationType3 { get; set; }
        public virtual CalculationType CalculationType4 { get; set; }
        public virtual CalculationType CalculationType5 { get; set; }
        public virtual CalendarPeriod CalendarPeriod { get; set; }
        public virtual CurrencyCode CurrencyCode { get; set; }
        public virtual ICollection<Division> Divisions { get; set; }
        public virtual SalesTax SalesTax { get; set; }
        public virtual FiscalCalendar FiscalCalendar { get; set; }
        public virtual GeneralLedgerAccount GeneralLedgerAccount { get; set; }
        public virtual GeneralLedgerAccount GeneralLedgerAccount1 { get; set; }
        public virtual GeneralLedgerAccount GeneralLedgerAccount2 { get; set; }
        public virtual GeneralLedgerAccount GeneralLedgerAccount3 { get; set; }
        public virtual GeneralLedgerAccount GeneralLedgerAccount4 { get; set; }
        public virtual GeneralLedgerAccount GeneralLedgerAccount5 { get; set; }
        public virtual GeneralLedgerAccount GeneralLedgerAccount6 { get; set; }
        public virtual GeneralLedgerAccount GeneralLedgerAccount7 { get; set; }
        public virtual GeneralLedgerAccount GeneralLedgerAccount8 { get; set; }
        public virtual GeneralLedgerAccount GeneralLedgerAccount9 { get; set; }
        public virtual GeneralLedgerAccount GeneralLedgerAccount10 { get; set; }
        public virtual GeneralLedgerAccount GeneralLedgerAccount11 { get; set; }
        public virtual GeneralLedgerAccount GeneralLedgerAccount12 { get; set; }
        public virtual GeneralLedgerAccount GeneralLedgerAccount13 { get; set; }
        public virtual GeneralLedgerAccount GeneralLedgerAccount14 { get; set; }
        public virtual GeneralLedgerAccount GeneralLedgerAccount15 { get; set; }
        public virtual GeneralLedgerAccount GeneralLedgerAccount16 { get; set; }
        public virtual GeneralLedgerAccount GeneralLedgerAccount17 { get; set; }
        public virtual GeneralLedgerAccount GeneralLedgerAccount18 { get; set; }
        public virtual GeneralLedgerAccount GeneralLedgerAccount19 { get; set; }
        public virtual GeneralLedgerAccount GeneralLedgerAccount20 { get; set; }
        public virtual GeneralLedgerAccount GeneralLedgerAccount21 { get; set; }
        public virtual GeneralLedgerAccount GeneralLedgerAccount22 { get; set; }
        public virtual GeneralLedgerAccount GeneralLedgerAccount23 { get; set; }
        public virtual GeneralLedgerAccount GeneralLedgerAccount24 { get; set; }
        public virtual GeneralLedgerAccount GeneralLedgerAccount25 { get; set; }
        public virtual ImportExportScript ImportExportScript { get; set; }
        public virtual KitComponentsShowType KitComponentsShowType { get; set; }
        public virtual Location Location { get; set; }
        public virtual Operation Operation { get; set; }
        public virtual PaymentMethod PaymentMethod { get; set; }
        public virtual ImportExportScript ImportExportScript1 { get; set; }
        public virtual PriceType PriceType { get; set; }
        public virtual QualityLevel QualityLevel { get; set; }
        public virtual User User { get; set; }
        public virtual OperationFormula OperationFormula { get; set; }
        public virtual SalesTax SalesTax1 { get; set; }
        public virtual SalesTaxRoundingType SalesTaxRoundingType { get; set; }
        public virtual OperationFormula OperationFormula1 { get; set; }
        public virtual UnitOfMeasureSet UnitOfMeasureSet { get; set; }
        public virtual UnitOfMeasureSet UnitOfMeasureSet1 { get; set; }
        public virtual UnitOfMeasureSet UnitOfMeasureSet2 { get; set; }
        public virtual UnitOfMeasureSet UnitOfMeasureSet3 { get; set; }
        public virtual UnitOfMeasureSet UnitOfMeasureSet4 { get; set; }
        public virtual UnitOfMeasureSet UnitOfMeasureSet5 { get; set; }
    }
}
