using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcRazor.Controllers
{
    public class RazorController : Controller
    {
        // GET: Razor
        public ActionResult Index()
        {
            return View();
        }

        //Razor規則
        public ActionResult RazorRules()
        {
            return View();
        }


        //Razor陳述式
        public ActionResult RazorStatement()
        {
            return View();
        }

        public ActionResult ImageUrl()
        {
            return View();
        }
    }
}