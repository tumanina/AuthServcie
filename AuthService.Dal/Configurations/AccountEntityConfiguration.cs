using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using AuthService.Dal.Entities;

namespace AuthService.Dal.Configurations
{
    internal class AccountEntityConfiguration : IEntityTypeConfiguration<AccountEntity>
    {
        public void Configure(EntityTypeBuilder<AccountEntity> builder)
        {
            builder.ToTable("Accounts");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).HasDefaultValueSql("NEWID()");

            builder.Property(x => x.Username)
                   .HasMaxLength(100)
                   .IsRequired();

            builder.Property(x => x.Password)
                   .HasMaxLength(100)
                   .IsRequired();
        }
    }

}
