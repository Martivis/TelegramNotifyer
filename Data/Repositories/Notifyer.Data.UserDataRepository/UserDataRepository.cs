using Microsoft.EntityFrameworkCore;
using Notifyer.Data.Context;
using Notifyer.Data.Context.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notifyer.Data.UserDataRepository
{
    internal class UserDataRepository : IUserDataRepository
    {
        private readonly AppDbContext _context;

        public UserDataRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddUserAsync(UserData userData)
        {
            _context.Add(userData);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteUserAsync(int id)
        {
            var user = await GetUserAsync(id);
            _context.Remove(user);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<UserData>> GetAllUsersAsync()
        {
            return await _context.Set<UserData>().ToListAsync();
        }

        public async Task<UserData> GetUserAsync(int id)
        {
            return await _context.FindAsync<UserData>(id)
                ?? throw new ApplicationException($"User with id {id} not found");
        }

        public async Task UpdateUserAsync(UserData userData)
        {
            _context.Update(userData);
            await _context.SaveChangesAsync();
        }
    }
}
