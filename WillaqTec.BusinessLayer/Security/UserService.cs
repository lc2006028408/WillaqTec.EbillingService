using System.Collections.Generic;
using System.Threading.Tasks;

namespace WillaqTec
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        //Basic

        public async Task<int> AddAsync(UserEntity userEntity)
        {
            return await _userRepository.AddAsync(userEntity);
        }

        public async Task<int> UpdateAsync(UserEntity userEntity)
        {
            return await _userRepository.UpdateAsync(userEntity);
        }

        public async Task<UserEntity> GetByIdAsync(int userId)
        {
            return await _userRepository.GetByIdAsync(userId);
        }

        public async Task<List<UserEntity>> GetAllAsync()
        {
            return await _userRepository.GetAllAsync();
        }

        // Advanced


        public async Task<UserEntity> ValidateAsync(string userName, string password)
        {
            return await _userRepository.ValidateAsync(userName, password);
        }
    }
}
