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
    
    public partial class ItemMPSForecast
    {
        public int ItemMPSForecastPK { get; set; }
        public Nullable<int> ItemFK { get; set; }
        public Nullable<int> ItemMPSTypeFK { get; set; }
        public Nullable<int> Quantity { get; set; }
        public Nullable<System.DateTime> Date { get; set; }
        public byte[] LastAccess { get; set; }
        public Nullable<System.DateTime> DateTo { get; set; }
        public Nullable<int> PartyFK { get; set; }
    
        public virtual Item Item { get; set; }
        public virtual ItemMPSType ItemMPSType { get; set; }
        public virtual Party Party { get; set; }
    }
}