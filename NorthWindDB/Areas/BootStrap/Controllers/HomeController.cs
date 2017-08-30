using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NorthWindDB.Areas.BootStrap.Controllers
{
    public class HomeController : Controller
    {
        // GET: BootStrap/Home
        public ActionResult Index()
        {
            return View();
        }
    }
}