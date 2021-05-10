using System;
using System.Collections.Generic;
using System.Text;

namespace WillaqTec
{
    public class NoteEntity : BaseEntity
    {
        public int NoteId { get; set; }
        public int NoteTypeId { get; set; }
        public int BranchOfficeId { get; set; }
        public int CustomerProviderId { get; set; }
        public DateTime IssueDate { get; set; }
        public int Number { get; set; }
        public string Description { get; set; }
    }
}
