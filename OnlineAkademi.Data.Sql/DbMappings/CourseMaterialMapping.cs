using OnlineAkademi.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OnlineAkademi.Core.Domain.Dto;

namespace OnlineAkademi.Data.Sql.DbMappings
{
    public class CourseMaterialMapping : BaseEntityMapping<CourseMaterial>
    {
        public override void Configure(EntityTypeBuilder<CourseMaterial> builder)
        {
            base.Configure(builder);

            builder.Property(m => m.Description)
                .HasColumnType("varchar(250)")
                .IsRequired()
                .HasColumnName("Description");

            builder.Property(m => m.Url)
               .HasColumnType("varchar(200)")
               .IsRequired()
               .HasColumnName("Url");

            builder.Property(m => m.MaterialType)
                .IsRequired()
                .HasColumnName("MaterialType");

            builder.Property(m => m.LastupUser)
                .HasColumnType("varchar(10)")
                .IsRequired();

            builder.Property(m => m.CreateUser)
                .HasColumnType("varchar(10)")
                .IsRequired();

            builder.Property(m => m.CreateDate)
                .HasDefaultValueSql("getdate()");

            builder.Property(m => m.LastupDate)
                .HasDefaultValueSql("getdate()");


        }
    }
}
