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
    
    public partial class Discount
    {
        public Discount()
        {
            this.DiscountPercentages = new HashSet<DiscountPercentage>();
            this.Parties = new HashSet<Party>();
            this.RequestForQuotes = new HashSet<RequestForQuote>();
            this.SalesOrders = new HashSet<SalesOrder>();
        }
    
        public int DiscountPK { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public Nullable<decimal> DiscountPercentage { get; set; }
        public byte[] LastAccess { get; set; }
        public Nullable<int> CustomerGorupFK { get; set; }
        public Nullable<int> ItemClassFK { get; set; }
        public Nullable<bool> CustomerGroupAndItemClass { get; set; }
    
        public virtual CustomerGroup CustomerGroup { get; set; }
        public virtual ItemClass ItemClass { get; set; }
        public virtual ICollection<DiscountPercentage> DiscountPercentages { get; set; }
        public virtual ICollection<Party> Parties { get; set; }
        public virtual ICollection<RequestForQuote> RequestForQuotes { get; set; }
        public virtual ICollection<SalesOrder> SalesOrders { get; set; }
    }
}
