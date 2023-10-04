using ControleLancamento.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleLancamento.Infra.Data.EntitiesConfiguration
{
    public class UserAccountConfiguration : IEntityTypeConfiguration<UserAccount>
    {
        public void Configure(EntityTypeBuilder<UserAccount> builder)
        {
            builder.ToTable("tbUserAccount");

            builder.RegistryFieldsEntity();

            builder.Property(p => p.UserId)
                .IsRequired();

            builder.HasOne(c => c.User);

            builder.Property(p => p.AccountId)
                .IsRequired();

            builder.HasOne(c => c.Account);

            builder.Property(p => p.IsUserMain)
                .HasColumnType("Bit")
                .IsRequired();
        }
    }
}
