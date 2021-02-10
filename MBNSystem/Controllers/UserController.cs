using MBNSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MBNSystem.Controllers
{
    public class UserController : Controller
    {
        MBNSystemEntities db = new MBNSystemEntities();
        // GET: User
        public ActionResult Index()
        {
            List<User> user = db.Users.ToList();
            return View(user);
        }


        public ActionResult UserProfile()
        {
            return View();
        }

    }


}