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
    
    public partial class TaskJournalContent
    {
        public TaskJournalContent()
        {
            this.TaskJournals = new HashSet<TaskJournal>();
            this.TaskJournalNotes = new HashSet<TaskJournalNote>();
        }
    
        public int TaskJournalContentPK { get; set; }
        public byte[] JournalContent { get; set; }
        public byte[] LastAccess { get; set; }
    
        public virtual ICollection<TaskJournal> TaskJournals { get; set; }
        public virtual ICollection<TaskJournalNote> TaskJournalNotes { get; set; }
    }
}