using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MBNSystem.Models;

namespace MBNSystem.Controllers
{
    public class BranchController : Controller
    {
        private readonly MBNSystemEntities db = new MBNSystemEntities();
        // GET: Branch
        public ActionResult BranchInformation(int branchid)
        {
            var branchinformation = db.ClientsBranches.Where(x => x.BranchId == branchid).FirstOrDefault();
            return PartialView(branchinformation);
        }

        //---------Client Contact Information---------//
        public ActionResult BranchContact(int branchid)
        {
            var contactperson = db.ClientsContacts.Where(x => x.BranchId == branchid).ToList();
            return PartialView(contactperson);
        }

        public ActionResult EditBranchContact(int clientcontactid)  
        {
            var clientcontactinfo = db.ClientsContacts.Where(x => x.ClientContactId == clientcontactid).FirstOrDefault();
            return PartialView(clientcontactinfo);
        }

        //--------------------------------------------//

        public ActionResult _EditBranch(int branchid)
        {
            var branch = db.ClientsBranches.Where(x => x.BranchId == branchid).FirstOrDefault();
            return PartialView(branch);
        }

        [HttpPost]
        public ActionResult _EditBranch(ClientsBranch obj)
        {
            try
            {
                var branch = db.ClientsBranches.Where(x => x.BranchId == obj.BranchId).FirstOrDefault();
                branch.IsHO = obj.IsHO;
                branch.Status = obj.Status;
                branch.Name = obj.Name;
                branch.Address = obj.Address;
                branch.PhoneNo = obj.PhoneNo;
                branch.EmailId = obj.EmailId;
                branch.Remarks = obj.Remarks;
                db.Entry(branch).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return RedirectToAction("ClientsList", "Clients");
        }

    }
}