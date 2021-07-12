using Microsoft.AspNetCore.Identity;
using OnlineAkademi.Core.Domain.Common;
using OnlineAkademi.Core.Domain.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OnlineAkademi.Data.Sql.Identity
{
    public class UserAndRoleSeeder
    {
        public static async Task InitializeAsync(UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            string adminUserName = "admin";
            string adminEmail = "admin@gmail.com";
            string password = "12345";
            if (await roleManager.FindByNameAsync("admin") == null)
            {
                await roleManager.CreateAsync(new IdentityRole("admin"));
            }
            if (await roleManager.FindByNameAsync("student") == null)
            {
                await roleManager.CreateAsync(new IdentityRole("student"));
            }
            if (await roleManager.FindByNameAsync("trainer") == null)
            {
                await roleManager.CreateAsync(new IdentityRole("trainer"));
            }
            if (await userManager.FindByNameAsync(adminUserName) == null)
            {
                AppUser admin = new AppUser
                {
                    Email = adminEmail,
                    UserName = adminUserName,
                    FirstName = "Ahmet",
                    LastName = "ŞAHİN",
                    Gender = Gender.Male,
                    Age = 30
                };

                IdentityResult result = await userManager.CreateAsync(admin, password);

                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(admin, "admin");
                }
            }
        }
    }
}
