using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Notifyer.Data.Context.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notifyer.Data.Context
{
    public static class AddDbSeeder
    {
        public static void Seed(IServiceProvider serviceProvider)
        {
            using var scope = serviceProvider.GetService<IServiceScopeFactory>()!.CreateScope();
            var contextFactory = scope.ServiceProvider.GetRequiredService<IDbContextFactory<AppDbContext>>();
            using var context = contextFactory.CreateDbContext();

            if (context.Set<NewsCathegory>().Any())
                return;

            var cathegories = new List<NewsCathegory>
            {
                new NewsCathegory { Name = "Sport" },
                new NewsCathegory { Name = "IT" },
                new NewsCathegory { Name = "Hobby" }
            };

            context.AddRange(cathegories);
            context.SaveChanges();
        }
    }
}
