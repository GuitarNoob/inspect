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
    
    public partial class Report
    {
        public Report()
        {
            this.ReportDivisions = new HashSet<ReportDivision>();
        }
    
        public int ReportPK { get; set; }
        public Nullable<int> ReportTypeFK { get; set; }
        public string Description { get; set; }
        public byte[] ReportContent { get; set; }
        public byte[] LastAccess { get; set; }
        public Nullable<bool> NoCache { get; set; }
        public Nullable<bool> HasSubreport { get; set; }
        public byte[] SubreportContent { get; set; }
    
        public virtual ReportType ReportType { get; set; }
        public virtual ICollection<ReportDivision> ReportDivisions { get; set; }
    }
}
