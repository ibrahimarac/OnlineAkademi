using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using OnlineAkademi.Core.Domain.Entities.Identity;
using OnlineAkademi.Core.Services;
using OnlineAkademi.Web.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace OnlineAkademi.Web.ViewComponents
{
    public class Sidebar:ViewComponent
    {
        private readonly IAccountService _accountService;
        private readonly IWebHostEnvironment _environment;

        public Sidebar(IAccountService accountService, IWebHostEnvironment environment)
        {
            _accountService = accountService;
            _environment = environment;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            //sol menülerin tutulduğu json dosyasının yolu
            var jsonPath = $"{_environment.WebRootPath}\\data\\Menu.json";

            IList<string> userRoles = null;

            var loggedInUser = User.Identity.Name;

            //Eğer oturum açılmamışsa
            if (loggedInUser==null)
            {
                userRoles = new List<string> { "guest" };
            }
            else
            {
                //login olan kullanıcının rolleri elde ediliyor
                var loginUser = await _accountService.GetUserAsync(loggedInUser);

                if (loginUser != null)
                    userRoles = await _accountService.GetRolesForUser(loginUser);
            }

            //Menüleri dosyadan çekelim ve deserialize işlemini gerçekleştirelim.
            var menus = JsonConvert.DeserializeObject<List<Menu>>(File.ReadAllText(jsonPath,Encoding.GetEncoding(1254)));

            //Menülerden bu kullanıcının rolüne uygun olanları elde edelim.
            var menuForRole = menus.Where(m => userRoles.Intersect(m.Roles).Count()!=0);

            return await Task.FromResult((IViewComponentResult)View(menuForRole));
        }
    }
}
