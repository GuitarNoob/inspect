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
    
    public partial class Organization
    {
        public Organization()
        {
            this.Catalogs = new HashSet<Catalog>();
            this.Divisions = new HashSet<Division>();
            this.Parties = new HashSet<Party>();
            this.Users = new HashSet<User>();
        }
    
        public int OrganizationPK { get; set; }
        public Nullable<int> HomeCurrencyCodeFK { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }
        public string PrimaryContactName { get; set; }
        public string PrimaryContactEmail { get; set; }
        public Nullable<bool> IntegrationEnabled { get; set; }
        public string MieDashboardConnection { get; set; }
        public byte[] LastAccess { get; set; }
    
        public virtual ICollection<Catalog> Catalogs { get; set; }
        public virtual CurrencyCode CurrencyCode { get; set; }
        public virtual ICollection<Division> Divisions { get; set; }
        public virtual ICollection<Party> Parties { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}