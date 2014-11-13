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
    
    public partial class SalesTax
    {
        public SalesTax()
        {
            this.Addresses = new HashSet<Address>();
            this.Addresses1 = new HashSet<Address>();
            this.Addresses2 = new HashSet<Address>();
            this.Addresses3 = new HashSet<Address>();
            this.DivisionParameters = new HashSet<DivisionParameter>();
            this.DivisionParameters1 = new HashSet<DivisionParameter>();
        }
    
        public int SalesTaxPK { get; set; }
        public Nullable<int> GeneralLedgerAccountFK { get; set; }
        public string Name { get; set; }
        public Nullable<decimal> Rate { get; set; }
        public string TaxCodeReference { get; set; }
        public byte[] LastAccess { get; set; }
    
        public virtual ICollection<Address> Addresses { get; set; }
        public virtual ICollection<Address> Addresses1 { get; set; }
        public virtual ICollection<Address> Addresses2 { get; set; }
        public virtual ICollection<Address> Addresses3 { get; set; }
        public virtual ICollection<DivisionParameter> DivisionParameters { get; set; }
        public virtual ICollection<DivisionParameter> DivisionParameters1 { get; set; }
        public virtual GeneralLedgerAccount GeneralLedgerAccount { get; set; }
    }
}