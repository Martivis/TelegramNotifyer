using Microsoft.EntityFrameworkCore;
using Notifyer.Data.Context.Entities;

namespace Notifyer.Data.Context
{
    public class AppDbContext : DbContext
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<UserData>().ToTable("users");
            modelBuilder.Entity<NewsCathegory>().ToTable("news_cathegories");

            modelBuilder.Entity<UserData>()
                .HasMany(e => e.SubscribedCathegories).WithMany(e => e.Subscribers);
        }
    }
}