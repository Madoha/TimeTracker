using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TimeTracker.Models;
using TimeTracker.Models.Entities;

namespace TimeTracker.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<News> News => Set<News>();

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder
                .Entity<User>()
                .Property(u => u.Created)
                .HasDefaultValueSql("now()");

            builder
                .Entity<News>()
                .Property(n => n.Date)
                .HasDefaultValueSql("now()");

            builder
                .Entity<News>()
                .Property(e => e.CreateDate)
                .HasDefaultValueSql("now()");

            builder
                .Entity<News>()
                .Property(e => e.IsActive)
                .HasDefaultValue(true);
        }
    }
}
