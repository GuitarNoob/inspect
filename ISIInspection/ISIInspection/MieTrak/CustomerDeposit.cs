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
    
    public partial class CustomerDeposit
    {
        public CustomerDeposit()
        {
            this.CustomerDepositLines = new HashSet<CustomerDepositLine>();
            this.GeneralLedgerDetails = new HashSet<GeneralLedgerDetail>();
            this.ReconciliationLines = new HashSet<ReconciliationLine>();
        }
    
        public int CustomerDepositPK { get; set; }
        public Nullable<int> CashBackAccountFK { get; set; }
        public Nullable<int> DepositToAccountFK { get; set; }
        public Nullable<int> CustomerDepositStatusFK { get; set; }
        public Nullable<System.DateTime> CreateDate { get; set; }
        public Nullable<System.DateTime> PostDate { get; set; }
        public Nullable<decimal> DepositAmount { get; set; }
        public Nullable<decimal> CashBackAmount { get; set; }
        public string CashBackMemo { get; set; }
        public string Memo { get; set; }
        public Nullable<bool> IsCleared { get; set; }
        public byte[] LastAccess { get; set; }
    
        public virtual GeneralLedgerAccount GeneralLedgerAccount { get; set; }
        public virtual CustomerDepositStatu CustomerDepositStatu { get; set; }
        public virtual GeneralLedgerAccount GeneralLedgerAccount1 { get; set; }
        public virtual ICollection<CustomerDepositLine> CustomerDepositLines { get; set; }
        public virtual ICollection<GeneralLedgerDetail> GeneralLedgerDetails { get; set; }
        public virtual ICollection<ReconciliationLine> ReconciliationLines { get; set; }
    }
}
