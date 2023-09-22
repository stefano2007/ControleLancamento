using ControleLancamento.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ControleLancamento.Infra.Data.EntitiesConfiguration
{
    public static class EntityConfiguration
    {
        public static void RegistryFieldsEntity<T>(this EntityTypeBuilder<T> builder) where T : Entity
        {
            builder.HasKey(t => t.Id);

            builder.Property(p => p.Active)
                .HasColumnName("ckActive")
                .HasColumnType("Bit")
                .IsRequired();

            builder.Property(p => p.DateCreate)
                .HasColumnName("dtCreate")
                .HasColumnType("Datetime")
                .IsRequired();
           
        }
    }
}
