
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineAkademi.Web.Controllers
{
    [Route("")]
    [AllowAnonymous]
    public class HomeController : Controller
    {
        [Route("")]
        [Route("Home/Index")]        
        public IActionResult Index()
        {
            return View();
        }
    }
}
