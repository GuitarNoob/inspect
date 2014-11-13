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
    
    public partial class BudgetAccount
    {
        public int BudgetAccountPK { get; set; }
        public Nullable<int> BudgetFK { get; set; }
        public Nullable<int> GeneralLedgerAccountFK { get; set; }
        public Nullable<int> FiscalCalendarFK { get; set; }
        public Nullable<decimal> Period1Amount { get; set; }
        public Nullable<decimal> Period2Amount { get; set; }
        public Nullable<decimal> Period3Amount { get; set; }
        public Nullable<decimal> Period4Amount { get; set; }
        public Nullable<decimal> Period5Amount { get; set; }
        public Nullable<decimal> Period6Amount { get; set; }
        public Nullable<decimal> Period7Amount { get; set; }
        public Nullable<decimal> Period8Amount { get; set; }
        public Nullable<decimal> Period9Amount { get; set; }
        public Nullable<decimal> Period10Amount { get; set; }
        public Nullable<decimal> Period11Amount { get; set; }
        public Nullable<decimal> Period12Amount { get; set; }
        public Nullable<decimal> Period13Amount { get; set; }
        public Nullable<decimal> Total { get; set; }
        public byte[] LastAccess { get; set; }
    
        public virtual Budget Budget { get; set; }
        public virtual FiscalCalendar FiscalCalendar { get; set; }
        public virtual GeneralLedgerAccount GeneralLedgerAccount { get; set; }
    }
}