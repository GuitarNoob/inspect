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
    
    public partial class CapacityPlanningItem
    {
        public int CapacityPlanningItemPK { get; set; }
        public Nullable<int> ItemFK { get; set; }
        public Nullable<int> UnitOfMeasureFK { get; set; }
        public string MaterialType { get; set; }
        public string PartNumber { get; set; }
        public string Revision { get; set; }
        public Nullable<int> LeadTime { get; set; }
        public byte[] LastAccess { get; set; }
    }
}
