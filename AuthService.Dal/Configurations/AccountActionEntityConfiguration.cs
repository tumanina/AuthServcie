using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using AuthService.Dal.Entities;

namespace AuthService.Dal.Configurations
{
    internal class AccountActionEntityConfiguration : IEntityTypeConfiguration<AccountActionEntity>
    {
        public void Configure(EntityTypeBuilder<AccountActionEntity> builder)
        {
            builder.ToTable("AccountActions");

            builder.HasKey(x => new { x.AccountId, x.ActionId });

            builder.HasOne(x => x.Account)
                .WithMany(t => t.Actions)
                .HasForeignKey("AccountId")
                .IsRequired();

            builder.HasOne(x => x.Action)
                .WithMany(t => t.Accounts)
                .HasForeignKey("ActionId")
                .IsRequired();
        }
    }
}