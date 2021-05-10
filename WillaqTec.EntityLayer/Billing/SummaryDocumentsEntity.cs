using System;
using System.Collections.Generic;
using System.Text;

namespace WillaqTec
{
    public class SummaryDocumentsEntity : BaseEntity
    {
        public int SummaryDocumentsId { get; set; }
        public int Correlative { get; set; }
        public int Number { get; set; }
        public string NumberTicketCDR { get; set; }
        public string FileName { get; set; }
    }
}
