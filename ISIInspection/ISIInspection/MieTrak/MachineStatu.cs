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
    
    public partial class MachineStatu
    {
        public MachineStatu()
        {
            this.Machines = new HashSet<Machine>();
        }
    
        public int MachineStatusPK { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public byte[] LastAccess { get; set; }
    
        public virtual ICollection<Machine> Machines { get; set; }
    }
}
