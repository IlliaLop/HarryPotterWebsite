using BLL.Interfaces;
using DLL.Entities;
using DLL.Interfaces;

namespace BLL.Services
{
    public class UserService : IGenericService<User>
    {
        private readonly IGenericRepository<User?> _userRepository;
        public UserService(IGenericRepository<User?> userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<User?> Get(uint id)
        {
            return await _userRepository.GetUserById(id);
        }

        public async Task<User?> AddUser(User user)
        {
            return await _userRepository.AddUser(user);
        }

        public async Task<int> DeleteUser(User user)
        {
            return await _userRepository.DeleteUser(user);
        }

        public async Task<int> UpdateUser(User userWithNewInformation, uint id)
        {
            return await _userRepository.UpdateUser(userWithNewInformation, id);
        }
    }
}
