using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineAkademi.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineAkademi.Data.Sql.DbMappings
{
    public class StudentsInCourseMapping : IEntityTypeConfiguration<StudentInCourse>
    {
        public void Configure(EntityTypeBuilder<StudentInCourse> builder)
        {
            //Student-Course ve StudentInCourse tabloları arasında çoktan çoğa ilişki kuruluyor.

            builder.HasKey(sc =>new { sc.CourseId,sc.StudentId});

            builder.HasOne(sc => sc.Student)
                .WithMany(s => s.StudentCourses)
                .HasForeignKey(sc => sc.StudentId);

            builder.HasOne(sc => sc.Course)
                .WithMany(c => c.CourseStudents)
                .HasForeignKey(sc => sc.CourseId);
        }
    }
}
