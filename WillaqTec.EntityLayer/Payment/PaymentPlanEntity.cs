using System;
using System.Collections.Generic;
using System.Text;

namespace WillaqTec
{
    public class PaymentPlanEntity : BaseEntity
    {
        public int PaymentPlanId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Amount { get; set; }
    }
}
