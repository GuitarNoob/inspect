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
    
    public partial class EngineeringChangeRequestType
    {
        public EngineeringChangeRequestType()
        {
            this.EngineeringChangeRequests = new HashSet<EngineeringChangeRequest>();
        }
    
        public int EngineeringChangeRequestTypePK { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public string Notes { get; set; }
        public byte[] LastAccess { get; set; }
    
        public virtual ICollection<EngineeringChangeRequest> EngineeringChangeRequests { get; set; }
    }
}
