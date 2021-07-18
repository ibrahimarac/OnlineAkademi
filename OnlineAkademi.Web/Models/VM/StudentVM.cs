using OnlineAkademi.Core.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineAkademi.Web.Models.VM
{
    public class StudentVM
    {
        [Display(Name ="Kullanıcı adı")]
        public string UserName { get; set; }

        [Display(Name ="Email")]
        public string Email { get; set; }

        [Display(Name ="Parola")]
        public string Password { get; set; }

        [Display(Name ="Parola tekrar")]
        public string PasswordConfirm { get; set; }

        [Display(Name = "İsim")]
        public string FirstName { get; set; }

        [Display(Name = "Soyisim")]
        public string LastName { get; set; }

        [Display(Name = "Cinsiyeti")]
        public Gender Gender { get; set; }

        [Display(Name = "Yaşı")]
        public int Age { get; set; }

        public string ReturnUrl { get; set; }

    }
}
