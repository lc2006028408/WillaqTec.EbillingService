using System;

namespace WillaqTec
{
    public class BaseEntity
    {
        public string CreatorUser { get; set; }
        public string UpdaterUser { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public bool Status { get; set; }
        public bool Removed { get; set; }
    }
}
