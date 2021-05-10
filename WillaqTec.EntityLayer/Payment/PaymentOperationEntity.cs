using System;
using System.Collections.Generic;
using System.Text;

namespace WillaqTec
{
    public class PaymentOperationEntity : BaseEntity
    {
        public int PaymentOperationId { get; set; }
        public int PaymentId { get; set; }
        public int CompanyCreditCardId { get; set; }

    }
}
