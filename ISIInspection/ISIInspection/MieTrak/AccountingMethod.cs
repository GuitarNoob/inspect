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
    
    public partial class AccountingMethod
    {
        public AccountingMethod()
        {
            this.DivisionParameters = new HashSet<DivisionParameter>();
        }
    
        public int AccountingMethodPK { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public byte[] LastAccess { get; set; }
        public Nullable<System.DateTime> LastEditDate { get; set; }
        public Nullable<System.DateTime> CreationDate { get; set; }
    
        public virtual ICollection<DivisionParameter> DivisionParameters { get; set; }
    }
}
