using System;
using System.Collections.Generic;
using System.Text;

namespace WillaqTec
{
    public class VoidedDocumentsDetailEntity : BaseEntity
    {
        public int VoidedDocumentsDetailId { get; set; }
        public int VoidedDocumentsId { get; set; }
        public int DocumentId { get; set; }
    }
}
