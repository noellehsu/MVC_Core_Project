using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;


namespace CoreMvc3_Razor_Clone.Controllers
{
    public class ParitalViewController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult SimpleCard()
        {
            return View();
        }
    }
}