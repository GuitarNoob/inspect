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
    
    public partial class Picture
    {
        public Picture()
        {
            this.Items = new HashSet<Item>();
            this.Items1 = new HashSet<Item>();
            this.Items2 = new HashSet<Item>();
        }
    
        public int PicturePK { get; set; }
        public byte[] Photo { get; set; }
        public byte[] LastAccess { get; set; }
    
        public virtual ICollection<Item> Items { get; set; }
        public virtual ICollection<Item> Items1 { get; set; }
        public virtual ICollection<Item> Items2 { get; set; }
    }
}
