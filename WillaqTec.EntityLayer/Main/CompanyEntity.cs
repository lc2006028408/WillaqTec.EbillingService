using System;
using System.Collections.Generic;
using System.Text;

namespace WillaqTec
{
    public class CompanyEntity : BaseEntity
    {
        public int CompanyId { get; set; }
        public int UserId { get; set; }
        public string IdentityDocumentNumber { get; set; }
        public string BusinessName { get; set; }
        public string Address { get; set; }

    }
}
