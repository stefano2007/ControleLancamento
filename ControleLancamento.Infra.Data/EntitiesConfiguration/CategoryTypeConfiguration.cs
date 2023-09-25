using ControleLancamento.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ControleLancamento.Infra.Data.EntitiesConfiguration
{
    public class CategoryTypeConfiguration : IEntityTypeConfiguration<CategoryType>
    {
        public void Configure(EntityTypeBuilder<CategoryType> builder)
        {
            builder.ToTable("tbCategoryType");

            builder.RegistryFieldsEntity();

            builder.Property(p => p.Name)
                .HasColumnName("nmCategoryType")
                .HasMaxLength(100)
                .IsRequired();
        }
    }
}
