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
    
    public partial class UserStartupWidget
    {
        public int UserStartupWidgetPK { get; set; }
        public Nullable<int> UserFK { get; set; }
        public Nullable<int> StartupWidgetFK { get; set; }
        public string Title { get; set; }
        public Nullable<int> Page { get; set; }
        public Nullable<int> Col { get; set; }
        public Nullable<int> Row { get; set; }
        public string SQLQuery { get; set; }
        public string ParamXML { get; set; }
        public byte[] LastAccess { get; set; }
        public Nullable<int> QuickViewFK { get; set; }
        public Nullable<decimal> Minimum { get; set; }
        public Nullable<decimal> Maximum { get; set; }
    
        public virtual QuickView QuickView { get; set; }
        public virtual StartupWidget StartupWidget { get; set; }
        public virtual User User { get; set; }
    }
}