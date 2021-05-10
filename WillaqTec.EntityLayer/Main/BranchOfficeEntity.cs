using System;
using System.Collections.Generic;
using System.Text;

namespace WillaqTec
{
    public class BranchOfficeEntity : BaseEntity
    {
        public int BranchOfficeId { get; set; }
        public int CompanyId { get; set; }
        public int DistrictId { get; set; }
        public int PersonId { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Telephone { get; set; }
        public string Cellular { get; set; }
        public int Latitude { get; set; }
        public int Longitude { get; set; }
        public bool IsWareHouse { get; set; }
    }
}
