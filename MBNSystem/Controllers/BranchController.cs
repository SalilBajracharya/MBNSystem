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

        public ActionResult BranchContact(int branchid) {
            var contactperson = db.ClientsContacts.Where(x => x.BranchId == branchid).ToList();
            return PartialView(contactperson);
        }
    }
}