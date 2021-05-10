using System;
using System.Collections.Generic;
using System.Text;

namespace WillaqTec
{
    public class PaymentEntity : BaseEntity
    {
        public int PaymentId { get; set; }
        public int CompanyId { get; set; }
        public int PaymentPlanId { get; set; }
        public DateTime IssueDate { get; set; }
        public DateTime StartingDate { get; set; }
        public DateTime EndingDate { get; set; }
    }
}
