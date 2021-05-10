using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace WillaqTec
{
    public interface IUserRepository : IRepository<UserEntity>
    {
        Task<UserEntity> ValidateAsync(string userName, string password);
    }
}
