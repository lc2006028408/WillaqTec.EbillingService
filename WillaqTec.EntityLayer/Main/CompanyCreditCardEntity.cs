namespace WillaqTec
{
    public class CompanyCreditCardEntity: BaseEntity
    {
        public int CompanyCreditCardId { get; set; }
        public int CompanyId { get; set; }
        public string CreditCardNumber { get; set; }
    }
}
