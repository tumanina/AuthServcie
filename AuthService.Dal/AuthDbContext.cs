using Microsoft.EntityFrameworkCore;
using AuthService.Dal.Configurations;
using AuthService.Dal.Entities;

namespace AuthService.Dal.DbContexts
{
    public class AuthDbContext : DbContext
    {
        public AuthDbContext(DbContextOptions<AuthDbContext> dbOptions) : base(dbOptions)
        { }

        public DbSet<AccountEntity> Accounts { get; set; }
        public DbSet<AccountActionEntity> AccountActions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new ActionEntityConfiguration());
            modelBuilder.ApplyConfiguration(new AccountEntityConfiguration());
            modelBuilder.ApplyConfiguration(new AccountActionEntityConfiguration());
        }
    }
}
