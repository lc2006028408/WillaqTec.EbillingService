namespace WillaqTec
{
    public interface ISecurityCommandText
    {
        // User

        string AddUser { get; }
        string UpdateUser { get; }
        string GetUserById { get; }
        string GetAllUser { get; }
        string ValidateUser { get; }
    }
}
