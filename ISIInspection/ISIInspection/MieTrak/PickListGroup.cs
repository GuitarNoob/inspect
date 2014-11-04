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
    
    public partial class PickListGroup
    {
        public PickListGroup()
        {
            this.PickLists = new HashSet<PickList>();
        }
    
        public int PickListGroupPK { get; set; }
        public Nullable<int> DivisionFK { get; set; }
        public Nullable<int> ProjectFK { get; set; }
        public System.DateTime CreateDate { get; set; }
        public Nullable<System.DateTime> CloseDate { get; set; }
        public Nullable<System.DateTime> DueDate { get; set; }
        public Nullable<int> PickListGroupNumber { get; set; }
        public string Label { get; set; }
        public decimal TotalWeight { get; set; }
        public Nullable<int> PickListGroupStatus { get; set; }
        public string Comment { get; set; }
        public string ProjectID { get; set; }
        public string ProjectName { get; set; }
        public string ProjectDescription { get; set; }
        public byte[] LastAccess { get; set; }
    
        public virtual Division Division { get; set; }
        public virtual ICollection<PickList> PickLists { get; set; }
        public virtual Project Project { get; set; }
    }
}
