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
    
    public partial class Catalog
    {
        public Catalog()
        {
            this.CatalogCategories = new HashSet<CatalogCategory>();
            this.ItemInventoryWorkSheetItems = new HashSet<ItemInventoryWorkSheetItem>();
        }
    
        public int CatalogPK { get; set; }
        public Nullable<int> CatalogTypeFK { get; set; }
        public Nullable<int> OrganizationFK { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Title { get; set; }
        public Nullable<System.DateTime> CreateDate { get; set; }
        public Nullable<System.DateTime> LastUpdateDate { get; set; }
        public Nullable<System.DateTime> EffectiveStartDate { get; set; }
        public Nullable<System.DateTime> EffectiveEndDate { get; set; }
        public string ExternalReferenceNumber { get; set; }
        public Nullable<bool> Viewable { get; set; }
        public byte[] LastAccess { get; set; }
    
        public virtual CatalogType CatalogType { get; set; }
        public virtual Organization Organization { get; set; }
        public virtual ICollection<CatalogCategory> CatalogCategories { get; set; }
        public virtual ICollection<ItemInventoryWorkSheetItem> ItemInventoryWorkSheetItems { get; set; }
    }
}
