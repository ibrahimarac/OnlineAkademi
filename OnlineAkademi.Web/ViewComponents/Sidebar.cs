using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using OnlineAkademi.Core.Domain.Entities.Identity;
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
        private readonly UserManager<AppUser> _userManager;
        private readonly IWebHostEnvironment _environment;

        public Sidebar(UserManager<AppUser> userManager, IWebHostEnvironment environment)
        {
            _userManager = userManager;
            _environment = environment;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            //sol menülerin tutulduğu json dosyasının yolu
            var jsonPath = $"{_environment.WebRootPath}\\data\\Menu.json";

            //login olan kullanıcının rolleri elde ediliyor
            var loginUser = await _userManager.GetUserAsync(UserClaimsPrincipal);

            IList<string> userRoles = null;

            if (loginUser != null)
                userRoles = await _userManager.GetRolesAsync(loginUser);
            else
                userRoles = new List<string> { "guest" };

            //Menüleri dosyadan çekelim ve deserialize işlemini gerçekleştirelim.
            var menus = JsonConvert.DeserializeObject<List<Menu>>(File.ReadAllText(jsonPath,Encoding.GetEncoding(1254)));

            //Menülerden bu kullanıcının rolüne uygun olanları elde edelim.
            var menuForRole = menus.Where(m => userRoles.Intersect(m.Roles).Count()!=0);

            return await Task.FromResult((IViewComponentResult)View(menuForRole));
        }
    }
}
