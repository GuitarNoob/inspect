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
    
    public partial class SecurityGroup
    {
        public SecurityGroup()
        {
            this.SecurityGroupModules = new HashSet<SecurityGroupModule>();
            this.UserDivisions = new HashSet<UserDivision>();
        }
    
        public int SecurityGroupPK { get; set; }
        public string Name { get; set; }
        public Nullable<bool> Enabled { get; set; }
        public byte[] LastAccess { get; set; }
    
        public virtual ICollection<SecurityGroupModule> SecurityGroupModules { get; set; }
        public virtual ICollection<UserDivision> UserDivisions { get; set; }
    }
}
