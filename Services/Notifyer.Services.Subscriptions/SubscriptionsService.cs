using Microsoft.EntityFrameworkCore;
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
        private readonly IDbContextFactory<AppDbContext> _contextFactory;

        public SubscriptionsService(IDbContextFactory<AppDbContext> contextFactury)
        {
            _contextFactory = contextFactury;
        }

        public async Task SubscribeAsync(long chatId, string cathegoryName)
        {
            using var context = _contextFactory.CreateDbContext();

            var user = await context.Set<UserData>()
                .Include(u => u.SubscribedCathegories)
                .FirstOrDefaultAsync(u => u.ChatId == chatId);
            
            if (user == null)
            {
                await RegisterUser(chatId);

                user = await context.Set<UserData>()
                .Include(u => u.SubscribedCathegories)
                .FirstAsync(u => u.ChatId == chatId);
            }

            var cathegory = context.Set<NewsCathegory>().FirstOrDefault(x => x.Name == cathegoryName)
                ?? throw new ApplicationException($"Cathegory {cathegoryName} not found");

            user.SubscribedCathegories.Add(cathegory);
            await context.SaveChangesAsync();
        }

        public async Task RegisterUser(long chatId)
        {
            using var context = _contextFactory.CreateDbContext();

            if (context.Set<UserData>().Find(chatId) is not null)
                throw new ApplicationException($"User already exists");

            var user = new UserData
            {
                ChatId = chatId,
            };

            context.Add(user);
            await context.SaveChangesAsync();
        }
    }
}
