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
    
    public partial class InvoiceSalesperson
    {
        public int InvoiceSalespersonPK { get; set; }
        public int InvoiceFK { get; set; }
        public int SalespersonFK { get; set; }
        public Nullable<decimal> CommissionPercentage { get; set; }
        public Nullable<decimal> CommissionAmount { get; set; }
        public Nullable<decimal> PaidAmount { get; set; }
        public byte[] LastAccess { get; set; }
    
        public virtual Invoice Invoice { get; set; }
        public virtual Party Party { get; set; }
    }
}