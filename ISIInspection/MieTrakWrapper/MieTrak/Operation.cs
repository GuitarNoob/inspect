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
    
    public partial class Operation
    {
        public Operation()
        {
            this.DivisionParameters = new HashSet<DivisionParameter>();
            this.OperationOperationRelations = new HashSet<OperationOperationRelation>();
            this.OperationOperationRelations1 = new HashSet<OperationOperationRelation>();
            this.QuoteAssemblies = new HashSet<QuoteAssembly>();
            this.RouterWorkCenters = new HashSet<RouterWorkCenter>();
            this.WorkCenters = new HashSet<WorkCenter>();
            this.WorkOrderAssemblies = new HashSet<WorkOrderAssembly>();
        }
    
        public int OperationPK { get; set; }
        public Nullable<int> DivisionFK { get; set; }
        public Nullable<int> MachineFK { get; set; }
        public Nullable<int> RunFormulaFK { get; set; }
        public Nullable<int> SetupFormulaFK { get; set; }
        public Nullable<int> WorkCenterFK { get; set; }
        public Nullable<bool> Enabled { get; set; }
        public Nullable<bool> UnattendedOperation { get; set; }
        public Nullable<decimal> UnattendedPercentage { get; set; }
        public string Code { get; set; }
        public string ExternalReferenceNumber { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Nullable<decimal> SetupOperationProfitRate { get; set; }
        public Nullable<decimal> SetupOperationProfitRatePrototype { get; set; }
        public Nullable<decimal> SetupOperationProfitRateProduction { get; set; }
        public Nullable<decimal> SetupOperationProfitRateExpedite { get; set; }
        public Nullable<decimal> SetupOperationOverHeadRate { get; set; }
        public Nullable<int> SetupEmployees { get; set; }
        public Nullable<decimal> SetupEmployeeRate { get; set; }
        public Nullable<decimal> SetupEmployeeRatePrototype { get; set; }
        public Nullable<decimal> SetupEmployeeRateProduction { get; set; }
        public Nullable<decimal> SetupEmployeeRateExpedite { get; set; }
        public Nullable<decimal> SetupEmployeeOverHeadRate { get; set; }
        public Nullable<decimal> SetupMarkupPercentage { get; set; }
        public Nullable<decimal> RunOperationProfitRate { get; set; }
        public Nullable<decimal> RunOperationProfitRatePrototype { get; set; }
        public Nullable<decimal> RunOperationProfitRateProduction { get; set; }
        public Nullable<decimal> RunOperationProfitRateExpedite { get; set; }
        public Nullable<decimal> RunOperationOverHeadRate { get; set; }
        public Nullable<int> RunEmployees { get; set; }
        public Nullable<decimal> RunEmployeeRate { get; set; }
        public Nullable<decimal> RunEmployeeRatePrototype { get; set; }
        public Nullable<decimal> RunEmployeeRateProduction { get; set; }
        public Nullable<decimal> RunEmployeeRateExpedite { get; set; }
        public Nullable<decimal> RunEmployeeOverHeadRate { get; set; }
        public Nullable<decimal> RunMarkupPercentage { get; set; }
        public string Comment { get; set; }
        public byte[] LastAccess { get; set; }
    
        public virtual Division Division { get; set; }
        public virtual ICollection<DivisionParameter> DivisionParameters { get; set; }
        public virtual Machine Machine { get; set; }
        public virtual OperationFormula OperationFormula { get; set; }
        public virtual OperationFormula OperationFormula1 { get; set; }
        public virtual WorkCenter WorkCenter { get; set; }
        public virtual ICollection<OperationOperationRelation> OperationOperationRelations { get; set; }
        public virtual ICollection<OperationOperationRelation> OperationOperationRelations1 { get; set; }
        public virtual ICollection<QuoteAssembly> QuoteAssemblies { get; set; }
        public virtual ICollection<RouterWorkCenter> RouterWorkCenters { get; set; }
        public virtual ICollection<WorkCenter> WorkCenters { get; set; }
        public virtual ICollection<WorkOrderAssembly> WorkOrderAssemblies { get; set; }
    }
}