using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineAkademi.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineAkademi.Data.Sql.DbMappings
{
    public class TrainerMapping: IEntityTypeConfiguration<Trainer>
    {
        public void Configure(EntityTypeBuilder<Trainer> builder)
        {
            builder.HasKey(t => t.UserName);
            builder.Property(t => t.UserName)
                .HasColumnType("varchar(10)");

            builder.Property(t => t.Email)
                .HasColumnType("varchar(150)")
                .IsRequired()
                .HasColumnName("Email");

            builder.Property(t => t.FirstName)
                .HasColumnType("varchar(30)")
                .IsRequired()
                .HasColumnName("FirstName");

            builder.Property(t => t.LastName)
                .HasColumnType("varchar(30)")
                .IsRequired()
                .HasColumnName("LastName");

            builder.Property(t => t.Experience)
                .IsRequired()
                .HasColumnName("Experience");

            builder.Property(t => t.Age)
                .IsRequired()
                .HasColumnName("Age");

            builder.Property(t => t.TrainerType)
                .IsRequired()
                .HasColumnName("TrainerType");

            builder.Property(t => t.LastupUser)
                .HasColumnType("varchar(10)")
                .IsRequired();

            builder.Property(t => t.CreateUser)
                .HasColumnType("varchar(10)")
                .IsRequired();

            builder.Property(t => t.CreateDate)
                .HasDefaultValueSql("getdate()");

            builder.Property(t => t.LastupDate)
                .HasDefaultValueSql("getdate()");

            builder.Property(t => t.IsActive)
                .HasDefaultValueSql("1");

            builder.ToTable("Trainers");
        }
    }
}
