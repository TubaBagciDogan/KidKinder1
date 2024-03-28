using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KidKinder1.Entities;
using KidKinder1.Context;
namespace KidKinder1.Controllers
{
    public class MessageController : Controller
    {
        KidKinderContext context = new KidKinderContext();
        public ActionResult Index()
        {
            var values = context.Contacts.ToList();
            return View(values);
        }
        public ActionResult DeleteMessage(int id)
        {
            var values = context.Contacts.Find(id);
            values.IsRead = true;
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}