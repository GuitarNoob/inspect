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
    
    public partial class BulletinMessage
    {
        public int BulletinMessagePK { get; set; }
        public Nullable<int> DepartmentFK { get; set; }
        public Nullable<int> UserFK { get; set; }
        public Nullable<int> ShiftFK { get; set; }
        public string Message { get; set; }
        public Nullable<System.DateTime> PostedDate { get; set; }
        public Nullable<System.DateTime> EndDate { get; set; }
        public byte[] LastAccess { get; set; }
    
        public virtual Department Department { get; set; }
        public virtual Shift Shift { get; set; }
        public virtual User User { get; set; }
    }
}