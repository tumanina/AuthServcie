using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using AuthService.Dal.Entities;
using System;

namespace AuthService.Dal.Configurations
{
    internal class ActionEntityConfiguration : IEntityTypeConfiguration<ActionEntity>
    {
        public void Configure(EntityTypeBuilder<ActionEntity> builder)
        {
            builder.ToTable("Actions");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).HasDefaultValueSql("NEWID()");

            builder.Property(x => x.Name)
                   .HasMaxLength(100)
                   .IsRequired();
        }
    }

}
