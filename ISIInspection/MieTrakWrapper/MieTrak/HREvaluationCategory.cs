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
    
    public partial class HREvaluationCategory
    {
        public HREvaluationCategory()
        {
            this.HREvaluationScores = new HashSet<HREvaluationScore>();
        }
    
        public int HREvaluationCategoryPK { get; set; }
        public Nullable<int> HREvaluationTypeFK { get; set; }
        public string CategoryName { get; set; }
        public int MaxScore { get; set; }
        public string Description { get; set; }
        public byte[] LastAccess { get; set; }
    
        public virtual HREvaluationType HREvaluationType { get; set; }
        public virtual ICollection<HREvaluationScore> HREvaluationScores { get; set; }
    }
}
