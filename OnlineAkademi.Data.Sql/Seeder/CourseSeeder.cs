using Microsoft.EntityFrameworkCore;
using OnlineAkademi.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineAkademi.Data.Sql.Seeder
{
    public static class CourseSeeder
    {
        public static void SeedCourses(this ModelBuilder builder)
        {
            builder.Entity<Course>().HasData(
                new Course
                {
                    Id=1,
                    CategoryId=1,
                    CreateDate=DateTime.Now,
                    LastupDate=DateTime.Now,
                    CreateUser="admin",
                    LastupUser="admin",
                    Duration=30,
                    Name="Yazılım uzmanlığı C# online ders",
                    Quota=12,
                    Price=100
                }
            );

            builder.Entity<Course>().HasData(
               new Course
               {
                   Id = 2,
                   CategoryId = 2,
                   CreateDate = DateTime.Now,
                   LastupDate = DateTime.Now,
                   CreateUser = "admin",
                   LastupUser = "admin",
                   Duration = 120,
                   Name = "Yazılım uzmanlığı C# canlı ders",
                   Quota = 15,
                   Price = 50
               }
           );
        }
    }
}
