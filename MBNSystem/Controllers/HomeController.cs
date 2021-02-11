using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MBNSystem.Controllers
{
    public class HomeController : Controller
    {
        [Route("Main")]
        public ActionResult Main()
        {
            return View();
        }

    }
}