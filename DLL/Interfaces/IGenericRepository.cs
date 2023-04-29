using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL.Interfaces
{
    public interface IGenericRepository<T>
    {
        Task<T> AddUser(T entity);
        Task<T?> GetUserById(uint id);
        Task<int> UpdateUser(T entity, uint id);
        Task<int> DeleteUser(T entity);
    }
}
