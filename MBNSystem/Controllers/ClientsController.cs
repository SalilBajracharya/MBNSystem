using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MBNSystem.Models;
using System.Data.Entity;

namespace MBNSystem.Controllers
{
    public class ClientsController : Controller
    {
        MBNSystemEntities db = new MBNSystemEntities();
        // GET: Clients
        public ActionResult ClientsList(string search)
        {
            List<Client> clients = db.Clients.ToList();
            return View(db.Clients.Where(x => x.Name.Contains(search) || search == null).ToList() );
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
        public ActionResult EditClient(Client obj)
        {
            if (ModelState.IsValid)
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
                catch(Exception ex)
                {
                    throw ex;
                }
            }
            return RedirectToAction("ClientsList", "Clients");
        }

        [HttpPost]
        public ActionResult DeleteClient(int id)
        {
            db.Clients.Remove(db.Clients.Find(id));
            db.SaveChanges();
            return RedirectToAction("ClientsList", "Clients");
        }
    }    
}