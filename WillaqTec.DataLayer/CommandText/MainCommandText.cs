namespace WillaqTec
{
    public class MainCommandText : IMainCommandText
    {
        // IdentityDocumentType

        public string AddIdentityDocumentType => "Usp_Mai_I_Mai_IdentityDocumentType";
        public string UpdateIdentityDocumentType => "Usp_Mai_U_Mai_IdentityDocumentType";
        public string GetIdentityDocumentTypeById => "Usp_Mai_S_Mai_IdentityDocumentType_Get_By_IdentityDocumentTypeId";
        public string GetAllIdentityDocumentType => "Usp_Mai_S_Mai_IdentityDocumentType";

        // Person
        public string AddPerson => "Usp_Mai_I_Mai_Person";
        public string UpdatePerson => "Usp_Mai_U_Mai_Person";
        public string GetPersonById => "Usp_Mai_S_Mai_Person_Get_By_PersonId";
        public string GetAllPerson => "Usp_Mai_S_Mai_Person";

        // Company
        public string AddCompany => "Usp_Mai_I_Mai_Company";
        public string UpdateCompany => "Usp_Mai_U_Mai_Company";
        public string GetCompanyById => "Usp_Mai_S_Mai_Company_Get_By_CompanyId";
        public string GetAllCompany => "Usp_Mai_S_Mai_Company";

        // CompanyCreditCarrd
        public string AddCompanyCreditCard => "Usp_Mai_I_Mai_CompanyCreditCard";
        public string UpdateCompanyCreditCard => "Usp_Mai_U_Mai_CompanyCreditCard";
        public string GetCompanyCreditCardById => "Usp_Mai_S_Mai_CompanyCreditCard_Get_By_CompanyCreditCardId";
        public string GetAllCompanyCreditCard => "Usp_Mai_S_Mai_CompanyCreditCard";
    }
}
