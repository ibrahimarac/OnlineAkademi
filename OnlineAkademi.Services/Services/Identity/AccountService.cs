using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using OnlineAkademi.Core.Domain.Dto.Identity;
using OnlineAkademi.Core.Domain.Entities.Identity;
using OnlineAkademi.Core.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OnlineAkademi.Services.Services.Identity
{
    public class AccountService : IAccountService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly IHttpContextAccessor _contextAccessor;

        public AccountService(UserManager<AppUser> userManager,
            SignInManager<AppUser> signInManager,
            IHttpContextAccessor contextAccessor)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _contextAccessor = contextAccessor;
        }

        public async Task<bool> DeleteUser(string userName)
        {
            var user=await _userManager.FindByNameAsync(userName);
            if (user == null)
                return false;

            var result = await _userManager.DeleteAsync(user);
            return result.Succeeded;
        }

        public async Task<bool> Login(LoginDto login)
        {
            var user = await _userManager.FindByNameAsync(login.UserName);
            if (user == null)
                return false;

            var result = await _signInManager.PasswordSignInAsync(login.UserName, login.Password, login.RememberMe, false);

            return result.Succeeded;
        }

        public async Task<bool> Register(RegisterDto register)
        {
            AppUser user = new AppUser
            {
                Email = register.Email,
                UserName = register.UserName,
                FirstName = register.Firstname,
                LastName = register.Lastname,
                Age = register.Age,
                Gender = register.Gender
            };

            var result = await _userManager.CreateAsync(user, register.Password);

            return result.Succeeded;
        }

        public async Task<bool> UpdateUser(RegisterDto register)
        {
            AppUser user = await _userManager.FindByNameAsync(register.UserName);
            if (user != null)
            {
                user.Email = register.Email;
                user.FirstName = register.Firstname;
                user.LastName = register.Lastname;
                user.Age = register.Age;
                user.Gender = register.Gender;
            }
            var result = await _userManager.UpdateAsync(user);
            return result.Succeeded;
        }

        public async Task<bool> UserExists(string userName)
        {
            var user=await _userManager.FindByNameAsync(userName);
            return user != null;
        }

        public async Task<AppUser> GetUserAsync(string userName)
        {
            var user = await _userManager.FindByNameAsync(userName);
            return user;
        }

        public async Task<IList<string>> GetRolesForUser(AppUser user)
        {
            var roles=await _userManager.GetRolesAsync(user);
            return roles;
        }

        public async Task<bool> AddUserToRole(string userName, string roleName)
        {
            var user = await _userManager.FindByNameAsync(userName);
            var result =await _userManager.AddToRoleAsync(user, roleName);
            return result.Succeeded;
        }

        public async Task Logout()
        {
            await _signInManager.SignOutAsync();
        }

        public async Task<bool> SignInAsync(string userName, string password, bool persist = false)
        {
            var userExists = await UserExists(userName);
            if (userExists)
            {
                var user = await _userManager.FindByNameAsync(userName);
                var result=await _signInManager.PasswordSignInAsync(user, password, persist, false);
                return result.Succeeded;
            }
            return false;
        }
    }
}
