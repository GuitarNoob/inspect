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
    
    public partial class TermType
    {
        public TermType()
        {
            this.Terms = new HashSet<Term>();
            this.Terms1 = new HashSet<Term>();
        }
    
        public int TermTypePK { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public byte[] LastAccess { get; set; }
    
        public virtual ICollection<Term> Terms { get; set; }
        public virtual ICollection<Term> Terms1 { get; set; }
    }
}