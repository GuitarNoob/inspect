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
    
    public partial class PartyDivision
    {
        public int PartyDivisionPK { get; set; }
        public Nullable<int> PartyFK { get; set; }
        public Nullable<int> DivisionFK { get; set; }
        public byte[] LastAccess { get; set; }
    
        public virtual Division Division { get; set; }
        public virtual Party Party { get; set; }
    }
}
