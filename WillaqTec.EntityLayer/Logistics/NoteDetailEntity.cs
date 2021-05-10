using System;
using System.Collections.Generic;
using System.Text;

namespace WillaqTec
{
    public class NoteDetailEntity : BaseEntity
    {
        public int NoteDetailId { get; set; }
        public int NoteId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
    }
}
