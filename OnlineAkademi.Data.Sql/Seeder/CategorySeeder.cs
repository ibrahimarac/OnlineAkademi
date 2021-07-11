using OnlineAkademi.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineAkademi.Data.Sql.Seeder
{
    public static class CategorySeeder
    {
        public static void SeedCategories(this ModelBuilder builder)
        {
            builder.Entity<Category>()
                .HasData(
                    new Category
                    {
                        Id=1,
                        Name="Online",
                        CreateUser="admin",
                        LastupUser="admin",
                        CreateDate=DateTime.Now,
                        LastupDate=DateTime.Now
                    },
                    new Category
                    {
                        Id = 2,
                        Name = "Yüz Yüze Eğitim",
                        CreateUser = "admin",
                        LastupUser = "admin",
                        CreateDate = DateTime.Now,
                        LastupDate = DateTime.Now
                    },
                    new Category
                    {
                        Id = 3,
                        Name = "Sunum",
                        CreateUser = "admin",
                        LastupUser = "admin",
                        CreateDate = DateTime.Now,
                        LastupDate = DateTime.Now
                    },
                    new Category
                    {
                        Id = 4,
                        Name = "Makale",
                        CreateUser = "admin",
                        LastupUser = "admin",
                        CreateDate = DateTime.Now,
                        LastupDate = DateTime.Now
                    },
                    new Category
                    {
                        Id = 5,
                        Name = "Mini Proje",
                        CreateUser = "admin",
                        LastupUser = "admin",
                        CreateDate = DateTime.Now,
                        LastupDate = DateTime.Now
                    }
                );
        }
    }
}
