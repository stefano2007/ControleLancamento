using ControleLancamento.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ControleLancamento.Infra.Data.EntitiesConfiguration
{
    public class LaunchConfiguration : IEntityTypeConfiguration<Launch>
    {
        public void Configure(EntityTypeBuilder<Launch> builder)
        {
            builder.ToTable("tbLaunch");

            builder.RegistryFieldsEntity();

            builder.Property(p => p.CategoryId)
                .IsRequired();

            builder.Property(p => p.AccountId)
                .IsRequired();

            builder.Property(p => p.LaunchType)
                .HasColumnType("int")
                .IsRequired();

            builder.Property(p => p.Description)
                .HasColumnName("dsLaunch")
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(p => p.DateLaunch)
                .HasColumnName("dtLaunch")
                .HasColumnType("Date")
                .IsRequired();

            builder.Property(p => p.Price)
                .HasColumnType("Money")
                .IsRequired();

            builder.Property(p => p.Observation)
                .HasMaxLength(250);

            builder.Property(p => p.Tag)
                .HasMaxLength(20);

            builder.HasOne(c => c.Account)
                .WithMany(c => c.Launchs);
        }
    }
}
