using System.Collections.Generic;
using System.Threading.Tasks;
using hrapp.Core.Entities;

namespace hrapp.Core.Interface
{
    public interface IUserRepository
    {
        Task<IReadOnlyList<User>> GetUsersAsync();
        Task<User> GetUserByIdAsync (int id);
        Task<List<User>> GetUserByNameAsync (string name);
        Task<bool> CreateUser(User user);
        Task<bool> UpdateUser(User user);
    }
}