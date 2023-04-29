using DLL.Entities;
using DLL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DLL.Repositories
{
    public class UserRepository : IGenericRepository<User>
    {
        private readonly HarryPotterContext _dataContext;

        public UserRepository(HarryPotterContext databaseConnection)
        {
            _dataContext = databaseConnection;
        }

        public async Task<int> UpdateUser(User userWithNewInformation, uint id)
        {
            var user = await _dataContext.User
                .Include(x => x.UserInfo)
                .FirstOrDefaultAsync(x =>
                    x.Id == id);

            if (user is null) return 1;

            user.Login = userWithNewInformation.Login;
            user.Password = userWithNewInformation.Password;
            user.UserInfo.Email = userWithNewInformation.UserInfo.Email;
            user.UserInfo.Name = userWithNewInformation.UserInfo.Name;

            return await _dataContext.SaveChangesAsync();
        }



        public async Task<User> AddUser(User user)
        {
            await _dataContext.User.AddAsync(user);
            await _dataContext.UserInfo.AddAsync(user.UserInfo);
            await _dataContext.SaveChangesAsync();
            return user;
        }

        public async Task<User?> GetUserById(uint id)
        {
            return await _dataContext.User
                .Include(x => x.UserInfo)
                .FirstOrDefaultAsync(x =>
                    x.Id == id);
        }

        public async Task<int> DeleteUser(User user)
        {
            _dataContext.User.Remove(user);
            _dataContext.UserInfo.Remove(user.UserInfo);
            return await _dataContext.SaveChangesAsync();
        }
    }
}
