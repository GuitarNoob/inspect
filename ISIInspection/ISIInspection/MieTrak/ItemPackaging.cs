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
    
    public partial class ItemPackaging
    {
        public ItemPackaging()
        {
            this.InvoicePackagings = new HashSet<InvoicePackaging>();
            this.Items = new HashSet<Item>();
        }
    
        public int ItemPackagingPK { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Nullable<decimal> Weight { get; set; }
        public Nullable<decimal> Length { get; set; }
        public Nullable<decimal> Width { get; set; }
        public Nullable<decimal> Price { get; set; }
        public string PackageHeadName { get; set; }
        public byte[] LastAccess { get; set; }
    
        public virtual ICollection<InvoicePackaging> InvoicePackagings { get; set; }
        public virtual ICollection<Item> Items { get; set; }
    }
}
