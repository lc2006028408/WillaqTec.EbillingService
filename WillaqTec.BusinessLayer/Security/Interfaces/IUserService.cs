using System.Threading.Tasks;

namespace WillaqTec
{
    public interface IUserService : IService<UserEntity>
    {
        Task<UserEntity> ValidateAsync(string userName, string password);
    }
}
