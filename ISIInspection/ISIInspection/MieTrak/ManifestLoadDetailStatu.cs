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
    
    public partial class ManifestLoadDetailStatu
    {
        public ManifestLoadDetailStatu()
        {
            this.ManifestLoadDetails = new HashSet<ManifestLoadDetail>();
        }
    
        public int ManifestLoadDetailStatusPK { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public byte[] LastAccess { get; set; }
    
        public virtual ICollection<ManifestLoadDetail> ManifestLoadDetails { get; set; }
    }
}
