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
    
    public partial class PartyBuyer
    {
        public int PartyBuyerPK { get; set; }
        public Nullable<int> PartyFK { get; set; }
        public Nullable<int> BuyerFK { get; set; }
        public string Description { get; set; }
        public Nullable<bool> DefaultBuyer { get; set; }
        public byte[] LastAccess { get; set; }
        public Nullable<bool> DefaultInvoiceEmail { get; set; }
        public Nullable<bool> DefaultPackingSlipEmail { get; set; }
    
        public virtual Party Party { get; set; }
        public virtual Party Party1 { get; set; }
    }
}