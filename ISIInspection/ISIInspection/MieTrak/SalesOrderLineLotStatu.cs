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
    
    public partial class SalesOrderLineLotStatu
    {
        public SalesOrderLineLotStatu()
        {
            this.SalesOrderLineLots = new HashSet<SalesOrderLineLot>();
        }
    
        public int SalesOrderLineLotStatusPK { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public byte[] LastAccess { get; set; }
    
        public virtual ICollection<SalesOrderLineLot> SalesOrderLineLots { get; set; }
    }
}
