using ControleLancamento.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ControleLancamento.Infra.Data.EntitiesConfiguration
{
    public class AccountConfiguration : IEntityTypeConfiguration<Account>
    {
        public void Configure(EntityTypeBuilder<Account> builder)
        {
           
            builder.ToTable("tbAccount");

            builder.RegistryFieldsEntity();

            builder.Property(p => p.Name)
                .HasColumnName("nmAccount")
                .HasMaxLength(100)
                .IsRequired();

            builder.HasMany(c => c.Launchs)
                .WithOne(c => c.Account)
                .HasForeignKey(c => c.AccountId);
        }
    }
}
