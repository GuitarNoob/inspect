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
    
    public partial class DaysOff
    {
        public DaysOff()
        {
            this.DaysOffDivisions = new HashSet<DaysOffDivision>();
        }
    
        public int DaysOffPK { get; set; }
        public string Name { get; set; }
        public System.DateTime Date { get; set; }
        public bool Yearly { get; set; }
        public Nullable<double> CreditHours { get; set; }
        public string Comment { get; set; }
        public byte[] LastAccess { get; set; }
    
        public virtual ICollection<DaysOffDivision> DaysOffDivisions { get; set; }
    }
}