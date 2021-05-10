namespace WillaqTec
{
    public class SecurityCommandText : ISecurityCommandText
    {
        // User

        public string AddUser => "Usp_Sec_I_Sec_User";
        public string UpdateUser => "Usp_Sec_U_Sec_User";
        public string GetUserById => "Usp_Sec_S_Sec_User_Get_By_UserId";
        public string GetAllUser => "Usp_Sec_S_Sec_User";
        public string ValidateUser => "Usp_Sec_S_Sec_User_Validate";

    }
}
