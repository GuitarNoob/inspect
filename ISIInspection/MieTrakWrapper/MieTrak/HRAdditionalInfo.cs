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
    
    public partial class HRAdditionalInfo
    {
        public int HRAddtionalInfoPK { get; set; }
        public int UserFK { get; set; }
        public int HRAddtionalInfoTypeFK { get; set; }
        public Nullable<bool> CheckBoxValue { get; set; }
        public string ShortTextValue { get; set; }
        public string LongTextValue { get; set; }
        public string MultiplyChoiceValue { get; set; }
        public Nullable<int> IntegerValue { get; set; }
        public Nullable<decimal> DecimalValue { get; set; }
        public Nullable<System.DateTime> DateValue { get; set; }
        public byte[] LastAccess { get; set; }
    
        public virtual HRAdditionalInfoType HRAdditionalInfoType { get; set; }
        public virtual User User { get; set; }
    }
}
