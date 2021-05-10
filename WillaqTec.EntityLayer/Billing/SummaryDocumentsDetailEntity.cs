using System;
using System.Collections.Generic;
using System.Text;

namespace WillaqTec
{
    public class SummaryDocumentsDetailEntity : BaseEntity
    {
        public int SummaryDocumentsDetailId { get; set; }
        public int SummaryDocumentsId { get; set; }
        public int DocumentId { get; set; }
    }
}
