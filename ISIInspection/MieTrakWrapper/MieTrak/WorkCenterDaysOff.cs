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
    
    public partial class WorkCenterDaysOff
    {
        public int WorkCenterDaysOffPK { get; set; }
        public Nullable<int> WorkCenterFK { get; set; }
        public Nullable<System.DateTime> Date { get; set; }
        public byte[] LastAccess { get; set; }
    
        public virtual WorkCenter WorkCenter { get; set; }
    }
}