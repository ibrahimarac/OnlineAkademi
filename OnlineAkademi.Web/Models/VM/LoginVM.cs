using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineAkademi.Web.Models.VM
{
    public class LoginVM
    {
        [Display(Name ="Kullanıcı adı")]
        public string UserName { get; set; }
        [Display(Name ="Parola")]
        public string Password { get; set; }
        [Display(Name ="Beni hatırla")]
        public bool RememberMe { get; set; }
    }
}
