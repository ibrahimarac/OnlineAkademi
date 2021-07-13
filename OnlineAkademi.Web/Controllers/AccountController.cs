using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnlineAkademi.Core.Domain.Common;
using OnlineAkademi.Core.Domain.Dto.Identity;
using OnlineAkademi.Core.Domain.Entities.Identity;
using OnlineAkademi.Core.Services;
using OnlineAkademi.Services.Services.Identity;
using OnlineAkademi.Utils.Extensions;
using OnlineAkademi.Web.Models.VM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineAkademi.Web.Controllers
{
    [AllowAnonymous]
    public class AccountController : Controller
    {
        private readonly IAccountService _accountService;
        private readonly SignInManager<AppUser> _signinService;
        private readonly IMapper Mapper;

        public AccountController(IAccountService accountService,IMapper mapper, SignInManager<AppUser> signinService)
        {
            _accountService = accountService;
            Mapper = mapper;
            _signinService = signinService;
        }


        [HttpGet]
        [Route("Account/Login")]
        public IActionResult Login()
        {
            if (HttpContext.HasCookie("username"))
            {
                var model = new LoginVM
                {
                    UserName = HttpContext.GetCookie("username"),
                    RememberMe = true
                };
                return View(model);
            };

            return View();
        }

        [HttpPost]
        [Route("Account/Login")]
        public async Task<IActionResult> Login(LoginVM login)
        {
            if (!ModelState.IsValid)
                return View(login).ShowMessage(JConfirmMessageType.Warning, "Uyarı", "Kullanıcı adı veya parolada hatalar var.");

            var loginDto = Mapper.Map<LoginVM, LoginDto>(login);
            var result=await _accountService.Login(loginDto);

            //Beni Hatırla işaretli mi
            if (login.RememberMe)
            {
                HttpContext.SetCookie("username", login.UserName, TimeSpan.FromDays(1));
            }
            else
            {
                HttpContext.DeleteCookie("username");
            }

            if (!result)
                return View(login).ShowMessage(JConfirmMessageType.Error, "Uyarı", "Kullanıcı adı veya parola hatalı.");

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        [Route("Account/Logout")]
        [Authorize]
        public async Task<IActionResult> Logout()
        {
            await _accountService.Logout();
            return RedirectToAction("Index", "Home");
        }

    }
}
