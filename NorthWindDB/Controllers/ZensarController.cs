using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NorthWindDB.Controllers
{
    public class ZensarController : Controller
    {
        // GET: Zensar
        public ActionResult GetView(string ViewName)
        {
            return View(ViewName);
        }
    }
}