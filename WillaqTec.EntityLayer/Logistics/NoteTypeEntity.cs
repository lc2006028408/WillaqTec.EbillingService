using System;
using System.Collections.Generic;
using System.Text;

namespace WillaqTec
{
    public class NoteTypeEntity : BaseEntity
    {
        public int NoteTypeId { get; set; }
        public int ActionType { get; set; }
        public string Description { get; set; }
    }
}
