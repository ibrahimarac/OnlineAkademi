using OnlineAkademi.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineAkademi.Data.Sql.DbMappings
{
    public class ErrorMapping : BaseEntityMapping<Error>
    {
        public override void Configure(EntityTypeBuilder<Error> builder)
        {
            base.Configure(builder);

            builder.Property(e => e.Id)
                .UseIdentityColumn();
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Exception)
                .HasColumnType("varchar(max)")
                .IsRequired();

            builder.Property(e => e.CreateDate)
                .HasDefaultValueSql("getdate()");

            builder.Property(e => e.IsAjaxRequest)
                .HasDefaultValueSql("0");

            builder.Property(e => e.QueryString)
                .HasColumnType("varchar(200)");

            builder.Property(e => e.Url)
                .HasColumnType("varchar(300)")
                .IsRequired();

            builder.Property(e => e.Username)
                .HasColumnType("varchar(10)")
                .IsRequired();


        }
    }
}
