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

        public AccountService(UserManager<AppUser> userManager,
            SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<bool> Login(LoginDto login)
        {
            var result = await _signInManager.PasswordSignInAsync(login.UserName, login.Password, login.RememberMe, false);
            return result.Succeeded;
        }

        public async Task<bool> Register(RegisterDto register)
        {
            AppUser user = new AppUser
            {
                Email=register.Email,
                UserName=register.UserName,
                FirstName=register.Firstname,
                LastName=register.Lastname
            };

            var result = await _userManager.CreateAsync(user, register.Password);

            return result.Succeeded;
        }
    }
}
