using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ajaxprj1.Models;

namespace ajaxprj1.Controllers
{    
    public class contactController : Controller
    {
        public contactdbEntities db = new contactdbEntities();

        // GET: contact
        public ActionResult Index()
        {
            contact first_cont = db.contacts.First();

            return View(first_cont);
        }

        public PartialViewResult getnelem(int id)
        {
            contact cont = new contact();

            if(id == 0)
            { id = db.contacts.Count(); }
            
            else if (id > db.contacts.Count())
            { id = 1; }

            cont = db.contacts.Find(id);
            
            return PartialView("getnelem", cont);
        }
       
        public PartialViewResult addContact()
        {
            return PartialView("AddContact");
        }

        [HttpPost]
        public ActionResult addContact_post(contact cont)
        {
            if (ModelState.IsValid)
            {                
                db.contacts.Add(cont);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        public PartialViewResult remContact()
        {
            List<contact> contacts = db.contacts.ToList();

            return PartialView("RemoveContact", contacts);
        }

        [HttpPost]
        public ActionResult removeContact_post(List<contact> clist)
        {
            foreach (var cont in clist)
            {
                if (cont.ischecked)
                {
                    contact cont1 = db.contacts.Find(cont.contactId);
                    db.contacts.Remove(cont1);
                }                
            }

            db.SaveChanges();

            return RedirectToAction("Index");
        }

    }
}