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
    
    public partial class CustomerPayment
    {
        public CustomerPayment()
        {
            this.CustomerAgings = new HashSet<CustomerAging>();
            this.CustomerDepositLines = new HashSet<CustomerDepositLine>();
            this.CustomerPayment1 = new HashSet<CustomerPayment>();
            this.CustomerPaymentApplies = new HashSet<CustomerPaymentApply>();
            this.CustomerPaymentApplyCredits = new HashSet<CustomerPaymentApplyCredit>();
            this.Documents = new HashSet<Document>();
            this.GeneralLedgerDetails = new HashSet<GeneralLedgerDetail>();
            this.ReconciliationLines = new HashSet<ReconciliationLine>();
        }
    
        public int CustomerPaymentPK { get; set; }
        public Nullable<int> DivisionFK { get; set; }
        public Nullable<int> CustomerFK { get; set; }
        public Nullable<int> CustomerPaymentTypeFK { get; set; }
        public Nullable<int> PaymentMethodFK { get; set; }
        public Nullable<int> DepositToAccountFK { get; set; }
        public Nullable<int> ReceiveFromAccountFK { get; set; }
        public Nullable<int> CustomerPaymentStatusFK { get; set; }
        public Nullable<int> ParentCustomerPaymentFK { get; set; }
        public Nullable<int> CustomerPaymentNumber { get; set; }
        public Nullable<bool> IsMiscellaneous { get; set; }
        public Nullable<bool> Deposited { get; set; }
        public Nullable<bool> IsWriteOff { get; set; }
        public Nullable<System.DateTime> CreateDate { get; set; }
        public Nullable<System.DateTime> PostDate { get; set; }
        public Nullable<decimal> Amount { get; set; }
        public Nullable<decimal> PaymentAmount { get; set; }
        public Nullable<decimal> AppliedAmount { get; set; }
        public Nullable<decimal> UnresolvedBalance { get; set; }
        public string Name { get; set; }
        public string ReferenceNumber { get; set; }
        public string CardNumber { get; set; }
        public string ExpirationDate { get; set; }
        public string Memo { get; set; }
        public Nullable<bool> IsCleared { get; set; }
        public Nullable<System.DateTime> PaymentDate { get; set; }
        public byte[] LastAccess { get; set; }
    
        public virtual ICollection<CustomerAging> CustomerAgings { get; set; }
        public virtual ICollection<CustomerDepositLine> CustomerDepositLines { get; set; }
        public virtual Party Party { get; set; }
        public virtual ICollection<CustomerPayment> CustomerPayment1 { get; set; }
        public virtual CustomerPayment CustomerPayment2 { get; set; }
        public virtual CustomerPaymentStatu CustomerPaymentStatu { get; set; }
        public virtual CustomerPaymentType CustomerPaymentType { get; set; }
        public virtual Division Division { get; set; }
        public virtual GeneralLedgerAccount GeneralLedgerAccount { get; set; }
        public virtual GeneralLedgerAccount GeneralLedgerAccount1 { get; set; }
        public virtual PaymentMethod PaymentMethod { get; set; }
        public virtual ICollection<CustomerPaymentApply> CustomerPaymentApplies { get; set; }
        public virtual ICollection<CustomerPaymentApplyCredit> CustomerPaymentApplyCredits { get; set; }
        public virtual ICollection<Document> Documents { get; set; }
        public virtual ICollection<GeneralLedgerDetail> GeneralLedgerDetails { get; set; }
        public virtual ICollection<ReconciliationLine> ReconciliationLines { get; set; }
    }
}
