using System;
using System.Collections.Generic;
using System.Text;

namespace WillaqTec
{
    public class ProductEntity :BaseEntity
    {
        public int ProductId { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
    }
}
