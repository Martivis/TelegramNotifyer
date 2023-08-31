using Notifyer.Data.Context;
using Notifyer.Data.Context.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notifyer.Services.Subscriptions
{
    internal class SubscriptionsService : ISubscriptionsService
    {
        private readonly AppDbContext _context;

        public SubscriptionsService(AppDbContext context)
        {
            _context = context;
        }

        public async Task SubscribeAsync(long chatId, string cathegoryName)
        {
            var user = _context.Set<UserData>().Find(chatId)
                ?? await RegisterUser(chatId);

            var cathegory = _context.Set<NewsCathegory>().FirstOrDefault(x => x.Name == cathegoryName)
                ?? throw new ApplicationException($"Cathegory {cathegoryName} not found");

            user.SubscribedCathegories.Add(cathegory);
            await _context.SaveChangesAsync();
        }

        public async Task<UserData> RegisterUser(long chatId)
        {
            if (_context.Set<UserData>().Find(chatId) is not null)
                throw new ApplicationException($"User already exists");

            var user = new UserData
            {
                ChatId = chatId,
            };

            _context.Add(user);
            await _context.SaveChangesAsync();
            return user;
        }
    }
}
