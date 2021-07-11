using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineAkademi.Core.Domain.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineAkademi.Data.Sql.DbMappings.Identity
{
    public class AppUserMapping : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
            builder.Property(u => u.FirstName)
                .HasColumnType("varchar(30)")
                .IsRequired();

            builder.Property(u => u.LastName)
                .HasColumnType("varchar(30)")
                .IsRequired();

            builder.Property(u => u.Age)
                .IsRequired();
        }
    }
}
