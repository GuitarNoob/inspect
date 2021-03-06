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
    
    public partial class DispositionType
    {
        public DispositionType()
        {
            this.BusinessProcessResultDetails = new HashSet<BusinessProcessResultDetail>();
            this.EngineeringChangeRequestParts = new HashSet<EngineeringChangeRequestPart>();
            this.QualityControls = new HashSet<QualityControl>();
            this.QualityControls1 = new HashSet<QualityControl>();
            this.QualityControls2 = new HashSet<QualityControl>();
        }
    
        public int DispositionTypePK { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public string Notes { get; set; }
        public byte[] LastAccess { get; set; }
    
        public virtual ICollection<BusinessProcessResultDetail> BusinessProcessResultDetails { get; set; }
        public virtual ICollection<EngineeringChangeRequestPart> EngineeringChangeRequestParts { get; set; }
        public virtual ICollection<QualityControl> QualityControls { get; set; }
        public virtual ICollection<QualityControl> QualityControls1 { get; set; }
        public virtual ICollection<QualityControl> QualityControls2 { get; set; }
    }
}
