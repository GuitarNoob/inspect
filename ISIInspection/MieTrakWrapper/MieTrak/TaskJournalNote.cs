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
    
    public partial class TaskJournalNote
    {
        public TaskJournalNote()
        {
            this.TaskJournalNote1 = new HashSet<TaskJournalNote>();
        }
    
        public int TaskJournalNotePK { get; set; }
        public Nullable<int> TaskJournalContentFK { get; set; }
        public Nullable<int> TaskJournalFK { get; set; }
        public Nullable<int> TaskJournalNoteFK { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Nullable<int> NodeIndex { get; set; }
        public byte[] LastAccess { get; set; }
    
        public virtual TaskJournal TaskJournal { get; set; }
        public virtual TaskJournalContent TaskJournalContent { get; set; }
        public virtual ICollection<TaskJournalNote> TaskJournalNote1 { get; set; }
        public virtual TaskJournalNote TaskJournalNote2 { get; set; }
    }
}