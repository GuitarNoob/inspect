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
    
    public partial class SalesOrderSalesperson
    {
        public int SalesOrderSalespersonPK { get; set; }
        public Nullable<int> SalesOrderFK { get; set; }
        public Nullable<int> SalesPersonFK { get; set; }
        public Nullable<decimal> CommisionPercentage { get; set; }
        public byte[] LastAccess { get; set; }
    
        public virtual Party Party { get; set; }
        public virtual SalesOrder SalesOrder { get; set; }
    }
}