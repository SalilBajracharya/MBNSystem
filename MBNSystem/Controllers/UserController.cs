using MBNSystem.Models;
using MBNSystem.MultiModels;
using PagedList;
using PagedList.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MBNSystem.Controllers
{
    //----------------------- USER HOMEPAGE -----------------------//
    public class UserController : Controller
    {
        MBNSystemEntities db = new MBNSystemEntities();
        // GET: User
        public ActionResult UserList()
        {
            List<User> user = db.Users.ToList();
            return View(user);
        }

        public ActionResult _UserList(string search, int pagenumber = 1, int pageSize = 10)
        {
            ViewBag.SN = ((pagenumber - 1) * pageSize) + 1;
            var table = new UserView
            {
                Users = db.Users.ToList().ToPagedList(pagenumber, pageSize)
            };

            if (search != null && search != "")
            {
                table.Users = db.Users.Where(x => x.Name.ToLower().Contains(search.ToLower())).ToList().ToPagedList(pagenumber, pageSize);
            }
            else
            {
                table.Users = db.Users.ToList().ToPagedList(pagenumber, pageSize);
            }

            return PartialView(table);
        }


        public ActionResult UserProfile()
        {
            return View();
        }

    }


}