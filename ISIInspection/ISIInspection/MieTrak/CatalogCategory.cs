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
    
    public partial class CatalogCategory
    {
        public CatalogCategory()
        {
            this.ItemCatalogCategories = new HashSet<ItemCatalogCategory>();
            this.ItemInventoryWorkSheetItems = new HashSet<ItemInventoryWorkSheetItem>();
        }
    
        public int CatalogCategoryPK { get; set; }
        public Nullable<int> CatalogFK { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ExternalReferenceNumber { get; set; }
        public byte[] LastAccess { get; set; }
    
        public virtual Catalog Catalog { get; set; }
        public virtual ICollection<ItemCatalogCategory> ItemCatalogCategories { get; set; }
        public virtual ICollection<ItemInventoryWorkSheetItem> ItemInventoryWorkSheetItems { get; set; }
    }
}
