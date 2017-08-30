using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NorthWindDB.Areas.acemaster.Controllers
{
    public class HomeController : Controller
    {
        // GET: acemaster/Home
        public ActionResult Index()
        {
            return View();
        }
    }
}