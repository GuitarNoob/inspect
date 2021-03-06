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
    
    public partial class ImportElectronicBOMItem
    {
        public int ImportElectronicBOMItemPK { get; set; }
        public Nullable<int> ItemFK { get; set; }
        public Nullable<int> ItemTypeFK { get; set; }
        public Nullable<int> ItemSubstitutionNumber { get; set; }
        public Nullable<int> QuoteNumber { get; set; }
        public Nullable<int> QuoteAssemblyNumber { get; set; }
        public string QuoteAssemblyPartNumber { get; set; }
        public Nullable<decimal> Quantity { get; set; }
        public string ItemNumber { get; set; }
        public string Type { get; set; }
        public string Revision { get; set; }
        public string PartNumber { get; set; }
        public string ParentPartNumber { get; set; }
        public string Description { get; set; }
        public string MoreInfo { get; set; }
        public byte[] LastAccess { get; set; }
        public Nullable<decimal> StockLength { get; set; }
        public Nullable<decimal> StockWidth { get; set; }
        public Nullable<decimal> PartLength { get; set; }
        public Nullable<decimal> PartWidth { get; set; }
    
        public virtual Item Item { get; set; }
        public virtual ItemType ItemType { get; set; }
    }
}
