using Notifyer.Data.Context;
using Notifyer.Data.Context.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISubscriptionsService
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
                ?? throw new ApplicationException($"User {chatId} not found");

            var cathegory = _context.Set<NewsCathegory>().FirstOrDefault(x => x.Name == cathegoryName)
                ?? throw new ApplicationException($"Cathegory {cathegoryName} not found");

            user.SubscribedCathegories.Add(cathegory);
            await _context.SaveChangesAsync();
        }
    }
}
