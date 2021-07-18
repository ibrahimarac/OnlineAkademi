using OnlineAkademi.Core.Domain.Entities;
using OnlineAkademi.Data.Sql.DbMappings;
using OnlineAkademi.Data.Sql.Seeder;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineAkademi.Data.Sql
{
    public class AkademiContext:DbContext
    {
        public AkademiContext(DbContextOptions<AkademiContext> opt):base(opt){
            Database.EnsureCreated();
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Trainer> Trainers { get; set; }
        public DbSet<CourseMaterial> Materials { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<StudentInCourse> StudentInCourses { get; set; }
        public DbSet<Error> Errors { get; set; }
        public DbSet<Log> CrudLogs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //mapping konfigürasyonları uygulanıyor

            modelBuilder.ApplyConfiguration(new CategoryMapping());

            modelBuilder.ApplyConfiguration(new CourseMapping());

            modelBuilder.ApplyConfiguration(new CourseMaterialMapping());

            modelBuilder.ApplyConfiguration(new TrainerMapping());

            modelBuilder.ApplyConfiguration(new StudentMapping());

            modelBuilder.ApplyConfiguration(new StudentsInCourseMapping());

            modelBuilder.ApplyConfiguration(new ErrorMapping());

            modelBuilder.ApplyConfiguration(new LogMapping());


            //Veritabanına ait varsayılan veriler yükleniyor

            modelBuilder.SeedCategories();

            modelBuilder.SeedCourses();
        }



    }
}
