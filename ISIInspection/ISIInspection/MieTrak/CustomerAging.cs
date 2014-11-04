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
    
    public partial class CustomerAging
    {
        public CustomerAging()
        {
            this.CustomerPaymentApplies = new HashSet<CustomerPaymentApply>();
        }
    
        public int CustomerAgingPK { get; set; }
        public Nullable<int> CustomerFK { get; set; }
        public Nullable<int> DivisionFK { get; set; }
        public Nullable<int> InvoiceFK { get; set; }
        public Nullable<int> TermFK { get; set; }
        public Nullable<int> CustomerPaymentFK { get; set; }
        public Nullable<int> GeneralJournalEntryFK { get; set; }
        public Nullable<int> GeneralJournalEntryLineFK { get; set; }
        public Nullable<bool> Paid { get; set; }
        public Nullable<System.DateTime> PaidDate { get; set; }
        public string CustomerName { get; set; }
        public string PurchaseOrderNumber { get; set; }
        public Nullable<System.DateTime> DateStamp { get; set; }
        public Nullable<System.DateTime> DiscountDate { get; set; }
        public Nullable<System.DateTime> DueDate { get; set; }
        public Nullable<System.DateTime> PromiseDate { get; set; }
        public Nullable<System.DateTime> ShipDate { get; set; }
        public Nullable<decimal> GrossAmount { get; set; }
        public Nullable<decimal> NetAmount { get; set; }
        public Nullable<decimal> DiscountAmount { get; set; }
        public Nullable<decimal> AppliedAmount { get; set; }
        public Nullable<decimal> ReceivedAmount { get; set; }
        public string Comment { get; set; }
        public Nullable<bool> SkipOnReport { get; set; }
        public byte[] LastAccess { get; set; }
        public Nullable<decimal> CurrencyPercent { get; set; }
        public Nullable<decimal> ForeignGrossAmount { get; set; }
    
        public virtual Party Party { get; set; }
        public virtual CustomerPayment CustomerPayment { get; set; }
        public virtual Division Division { get; set; }
        public virtual GeneralJournalEntry GeneralJournalEntry { get; set; }
        public virtual GeneralJournalEntryLine GeneralJournalEntryLine { get; set; }
        public virtual Invoice Invoice { get; set; }
        public virtual Term Term { get; set; }
        public virtual ICollection<CustomerPaymentApply> CustomerPaymentApplies { get; set; }
    }
}