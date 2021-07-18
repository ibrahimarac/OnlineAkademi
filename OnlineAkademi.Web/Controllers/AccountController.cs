using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnlineAkademi.Core.Domain.Common;
using OnlineAkademi.Core.Domain.Dto;
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
        private readonly IAccountService Accounts;
        private readonly IStudentService Students;
        private readonly SignInManager<AppUser> _signinService;
        private readonly IMapper Mapper;

        public AccountController(IAccountService accountService,IStudentService studentService,IMapper mapper, SignInManager<AppUser> signinService)
        {
            Accounts = accountService;
            Students = studentService;
            Mapper = mapper;
            _signinService = signinService;
        }


        [HttpGet]
        [Route("Account/Login")]
        public IActionResult Login(string ReturnUrl)
        {
            if (HttpContext.HasCookie("username"))
            {
                var model = new LoginVM
                {
                    UserName = HttpContext.GetCookie("username"),
                    RememberMe = true,
                    ReturnUrl=ReturnUrl
                };
                return View(model);
            };

            return View(new LoginVM { 
                ReturnUrl=ReturnUrl            
            });
        }

        [HttpPost]
        [Route("Account/Login")]
        public async Task<IActionResult> Login(LoginVM login)
        {
            if (!ModelState.IsValid)
                return View(login).ShowMessage(JConfirmMessageType.Warning, "Uyarı", "Kullanıcı adı veya parolada hatalar var.");

            var loginDto = Mapper.Map<LoginVM, LoginDto>(login);
            var result=await Accounts.Login(loginDto);

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

            if (login.ReturnUrl == null)
                return RedirectToAction("Index", "Home");
            else
                return Redirect(login.ReturnUrl);
        }

        [HttpGet]
        [Route("Account/Logout")]
        [Authorize]
        public async Task<IActionResult> Logout()
        {
            await Accounts.Logout();
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        [Route("Account/Register")]
        public IActionResult Register(string ReturnUrl)
        {            
            return View();
        }

        [HttpPost]
        [Route("Account/Register")]
        public async Task<IActionResult> Register(StudentVM studentVM)
        {
            if (!ModelState.IsValid)
                return View(studentVM).ShowMessage(JConfirmMessageType.Warning, "Uyarı","Girilen bilgilerde bazı hatalar tespit edildi.");

            //Önce eğitmeni Identity tablolarına eklemeye çalışalım
            var userExists = await Accounts.UserExists(studentVM.UserName);
            if (userExists)
                return View(studentVM).ShowMessage(JConfirmMessageType.Error, "Hata", "Bu kullanıcı adına sahip bir öğrenci zaten tanımlı.");

            var createStudentResult = await Accounts.Register(new RegisterDto
            {
                Email = studentVM.Email,
                Firstname = studentVM.FirstName,
                Lastname = studentVM.LastName,
                Password = studentVM.Password,
                UserName = studentVM.UserName,
                Gender = studentVM.Gender
            });

            //Öğrenciyi student rolüne ekliyorum.
            var addRoleResult = await Accounts.AddUserToRole(studentVM.UserName, "student");
            if (!addRoleResult)
                return View(studentVM).ShowMessage(JConfirmMessageType.Error, "Hata", "Öğrenci role atanırken bir hata oluştu.");


            //IDentity tablosuna ekleme başarılı ise
            //kendi tabloma kullanıcıyı ekliyorum.
            if (createStudentResult)
            {
                //VM to Dto
                var trainerDto = Mapper.Map<StudentVM, StudentDto>(studentVM);
                trainerDto.IsActive = true;
                Students.AddStudent(trainerDto);

                //Öğrenciyi login yapalım
                var result=await Accounts.SignInAsync(studentVM.UserName, studentVM.Password, true);

                //Eğer kullanıcı yetki isteyen bir sayfayı talep etti ve oturum açılmışsa
                if (studentVM.ReturnUrl != null)
                    return Redirect(studentVM.ReturnUrl);

                return RedirectToAction("Index", "Home").ShowMessage(JConfirmMessageType.Success,"Hoşgeldiniz","Öğrenci kaydınınız başarıyla tamamlandı.");
            }
                        
            return View(studentVM).ShowMessage(JConfirmMessageType.Error, "Hata", "Kullanıcı oluşturma işleminde hata(lar) var");
        }

    }
}
