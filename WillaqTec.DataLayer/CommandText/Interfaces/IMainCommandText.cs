namespace WillaqTec
{
    public interface IMainCommandText
    {
        // IdentityDocumentType

        string AddIdentityDocumentType { get; }
        string UpdateIdentityDocumentType { get; }
        string GetIdentityDocumentTypeById { get; }
        string GetAllIdentityDocumentType { get; }

        // Person

        string AddPerson { get; }
        string UpdatePerson { get; }
        string GetPersonById { get; }
        string GetAllPerson { get; }

        // Company

        string AddCompany { get; }
        string UpdateCompany { get; }
        string GetCompanyById { get; }
        string GetAllCompany { get; }

        // CompanyCreditCard

        string AddCompanyCreditCard { get; }
        string UpdateCompanyCreditCard { get; }
        string GetCompanyCreditCardById { get; }
        string GetAllCompanyCreditCard { get; }

    }
}
