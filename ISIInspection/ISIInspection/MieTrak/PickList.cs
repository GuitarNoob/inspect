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
    
    public partial class PickList
    {
        public PickList()
        {
            this.ManifestLoadDetails = new HashSet<ManifestLoadDetail>();
            this.PickListItems = new HashSet<PickListItem>();
        }
    
        public int PickListPK { get; set; }
        public int PickListGroupFK { get; set; }
        public Nullable<int> EmployeeFK { get; set; }
        public Nullable<int> SalesOrderFK { get; set; }
        public Nullable<int> WorkOrderFK { get; set; }
        public Nullable<int> CustomerFK { get; set; }
        public Nullable<int> AddressFK { get; set; }
        public Nullable<int> PickListNumber { get; set; }
        public Nullable<int> LineReferenceNumber { get; set; }
        public decimal TotalWeight { get; set; }
        public string Description { get; set; }
        public string Notes { get; set; }
        public Nullable<System.DateTime> CompletedDate { get; set; }
        public Nullable<System.DateTime> CreateDate { get; set; }
        public Nullable<System.DateTime> ReleasedToShippingDate { get; set; }
        public Nullable<System.DateTime> StagedDate { get; set; }
        public Nullable<System.DateTime> PostedDate { get; set; }
        public Nullable<System.DateTime> InTransitDate { get; set; }
        public Nullable<System.DateTime> ConsignmentDate { get; set; }
        public Nullable<System.DateTime> DeliveryDate { get; set; }
        public string DeliveryTime { get; set; }
        public string ContactName { get; set; }
        public string ContactPhone { get; set; }
        public string Material { get; set; }
        public byte[] LastAccess { get; set; }
        public Nullable<int> PickListStatus { get; set; }
    
        public virtual Address Address { get; set; }
        public virtual ICollection<ManifestLoadDetail> ManifestLoadDetails { get; set; }
        public virtual Party Party { get; set; }
        public virtual PickListGroup PickListGroup { get; set; }
        public virtual SalesOrder SalesOrder { get; set; }
        public virtual User User { get; set; }
        public virtual WorkOrder WorkOrder { get; set; }
        public virtual ICollection<PickListItem> PickListItems { get; set; }
    }
}
