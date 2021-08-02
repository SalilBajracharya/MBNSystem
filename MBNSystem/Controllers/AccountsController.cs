using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Net.Mail;
using System.Runtime.Remoting;
using System.Security.Cryptography.Pkcs;
using System.Threading.Tasks;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using System.Web.Razor.Generator;
using System.Web.Security;
using System.Web.Services.Description;
using MBNSystem.Models;
using MBNSystem.ViewModels;

//-----------------------USER ACCOUNTS MODIFICATION CONTROLLER-----------------------//
namespace MBNSystem.Controllers
{
    public class AccountsController : Controller
    {
        MBNSystemEntities db = new MBNSystemEntities();
        //Add New User if Super User Only
        public ActionResult _AddUser()
        {
            return PartialView();
        }

        [HttpPost]
        public ActionResult AddUserAuthorize(User obj)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    User user = new User();

                    user.UserName = obj.UserName;
                    user.Email = obj.Email;
                    user.MobileNo = obj.MobileNo;
                    user.Password = Membership.GeneratePassword(10, 3);
                    user.Name = obj.Name;
                    user.Designation = obj.Designation;
                    user.RoleId = obj.RoleId;
                    user.Status = 1;
                    user.CreatedDate = DateTime.Now;
                    user.ExpiryDate = DateTime.Now.AddYears(1);
                    user.LastPwdChangeDate = DateTime.Now;
                    user.ChangePwd = false;//if 1 force user to reset 
                    SendMail(user.UserName, user.Email, user.Password, "NewAccount");
                    db.Users.Add(user);
                    db.SaveChanges();

                }
                catch (Exception ex)
                {
                    throw ex;
                }

            }
            return RedirectToAction("Main", "Home");
        }

        public ActionResult EditUser(int userid)
        {
            var user = db.Users.Where(x => x.UserId == userid).FirstOrDefault();
            return View(user);
        }

        [HttpPost]
        public ActionResult EditUser(User obj)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    string username = User.Identity.Name;
                    var user = db.Users.Where(x => x.UserName == username).FirstOrDefault();
                    user.UserName = obj.UserName;
                    user.Email = obj.Email;
                    user.MobileNo = obj.MobileNo;
                    user.Name = obj.Name;
                    user.Designation = obj.Designation;
                    user.Status = 1;
                    db.Entry(user).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return RedirectToAction("Index", "User");
        }


        //Delete User
        [HttpPost]
        public ActionResult DeleteUser(int id)
        {
            db.Users.Remove(db.Users.Find(id));
            db.SaveChanges();
            return RedirectToAction("Index", "User");
        }

        //Forgot Password Actions
        public ActionResult ForgotPassword()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ForgotPassword(string username)
        {
            string message = "";
            using (MBNSystemEntities db = new MBNSystemEntities())
            {
                var userdetails = db.Users.Where(x => x.UserName == username).FirstOrDefault();
                if (userdetails != null)
                {
                    string validationKey = Guid.NewGuid().ToString().Substring(0, 8);
                    string validationPin = Guid.NewGuid().ToString().Substring(0, 4);
                    SendMail(userdetails.UserName, userdetails.Email, validationKey, "ResetPassword");

                    UserValidationRequest uvr = new UserValidationRequest();
                    uvr.UserId = userdetails.UserId;
                    uvr.ValidationType = 1;
                    uvr.ValidationExpiryDate = DateTime.Now.AddDays(1);
                    uvr.ValidationKey = validationKey;
                    uvr.ValidationPin = validationPin;
                    uvr.ValidationStatus = 0;
                    db.UserValidationRequests.Add(uvr);
                    db.SaveChanges();
                    message = "Reset Password link has been sent to your email id.";
                }
                else
                {
                    message = "Account Not Found";
                }
            }
            ViewBag.Message = message;
            return View();
        }


        [NonAction]
        public void SendMail(string username, string emailId, string key, string emailFor)
        {
            var verifyUrl = "/Accounts/" + emailFor + "/?vk=" + key;
            var link = Request.Url.AbsoluteUri.Replace(Request.Url.PathAndQuery, verifyUrl);

            var fromEmail = new MailAddress("testingemail0911@gmail.com", "Testing");
            var toEmail = new MailAddress(emailId);
            var fromEmailPassword = "!testing123";
            string subject = "";
            string body = "";

            if (emailFor == "NewAccount")
            {
                subject = "Your MBNSystem account has been created";
                body = "Your login credentials are : </br></br> Username:" + username + "</br> Password:" + key;
            }
            else if (emailFor == "ResetPassword")
            {
                subject = "Reset Password";
                body = "Your reset password link is ready. Please click on the link for resetting your password. </br> <a href=" + link + ">" + link + "</a>";
            }



            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromEmail.Address, fromEmailPassword)
            };

            using (var message = new MailMessage(fromEmail, toEmail)
            {
                Subject = subject,
                Body = body,
                IsBodyHtml = true
            })
                smtp.Send(message);
        }

        //Get View for Change Password
        public ActionResult ChangePassword()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ChangePassword(ChangePasswordVM obj)
        {
            int uid = Convert.ToInt32(Session["userID"]);
            User u = db.Users.Find(uid);
            if (u.Password == obj.CurrentPassword)
            {
                u.Password = obj.NewPassword;
                db.Entry(u).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                ViewBag.Message = "New Password updated successfully.";
            }
            else
            {
                ViewBag.Message = "Something went wrong.";

            }
            return View("Main", "Home");
        }

        //public ActionResult ResetPassword(string vk)
        //{
        //    if (string.IsNullOrWhiteSpace(vk))
        //    {
        //        return HttpNotFound();
        //    }
        //    using (MBNSystemEntities db = new MBNSystemEntities())
        //    {
        //        var user = db.UserValidationRequests.Where(x => x.ValidationKey == vk).FirstOrDefault();


        //        if (user != null && DateTime.Now < user.ValidationExpiryDate)
        //        {
        //            ResetPasswordModel model = new ResetPasswordModel();
        //            model.validationKey = vk;
        //            return View(model);
        //        }
        //        else if (user != null && DateTime.Now >= user.ValidationExpiryDate)
        //        {
        //            UserValidationRequest uvr = new UserValidationRequest();
        //            user.ValidationStatus = 2;
        //            uvr.ValidationStatus = user.ValidationStatus;
        //            db.Configuration.ValidateOnSaveEnabled = false;
        //            db.SaveChanges();
        //            return HttpNotFound();
        //        }
        //        else
        //        {
        //            return HttpNotFound();
        //        }
        //    }
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult ResetPassword(ResetPasswordModel model)
        //{
        //    var message = "";
        //    if (ModelState.IsValid)
        //    {
        //        using (MBNSystemEntities db = new MBNSystemEntities())

        //        {
        //            var uvr = db.UserValidationRequests.Where(x => x.ValidationKey == model.validationKey).FirstOrDefault();
        //            if (uvr != null)
        //            {
        //                var user = db.Users.Where(x => x.UserId == uvr.UserId).FirstOrDefault();
        //                user.Password = /*Crypto.Hash(model.NewPassword);*/model.NewPassword;
        //                user.LastPwdChangeDate = DateTime.Now;
        //                uvr.ValidationStatus = 1;
        //                db.Configuration.ValidateOnSaveEnabled = false;
        //                db.SaveChanges();
        //                message = "New Password updated successfully";
        //            }

        //        }
        //    }
        //    else
        //    {
        //        message = "Something went wrong";
        //    }

        //    ViewBag.Message = message;


        //    return View(model);
        //}
    }
}