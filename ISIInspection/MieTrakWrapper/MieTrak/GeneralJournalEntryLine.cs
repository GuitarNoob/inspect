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
    
    public partial class GeneralJournalEntryLine
    {
        public GeneralJournalEntryLine()
        {
            this.CustomerAgings = new HashSet<CustomerAging>();
            this.GeneralLedgerDetails = new HashSet<GeneralLedgerDetail>();
            this.ReconciliationLines = new HashSet<ReconciliationLine>();
        }
    
        public int GeneralJournalEntryLinePK { get; set; }
        public Nullable<int> GeneralJournalEntryFK { get; set; }
        public Nullable<int> AccountFK { get; set; }
        public Nullable<int> PartyFK { get; set; }
        public Nullable<int> EmployeeFK { get; set; }
        public Nullable<decimal> DebitAmount { get; set; }
        public Nullable<decimal> CreditAmount { get; set; }
        public string Memo { get; set; }
        public Nullable<bool> Billable { get; set; }
        public Nullable<bool> IsCleared { get; set; }
        public byte[] LastAccess { get; set; }
    
        public virtual ICollection<CustomerAging> CustomerAgings { get; set; }
        public virtual GeneralJournalEntry GeneralJournalEntry { get; set; }
        public virtual GeneralLedgerAccount GeneralLedgerAccount { get; set; }
        public virtual Party Party { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<GeneralLedgerDetail> GeneralLedgerDetails { get; set; }
        public virtual ICollection<ReconciliationLine> ReconciliationLines { get; set; }
    }
}