using System;
using System.IO.Compression;
using System.Collections.Generic;
using System.Threading.Tasks;
using hrapp.Core.Entities;
using hrapp.Core.Interface;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace hrapp.Infrastructure.Data
{
    public class UserRepository : IUserRepository
    {
        private readonly HrContext _context;
        public UserRepository(HrContext context)
        {
            _context = context;
        }

        public async Task<bool> CreateUser(User user)
        {
            _context.Users.Add(user);
            return await SaveChanges();
        }

        public async Task<User> GetUserByIdAsync(int id)
        {
            return await _context.Users.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<User>> GetUserByNameAsync(string name)
        {
            return await _context.Users.Where(x => x.FirstName.Contains(name) || 
                                        x.LastName.Contains(name)).ToListAsync();
        }

        public async Task<IReadOnlyList<User>> GetUsersAsync()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<bool> UpdateUser(User user)
        {
            _context.Users.Update(user);
            return await SaveChanges();
        }

        async Task<bool> SaveChanges()
        {
            var result = await _context.SaveChangesAsync();
            if (result != 0)
                return true;
            else
                return false;
        }
    }
}