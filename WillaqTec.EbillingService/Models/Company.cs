namespace WillaqTec.Models
{
    public class Company
    {
        public int CompanyId { get; set; }
        public int UserId { get; set; }
        public string IdentityDocumentNumber { get; set; }
        public string BusinessName { get; set; }
        public string Address { get; set; }
    }
}
