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
    
    public partial class Statement
    {
        public Statement()
        {
            this.StatementDetails = new HashSet<StatementDetail>();
            this.StatementExplosions = new HashSet<StatementExplosion>();
        }
    
        public int StatementPK { get; set; }
        public Nullable<int> StatementTypeFK { get; set; }
        public string Name { get; set; }
        public byte[] LastAccess { get; set; }
    
        public virtual StatementType StatementType { get; set; }
        public virtual ICollection<StatementDetail> StatementDetails { get; set; }
        public virtual ICollection<StatementExplosion> StatementExplosions { get; set; }
    }
}
