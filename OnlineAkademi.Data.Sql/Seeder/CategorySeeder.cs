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
                        Name="Kategori 1",
                        CreateUser="admin",
                        LastupUser="admin",
                        CreateDate=DateTime.Now,
                        LastupDate=DateTime.Now
                    },
                    new Category
                    {
                        Id = 2,
                        Name = "Kategori 2",
                        CreateUser = "admin",
                        LastupUser = "admin",
                        CreateDate = DateTime.Now,
                        LastupDate = DateTime.Now
                    },
                    new Category
                    {
                        Id = 3,
                        Name = "Kategori 3",
                        CreateUser = "admin",
                        LastupUser = "admin",
                        CreateDate = DateTime.Now,
                        LastupDate = DateTime.Now
                    }
                );
        }
    }
}
