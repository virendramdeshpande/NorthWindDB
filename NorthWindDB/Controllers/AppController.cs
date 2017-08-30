using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NorthWindDB.Controllers
{
    public class AppController : Controller
    {
        // GET: app/angular
        public ActionResult Angular()
        {
            return View();
        }

        public ActionResult Zensar()
        {
            return View();
        }

    }
}