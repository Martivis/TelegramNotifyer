using Microsoft.EntityFrameworkCore;
using Notifyer.Data.Context.Entities;

namespace Notifyer.Data.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<UserData>().ToTable("users");
            modelBuilder.Entity<NewsCathegory>().ToTable("news_cathegories");

            modelBuilder.Entity<UserData>().HasKey(x => x.ChatId);
            modelBuilder.Entity<NewsCathegory>().HasKey(x => x.Id);

            modelBuilder.Entity<UserData>()
                .HasMany(e => e.SubscribedCathegories).WithMany(e => e.Subscribers);
        }
    }
}