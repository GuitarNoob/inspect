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
    
    public partial class RouterWorkCenterMachine
    {
        public int RouterWorkCenterMachinePK { get; set; }
        public Nullable<int> RouterWorkCenterFK { get; set; }
        public Nullable<int> MachineFK { get; set; }
        public byte[] LastAccess { get; set; }
    
        public virtual Machine Machine { get; set; }
        public virtual RouterWorkCenter RouterWorkCenter { get; set; }
    }
}
