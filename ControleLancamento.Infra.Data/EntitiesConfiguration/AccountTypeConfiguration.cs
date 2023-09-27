using ControleLancamento.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ControleLancamento.Infra.Data.EntitiesConfiguration
{
    public class AccountTypeConfiguration : IEntityTypeConfiguration<AccountType>
    {
        public void Configure(EntityTypeBuilder<AccountType> builder)
        {
            builder.ToTable("tbAccountType");

            builder.RegistryFieldsEntity();

            builder.Property(p => p.Name)
                .HasColumnName("nmAccountType")
                .HasMaxLength(100)
                .IsRequired();
        }
    }
}
