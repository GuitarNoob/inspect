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
    
    public partial class UnitOfMeasure
    {
        public UnitOfMeasure()
        {
            this.UnitOfMeasureSets = new HashSet<UnitOfMeasureSet>();
            this.UnitOfMeasureSets1 = new HashSet<UnitOfMeasureSet>();
            this.UnitOfMeasureSets2 = new HashSet<UnitOfMeasureSet>();
            this.UnitOfMeasureSets3 = new HashSet<UnitOfMeasureSet>();
            this.UnitOfMeasureSets4 = new HashSet<UnitOfMeasureSet>();
        }
    
        public int UnitOfMeasurePK { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public byte[] LastAccess { get; set; }
    
        public virtual ICollection<UnitOfMeasureSet> UnitOfMeasureSets { get; set; }
        public virtual ICollection<UnitOfMeasureSet> UnitOfMeasureSets1 { get; set; }
        public virtual ICollection<UnitOfMeasureSet> UnitOfMeasureSets2 { get; set; }
        public virtual ICollection<UnitOfMeasureSet> UnitOfMeasureSets3 { get; set; }
        public virtual ICollection<UnitOfMeasureSet> UnitOfMeasureSets4 { get; set; }
    }
}
