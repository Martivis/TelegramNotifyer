using Microsoft.EntityFrameworkCore;
using Notifyer.Data.Context;
using Notifyer.Data.Context.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notifyer.Data.NewsCathegoryRepository
{
    internal class NewsCathegoryRepository : INewsCathegoryRepository
    {
        private readonly AppDbContext _context;

        public NewsCathegoryRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(NewsCathegory cathegory)
        {
            _context.Add(cathegory);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<NewsCathegory>> GetAllAsync()
        {
            return await _context.Set<NewsCathegory>().ToListAsync();
        }

        public async Task<IEnumerable<NewsCathegory>> GetByUserAsync(int id)
        {
            return await _context.Set<NewsCathegory>()
                .Include(cathegory => cathegory.Subscribers)
                .Where(cathegory => cathegory.Subscribers.Any(sub => sub.ChatId == id))
                .ToListAsync();
        }

        public async Task<NewsCathegory> GetAsync(int id)
        {
            return await _context.FindAsync<NewsCathegory>(id)
                ?? throw new ApplicationException($"Cathegory with id {id} not found");
        }

        public async Task UpdateAsync(NewsCathegory userData)
        {
            _context.Update(userData);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var cathegory = await GetAsync(id);
            _context.Remove(cathegory);
            await _context.SaveChangesAsync();
        }
    }
}
