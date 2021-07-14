using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MBNSystem.Models;
using System.Data.Entity;
using MBNSystem.MultiModels;
using PagedList;
using PagedList.Mvc;

namespace MBNSystem.Controllers
{
    public class ClientsController : Controller
    {
        private readonly MBNSystemEntities db = new MBNSystemEntities();
        // GET: Clients
        public ActionResult ClientsList()   
        {
            return View();
        }

        public ActionResult _ClientsList(string search, int pageNumber = 1, int pageSize = 10)
        {
            ViewBag.SN = ((pageNumber - 1) * pageSize) + 1; 

            var table = new MultiTableView
            {
                Client = db.Clients.ToList().ToPagedList(pageNumber, pageSize),
                ClientBranch = db.ClientsBranches.ToList(),
                ClientContact = db.ClientsContacts.ToList()
            };

            if (search != null && search != "")
            {
                table.Client = db.Clients.Where(x => x.Name.ToLower().Contains(search.ToLower())).ToList().ToPagedList(pageNumber, pageSize);
            }
            else
            {
                table.Client = db.Clients.ToList().ToPagedList(pageNumber, pageSize);
            }
            return PartialView(table);
        }

        public ActionResult _ClientsInfo(int clientid)
        {

            return PartialView();
        }

        public ActionResult _AddClients()
        {
            return PartialView();
        }

        [HttpPost]
        public ActionResult AddClientsAuthorize(Client obj)
        {
            if (ModelState.IsValid)
            {   
                try
                {
                    Client client = new Client();

                    client.Name = obj.Name;
                    client.Status = obj.Status;
                    client.PANNo = obj.PANNo;
                    client.AssignedStaffHrid = obj.AssignedStaffHrid;
                    client.SBId = obj.SBId;
                    client.SBVPN = obj.SBVPN;
                    client.SMSId = obj.SMSId;
                    client.UsesATM = obj.UsesATM;

                    db.Clients.Add(client);
                    db.SaveChanges();

                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return RedirectToAction("ClientsList", "Clients");
        }

        public ActionResult _EditClient(int clientid)
        {
            var client = db.Clients.Where(x => x.ClientId == clientid).SingleOrDefault();
            return PartialView(client);
        }

        [HttpPost]
        public ActionResult _EditClient(Client obj)
        {
            try
            {
                var client = db.Clients.Where(x => x.ClientId == obj.ClientId).FirstOrDefault();
                client.Name = obj.Name;
                client.Status = obj.Status;
                client.PANNo = obj.PANNo;
                //client.AssignedStaffHrid = obj.AssignedStaffHrid;
                //client.SBId = obj.SBId;
                //client.SBVPN = obj.SBVPN;
                //client.SMSId = obj.SMSId;
                //client.UsesATM = obj.UsesATM;
                db.Entry(client).State = EntityState.Modified;
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return RedirectToAction("ClientsList", "Clients");
        }

        [HttpPost]
        public ActionResult _DeleteClient(int id)
        {
            db.Clients.Remove(db.Clients.Find(id));
            db.SaveChanges();
            return RedirectToAction("ClientsList", "Clients");
        }


        //Single Client Information
        public ActionResult ClientInformation(int clientid)
        {
            var client = db.Clients.Where(x => x.ClientId == clientid).SingleOrDefault();
            return PartialView(client);
        }

        public ActionResult _EditClientInformation(int clientid)
        {
            var client = db.Clients.Where(x => x.ClientId == clientid).SingleOrDefault();
            return PartialView(client);
        }

        [HttpPost]
        public ActionResult _EditClientInformation(Client obj)
        {
            try
            {
                var client = db.Clients.Where(x => x.ClientId == obj.ClientId).SingleOrDefault();
                client.Name = obj.Name;
                client.Status = obj.Status;
                client.PANNo = obj.PANNo;
                client.AssignedStaffHrid = obj.AssignedStaffHrid;
                client.SBId = obj.SBId;
                client.SBVPN = obj.SBVPN;
                client.SMSId = obj.SMSId;
                client.UsesATM = obj.UsesATM;

                db.Entry(client).State = EntityState.Modified;
                db.SaveChanges();
            }
            catch(Exception ex)
            {
                throw ex;
            }
            return RedirectToAction("ClientsList", "Clients");
        }
    }

}