using System;
using System.Collections.Generic;
using System.Text;

namespace WillaqTec
{
    public class PersonEntity: BaseEntity
    {
        public int PersonId { get; set; }
        public int IdentityDocumentTypeId { get; set; }
        public string IdentityDocumentNumber { get; set; }
        public string FatherLastName { get; set; }
        public string MotherLastName { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
    }
}
