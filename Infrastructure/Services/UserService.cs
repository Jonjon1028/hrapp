using Core.Interface;
using hrapp.Core.Entities;
using hrapp.Core.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repo;

        public UserService(IUserRepository repo)
        {
            _repo = repo;
        }

        public Task<bool> CreateUser(User user)
        {
            return _repo.CreateUser(user);
        }

        public Task<User> GetUserByIdAsync(int id)
        {
            return _repo.GetUserByIdAsync(id);
        }

        public Task<List<User>> GetUserByNameAsync(string name)
        {
            return _repo.GetUserByNameAsync(name);
        }

        public Task<IReadOnlyList<User>> GetUsersAsync()
        {
            return _repo.GetUsersAsync();
        }

        public Task<bool> UpdateUser(User user)
        {
            return _repo.UpdateUser(user);
        }
    }
}
