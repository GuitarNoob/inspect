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
    
    public partial class HREducation
    {
        public int HREducationPK { get; set; }
        public Nullable<int> DegreeFK { get; set; }
        public Nullable<int> SchoolTypeFK { get; set; }
        public Nullable<int> UserFK { get; set; }
        public string SchoolName { get; set; }
        public Nullable<System.DateTime> GraduationDate { get; set; }
        public Nullable<System.DateTime> FromDate { get; set; }
        public Nullable<System.DateTime> ToDate { get; set; }
        public byte[] LastAccess { get; set; }
    
        public virtual User User { get; set; }
        public virtual UserCodeItem UserCodeItem { get; set; }
        public virtual UserCodeItem UserCodeItem1 { get; set; }
    }
}