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
    
    public partial class WorkCenter
    {
        public WorkCenter()
        {
            this.BusinessProcessResultDetails = new HashSet<BusinessProcessResultDetail>();
            this.EngineeringChangeRequests = new HashSet<EngineeringChangeRequest>();
            this.Machines = new HashSet<Machine>();
            this.Operations = new HashSet<Operation>();
            this.QualityControls = new HashSet<QualityControl>();
            this.QualityControls1 = new HashSet<QualityControl>();
            this.QualityControls2 = new HashSet<QualityControl>();
            this.RouterWorkCenters = new HashSet<RouterWorkCenter>();
            this.WorkCenterDaysOffs = new HashSet<WorkCenterDaysOff>();
            this.WorkCenterEmployees = new HashSet<WorkCenterEmployee>();
            this.WorkOrderAssemblies = new HashSet<WorkOrderAssembly>();
            this.WorkOrderCollections = new HashSet<WorkOrderCollection>();
        }
    
        public int WorkCenterPK { get; set; }
        public Nullable<int> DepartmentFK { get; set; }
        public Nullable<int> DivisionFK { get; set; }
        public Nullable<int> DefaultOperationFK { get; set; }
        public Nullable<int> WorkCenterTypeFK { get; set; }
        public Nullable<int> LagTime { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public Nullable<bool> Active { get; set; }
        public Nullable<bool> DoNotShowOnWhiteboard { get; set; }
        public Nullable<bool> NonProductionAsset { get; set; }
        public Nullable<bool> DefaultLoadingWorkCenter { get; set; }
        public Nullable<bool> Monday { get; set; }
        public Nullable<bool> Tuesday { get; set; }
        public Nullable<bool> Wednesday { get; set; }
        public Nullable<bool> Thursday { get; set; }
        public Nullable<bool> Friday { get; set; }
        public Nullable<bool> Saturday { get; set; }
        public Nullable<bool> Sunday { get; set; }
        public Nullable<bool> NonRouter { get; set; }
        public Nullable<decimal> MondayHours { get; set; }
        public Nullable<decimal> TuesdayHours { get; set; }
        public Nullable<decimal> WednesdayHours { get; set; }
        public Nullable<decimal> ThursdayHours { get; set; }
        public Nullable<decimal> FridayHours { get; set; }
        public Nullable<decimal> SaturdayHours { get; set; }
        public Nullable<decimal> SundayHours { get; set; }
        public Nullable<decimal> CapacityHours { get; set; }
        public Nullable<decimal> WaitTime { get; set; }
        public Nullable<decimal> AverageProductionDays { get; set; }
        public Nullable<decimal> PercentOfProductivity { get; set; }
        public Nullable<decimal> AverageEmployeeRate { get; set; }
        public Nullable<decimal> AverageEmployeeOverheadRate { get; set; }
        public Nullable<decimal> HourlyOverHead { get; set; }
        public Nullable<decimal> HourlyRate { get; set; }
        public Nullable<decimal> ManufactureSupplies { get; set; }
        public Nullable<decimal> MonthlyPayments { get; set; }
        public Nullable<decimal> MonthlyMiscellaneous { get; set; }
        public Nullable<decimal> SetupRate { get; set; }
        public Nullable<decimal> SquareFeetSpace { get; set; }
        public Nullable<decimal> MinutesPerPart { get; set; }
        public Nullable<decimal> SetupTime { get; set; }
        public Nullable<decimal> StagingTime { get; set; }
        public Nullable<decimal> TransitTime { get; set; }
        public Nullable<decimal> TearDownTime { get; set; }
        public string Comment { get; set; }
        public byte[] LastAccess { get; set; }
        public Nullable<bool> WorkOrderNestFlag { get; set; }
    
        public virtual ICollection<BusinessProcessResultDetail> BusinessProcessResultDetails { get; set; }
        public virtual Department Department { get; set; }
        public virtual Division Division { get; set; }
        public virtual ICollection<EngineeringChangeRequest> EngineeringChangeRequests { get; set; }
        public virtual ICollection<Machine> Machines { get; set; }
        public virtual ICollection<Operation> Operations { get; set; }
        public virtual Operation Operation { get; set; }
        public virtual ICollection<QualityControl> QualityControls { get; set; }
        public virtual ICollection<QualityControl> QualityControls1 { get; set; }
        public virtual ICollection<QualityControl> QualityControls2 { get; set; }
        public virtual ICollection<RouterWorkCenter> RouterWorkCenters { get; set; }
        public virtual WorkCenterType WorkCenterType { get; set; }
        public virtual ICollection<WorkCenterDaysOff> WorkCenterDaysOffs { get; set; }
        public virtual ICollection<WorkCenterEmployee> WorkCenterEmployees { get; set; }
        public virtual ICollection<WorkOrderAssembly> WorkOrderAssemblies { get; set; }
        public virtual ICollection<WorkOrderCollection> WorkOrderCollections { get; set; }
    }
}
