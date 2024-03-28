using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KidKinder1.Entities;
using KidKinder1.Context;
namespace KidKinder1.Controllers
{
    public class ContactController : Controller
    {
        KidKinderContext context = new KidKinderContext();
        // GET: Contact
        public ActionResult Index()
        {
            return View();
        }
        public PartialViewResult ContactHeaderPartial()
        {
            return PartialView();
        }

        public PartialViewResult ContactAddressPartial()
        {
            ViewBag.description = context.Communications.Select(x => x.Description).FirstOrDefault();
            ViewBag.phone = context.Communications.Select(x => x.Phone).FirstOrDefault();
            ViewBag.address = context.Communications.Select(x => x.Address).FirstOrDefault();
            ViewBag.email = context.Communications.Select(x => x.Email).FirstOrDefault();

            return PartialView();
        }
        [HttpGet]
        public PartialViewResult ContactMessage()
        {
            return PartialView();
        }
        [HttpPost]
        public ActionResult ContactMessage(Contact p)
        {
            var value = context.Contacts.Add(p);
            value.SendDate = DateTime.Now;
            value.IsRead = false;
            context.SaveChanges();
            return RedirectToAction("Index", "Default");

        }
    }
}