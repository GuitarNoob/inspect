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
    
    public partial class StatementDetail
    {
        public StatementDetail()
        {
            this.StatementExplosions = new HashSet<StatementExplosion>();
            this.StatementExplosions1 = new HashSet<StatementExplosion>();
        }
    
        public int StatementDetailPK { get; set; }
        public Nullable<int> StatementFK { get; set; }
        public string Name { get; set; }
        public Nullable<int> Row { get; set; }
        public Nullable<int> ColumnPlace { get; set; }
        public byte[] LastAccess { get; set; }
        public Nullable<bool> Bold { get; set; }
        public Nullable<bool> Underline { get; set; }
        public Nullable<bool> ReverseAmount { get; set; }
        public Nullable<bool> Contain100PercentageValue { get; set; }
        public Nullable<bool> PageBreak { get; set; }
    
        public virtual Statement Statement { get; set; }
        public virtual ICollection<StatementExplosion> StatementExplosions { get; set; }
        public virtual ICollection<StatementExplosion> StatementExplosions1 { get; set; }
    }
}