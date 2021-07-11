using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineAkademi.Web.Models
{
    public class Menu
    {
        public string Title { get; set; }
        public string Controller { get; set; }
        public string Action { get; set; }

        public List<string> Roles { get; set; }
        [JsonProperty("submenu")]
        public List<SubMenu> SubMenus { get; set; }
    }
}
