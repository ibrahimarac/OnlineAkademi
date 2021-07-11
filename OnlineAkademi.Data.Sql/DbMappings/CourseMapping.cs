using OnlineAkademi.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineAkademi.Data.Sql.DbMappings
{
    public class CourseMapping : BaseEntityMapping<Course>
    {
        public override void Configure(EntityTypeBuilder<Course> builder)
        {
            base.Configure(builder);

            builder.Property(c => c.Name)
                .HasColumnType("varchar(150)")
                .IsRequired()
                .HasColumnName("CourseName");

            builder.Property(c => c.Duration)
                .IsRequired()
                .HasColumnName("Duration");

            builder.Property(c => c.Price)
                .IsRequired()
                .HasColumnName("Price");

            builder.Property(c => c.Quota)
                .IsRequired()
                .HasColumnName("Quota");

            builder.Property(c => c.LastupUser)
                .HasColumnType("varchar(10)")
                .IsRequired();

            builder.Property(c => c.CreateUser)
                .HasColumnType("varchar(10)")
                .IsRequired();

            builder.Property(c => c.CreateDate)
                .HasDefaultValueSql("getdate()");

            builder.Property(c => c.LastupDate)
                .HasDefaultValueSql("getdate()");

            builder.Property(c => c.IsActive)
                .HasDefaultValueSql("1");

        }
    }
}
