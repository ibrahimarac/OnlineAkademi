using OnlineAkademi.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineAkademi.Data.Sql.DbMappings
{
    public class LogMapping:BaseEntityMapping<Log>
    {
        public override void Configure(EntityTypeBuilder<Log> builder)
        {
            base.Configure(builder);

            builder.Property(log => log.Username)
                .HasColumnType("varchar(10)")
                .IsRequired();

            builder.Property(log => log.Old)
                .HasColumnType("varchar(max)");

            builder.Property(log => log.New)
                .HasColumnType("varchar(max)");

            builder.Property(log => log.EntityName)
                .HasColumnType("varchar(30)")
                .IsRequired();

            builder.Property(log => log.LogDate)
                .HasDefaultValueSql("getdate()")
                .IsRequired();
        }
    }
}
