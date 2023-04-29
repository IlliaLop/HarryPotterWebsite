using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IGenericService<T>
    {
        public Task<T?> Get(uint id);
        public Task<T?> AddUser(T user);
        public Task<int> DeleteUser(T user);
        public Task<int> UpdateUser(T userWithNewInformation, uint id);
    }
}
