using System;
using System.Collections.Generic;
using System.Text;

namespace WillaqTec
{
    public class DocumentEntity : BaseEntity
    {
        public int DocumentId { get; set; }
        public int Indicator { get; set; }
        public int DocumentTypeId { get; set; }
        public int CustomerProviderId { get; set; }
        public string Serie { get; set; }
        public int Number { get; set; }
        public string Observation { get; set; }
        public decimal SubTotal { get; set; }
        public decimal Tax { get; set; }
        public decimal Total { get; set; }
        public DateTime IssueDate { get; set; }
        public DateTime PaymentDate { get; set; }
        public DateTime ExpiredDate { get; set; }
        public int CurrentAccountId { get; set; }
        public int BranchOfficeId { get; set; }
        public int MethodPaymentId { get; set; }
        public int UserId { get; set; }
    }
}
