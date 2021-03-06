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
    
    public partial class PartyUserNote
    {
        public int PartyUserNotePK { get; set; }
        public Nullable<int> DirectionTypeFK { get; set; }
        public Nullable<int> NotesContactTypeFK { get; set; }
        public Nullable<int> PartyFK { get; set; }
        public Nullable<int> UserFK { get; set; }
        public string Title { get; set; }
        public string Memo { get; set; }
        public Nullable<System.DateTime> CreateDate { get; set; }
        public byte[] LastAccess { get; set; }
        public Nullable<int> CRMNotesCategoryFK { get; set; }
        public Nullable<bool> ShowOnAccountingReport { get; set; }
    
        public virtual CRMNotesCategory CRMNotesCategory { get; set; }
        public virtual DirectionType DirectionType { get; set; }
        public virtual NotesContactType NotesContactType { get; set; }
        public virtual Party Party { get; set; }
        public virtual User User { get; set; }
    }
}
