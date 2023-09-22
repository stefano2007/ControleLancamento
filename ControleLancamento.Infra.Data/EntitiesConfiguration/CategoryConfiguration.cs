using ControleLancamento.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ControleLancamento.Infra.Data.EntitiesConfiguration
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable("tbCategory");

            builder.RegistryFieldsEntity();

            builder.Property(p => p.Name)
                .HasColumnName("nmCategory")
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(p => p.Color)
                .HasMaxLength(7);

            builder.Property(p => p.Icon)
                .HasMaxLength(20);
        }
    }
}
