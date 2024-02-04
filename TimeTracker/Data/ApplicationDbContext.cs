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

        public DbSet<User> Users => Set<User>();
        public DbSet<News> News => Set<News>();

        public DbSet<Finance> Finance => Set<Finance>();

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            
            builder
                .Entity<User>()
                .Property(u => u.Created)
                .HasDefaultValueSql("SYSUTCDATETIME()");

            builder
                .Entity<News>()
                .Property(n => n.Date)
                .HasDefaultValueSql("SYSUTCDATETIME()");

            builder
                .Entity<News>()
                .Property(e => e.CreateDate)
                .HasDefaultValueSql("SYSUTCDATETIME()");
            
            builder
               .Entity<Finance>()
               .Property(e => e.Date)
               .HasDefaultValueSql("SYSUTCDATETIME()");

            builder
                .Entity<News>()
                .Property(e => e.IsActive)
                .HasDefaultValue(true);
        }
    }
}
