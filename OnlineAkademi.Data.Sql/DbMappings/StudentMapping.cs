using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineAkademi.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineAkademi.Data.Sql.DbMappings
{
    public class StudentMapping: IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.HasKey(s => s.UserName);
            builder.Property(s => s.UserName)
                .HasColumnType("varchar(10)");

            builder.Property(s => s.FirstName)
                 .HasColumnType("varchar(30)")
                 .IsRequired()
                 .HasColumnName("FirstName");

            builder.Property(s => s.LastName)
                .HasColumnType("varchar(30)")
                .IsRequired()
                .HasColumnName("LastName");

            builder.Property(s => s.FirstName)
                .IsRequired()
                .HasColumnType("varchar(30)")
                .HasColumnName("Experience");

            builder.Property(t => t.LastName)
                .IsRequired()
                .HasColumnType("varchar(30)")
                .HasColumnName("TrainerType");

            builder.Property(s => s.LastupUser)
                .HasColumnType("varchar(10)")
                .IsRequired();

            builder.Property(s => s.CreateUser)
                .HasColumnType("varchar(10)")
                .IsRequired();

            builder.Property(t => t.CreateDate)
                .HasDefaultValueSql("getdate()");

            builder.Property(s => s.LastupDate)
                .HasDefaultValueSql("getdate()");

            builder.Property(s => s.IsActive)
                .HasDefaultValueSql("1");

            builder.ToTable("Students");
        }
    }
}
