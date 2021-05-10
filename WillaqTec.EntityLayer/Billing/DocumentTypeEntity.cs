using System;
using System.Collections.Generic;
using System.Text;

namespace WillaqTec
{
    public class DocumentTypeEntity : BaseEntity
    {
        public int DocumentTypeId { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
    }
}
