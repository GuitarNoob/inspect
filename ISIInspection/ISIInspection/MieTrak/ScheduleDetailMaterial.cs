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
    
    public partial class ScheduleDetailMaterial
    {
        public int ScheduleDetailMaterialPK { get; set; }
        public Nullable<int> ScheduleDetailFK { get; set; }
        public Nullable<int> ItemFK { get; set; }
        public Nullable<decimal> StockLength { get; set; }
        public Nullable<decimal> StockWidth { get; set; }
        public Nullable<decimal> QuantityOnHand { get; set; }
        public Nullable<decimal> QuantityRequired { get; set; }
        public Nullable<decimal> RunningQuantityOnHand { get; set; }
        public Nullable<System.DateTime> PurchaseByDate { get; set; }
        public byte[] LastAccess { get; set; }
    
        public virtual Item Item { get; set; }
        public virtual ScheduleDetail ScheduleDetail { get; set; }
    }
}
