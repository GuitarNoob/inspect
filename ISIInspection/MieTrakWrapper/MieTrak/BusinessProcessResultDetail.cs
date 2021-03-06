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
    
    public partial class BusinessProcessResultDetail
    {
        public int BusinessProcessResultDetailPK { get; set; }
        public Nullable<int> BusinessProcessResultFK { get; set; }
        public Nullable<int> BusinessProcessTemplateDetail { get; set; }
        public Nullable<int> UserFK { get; set; }
        public Nullable<int> UserResultsFK { get; set; }
        public Nullable<int> RatingLow { get; set; }
        public Nullable<int> RatingHigh { get; set; }
        public Nullable<int> RatingResult { get; set; }
        public Nullable<int> Sequence { get; set; }
        public string Description { get; set; }
        public Nullable<bool> RequiredPassFail { get; set; }
        public Nullable<bool> RequiredPassFailResult { get; set; }
        public Nullable<bool> RequiredDate { get; set; }
        public Nullable<System.DateTime> CompletedDate { get; set; }
        public Nullable<System.DateTime> RequiredDateResult { get; set; }
        public Nullable<bool> RequiredSignoff { get; set; }
        public Nullable<bool> RequiredSignoffResult { get; set; }
        public Nullable<bool> TollerancePlusRequired { get; set; }
        public Nullable<decimal> TollerancePlusRequiredResult { get; set; }
        public Nullable<bool> TolleranceMinusRequired { get; set; }
        public Nullable<decimal> TolleranceMinusRequiredResult { get; set; }
        public Nullable<bool> XAxisRequired { get; set; }
        public Nullable<decimal> XAxisRequiredResult { get; set; }
        public Nullable<bool> XRecordDimensionRequired { get; set; }
        public Nullable<decimal> XRecordDimensionRequiredResult { get; set; }
        public Nullable<bool> YAxisRequired { get; set; }
        public Nullable<decimal> YAxisRequiredResult { get; set; }
        public Nullable<bool> YRecordDimensionRequired { get; set; }
        public Nullable<decimal> YRecordDimensionRequiredResult { get; set; }
        public Nullable<bool> ZAxisRequired { get; set; }
        public Nullable<decimal> ZAxisRequiredResult { get; set; }
        public Nullable<bool> ZRecordDimensionRequired { get; set; }
        public Nullable<decimal> ZRecordDimensionRequiredResult { get; set; }
        public string Notes { get; set; }
        public byte[] LastAccess { get; set; }
        public Nullable<int> DispositionTypeFK { get; set; }
        public Nullable<int> InspectorFK { get; set; }
        public Nullable<int> RejectionTypeFK { get; set; }
        public Nullable<int> WorkCenterFK { get; set; }
        public Nullable<bool> DispositionRequired { get; set; }
        public Nullable<bool> QuantityFailRequired { get; set; }
        public Nullable<decimal> QuantityFailed { get; set; }
        public Nullable<bool> QuantityPassRequired { get; set; }
        public Nullable<decimal> QuantityPassed { get; set; }
        public Nullable<decimal> QuantityInspected { get; set; }
        public Nullable<decimal> QuantityRejected { get; set; }
        public string DefectDescription { get; set; }
    
        public virtual BusinessProcessResult BusinessProcessResult { get; set; }
        public virtual DispositionType DispositionType { get; set; }
        public virtual User User { get; set; }
        public virtual RejectionType RejectionType { get; set; }
        public virtual User User1 { get; set; }
        public virtual User User2 { get; set; }
        public virtual WorkCenter WorkCenter { get; set; }
    }
}
