using ControleLancamento.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ControleLancamento.Infra.Data.EntitiesConfiguration
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("tbUser");

            builder.RegistryFieldsEntity();

            builder.Property(p => p.Name)
                .HasColumnName("nmUser")
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(p => p.Email)
                .IsRequired()
                .HasMaxLength(120);

            builder.Property(p => p.Password)
                .IsRequired()
                .HasMaxLength(60);

            builder.Property(p => p.Occupation)
               .HasMaxLength(60);

            builder.Property(p => p.CellPhone)
               .HasMaxLength(11);
        }
    }
}
