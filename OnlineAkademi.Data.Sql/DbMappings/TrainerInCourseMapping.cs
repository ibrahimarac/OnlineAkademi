using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineAkademi.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineAkademi.Data.Sql.DbMappings
{
    public class TrainerInCourseMapping : IEntityTypeConfiguration<TrainerInCourse>
    {
        public void Configure(EntityTypeBuilder<TrainerInCourse> builder)
        {
            //Trainer-Course ve TrainerInCourse tabloları arasında çoktan çoğa ilişki kuruluyor.

            builder.HasKey(tc =>new { tc.CourseId,tc.TrainerId});

            builder.HasOne(tc => tc.Trainer)
                .WithMany(t => t.TrainerInCourses)
                .HasForeignKey(tc => tc.TrainerId);

            builder.HasOne(tc => tc.Course)
                .WithMany(c => c.TrainerInCourses)
                .HasForeignKey(tc => tc.CourseId);
        }
    }
}
