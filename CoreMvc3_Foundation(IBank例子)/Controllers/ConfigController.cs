using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;



namespace CoreMvc3_Foundation.Controllers
{
    //把相依性全部寫在Controller
    public class ConfigController : Controller
    {
        public readonly IConfiguration _config;
        public ConfigController(IConfiguration config)
        {
            _config = config;
           
        }


        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ReadAppsettings()
        {
            return View();
        }

        public IActionResult ReadFriends()
        {
            ViewData["Name"] = _config.GetValue<string>("Friends:0:Name");
            ViewData["Email"] = _config.GetValue<string>("Friends:0:Email");
            ViewData["Mobile"] = _config.GetValue<string>("Friends:0:Mobile");
             

            return View();
        }
        public IActionResult ReadConnectionString()
        {
            //以下兩種寫法皆可
            string connectionString = _config.GetValue<string>("ConnectionStrings:DatabaseContext");

            string conn = _config.GetConnectionString("DatabaseContext");

            return View();
        }

    }
}