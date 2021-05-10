using System;
using System.Collections.Generic;
using System.Text;

namespace WillaqTec
{
    public class DocumentDetailEntity : BaseEntity
    {
        public int DocumentDetailId { get; set; }
        public int DocumentId { get; set; }
        public int ProductId { get; set; }
        public string Description { get; set; }
        public string AnotherDescription { get; set; }
        public bool IsEspecific { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
    }
}
