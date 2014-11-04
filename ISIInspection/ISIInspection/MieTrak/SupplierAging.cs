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
    
    public partial class SupplierAging
    {
        public SupplierAging()
        {
            this.BillPaymentApplies = new HashSet<BillPaymentApply>();
            this.BillPaymentApplyCredits = new HashSet<BillPaymentApplyCredit>();
        }
    
        public int SupplierAgingPK { get; set; }
        public Nullable<int> SupplierFK { get; set; }
        public Nullable<int> DivisionFK { get; set; }
        public Nullable<int> PurchaseOrderReceivingFK { get; set; }
        public Nullable<int> TermFK { get; set; }
        public Nullable<int> BillFK { get; set; }
        public Nullable<int> InvoiceFK { get; set; }
        public Nullable<bool> Paid { get; set; }
        public Nullable<bool> Commission { get; set; }
        public Nullable<System.DateTime> PaidDate { get; set; }
        public Nullable<System.DateTime> SchedulePaymentDate { get; set; }
        public string SupplierName { get; set; }
        public string PurchaseOrderNumber { get; set; }
        public Nullable<System.DateTime> DateStamp { get; set; }
        public Nullable<System.DateTime> DiscountDate { get; set; }
        public Nullable<System.DateTime> DueDate { get; set; }
        public Nullable<decimal> GrossAmount { get; set; }
        public Nullable<decimal> NetAmount { get; set; }
        public Nullable<decimal> DiscountAmount { get; set; }
        public Nullable<decimal> AppliedAmount { get; set; }
        public Nullable<decimal> PaidAmount { get; set; }
        public string Comment { get; set; }
        public byte[] LastAccess { get; set; }
        public Nullable<decimal> CurrencyPercent { get; set; }
        public Nullable<decimal> ForeignGrossAmount { get; set; }
    
        public virtual Bill Bill { get; set; }
        public virtual ICollection<BillPaymentApply> BillPaymentApplies { get; set; }
        public virtual ICollection<BillPaymentApplyCredit> BillPaymentApplyCredits { get; set; }
        public virtual Division Division { get; set; }
        public virtual Invoice Invoice { get; set; }
        public virtual Party Party { get; set; }
        public virtual PurchaseOrderReceiving PurchaseOrderReceiving { get; set; }
        public virtual Term Term { get; set; }
    }
}
