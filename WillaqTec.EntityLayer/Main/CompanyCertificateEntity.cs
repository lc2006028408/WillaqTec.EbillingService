using System;
using System.Collections.Generic;
using System.Text;

namespace WillaqTec
{
    public class CompanyCertificateEntity : BaseEntity
    {
        public int CompanyCertificateId { get; set; }
        public int CompanyId { get; set; }
        public string Value { get; set; }
        public string Password { get; set; }
        public DateTime ExpiredDate { get; set; }
    }
}
