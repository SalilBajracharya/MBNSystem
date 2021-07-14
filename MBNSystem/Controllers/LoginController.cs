using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Web.Services.Description;
using System.Web.UI.WebControls;
using MBNSystem.Models;

namespace MBNSystem.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        [AllowAnonymous]
        public ActionResult LoginForm()
        {
            if (Session["userID"] == null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Main", "Home");
            }
        }

        [HttpPost]
        public ActionResult LoginAuthorize(User user)
        {
            using (MBNSystemEntities db = new MBNSystemEntities())
            {
                var userDetails = db.Users.Where(x => x.UserName == user.UserName && x.Password == user.Password).FirstOrDefault();
                if (userDetails == null)
                {
                    TempData["Message"] = "Incorrect Username or Password";
                    return View("LoginForm", user);
                }
                else
                {
                    Session["userID"] = userDetails.UserId;
                    Session["username"] = userDetails.UserName;
                    Session["loggedin"] = "loggedin";
                    FormsAuthentication.SetAuthCookie(user.UserName, false);
                    if (user.ChangePwd)
                    {
                        return RedirectToAction("Main", "Home");
                    }
                    else
                    {
                        return RedirectToAction("FirstLogin", "Login");
                    }
                }
            }
        }

        public ActionResult FirstLogin()
        {
            return View();
        }
        

        [HttpPost]
        public ActionResult FirstLogin(User model)
        {
            return RedirectToAction("LoginForm","Login");
        }

        public ActionResult Logout()
        {
            Session.Abandon();
            return RedirectToAction("LoginForm", "Login");
        }
    }
}