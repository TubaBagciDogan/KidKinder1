using KidKinder1.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KidKinder1.Entities;
namespace KidKinder1.Controllers
{
    public class AdminController : Controller
    {
        KidKinderContext context = new KidKinderContext();
        public ActionResult Index()
        {
            var values = context.Admins.ToList();
            return View(values);
        }

        [HttpGet]
        public ActionResult CreateAdmin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateAdmin (Admin p)
        {
            context.Admins.Add(p);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DeleteAdmin(int id)
        {
            var values = context.Admins.Find(id);
            context.Admins.Remove(values);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult UpdateAdmin(int id)
        {
            var values = context.Admins.Find(id);
            return View(values);
        }

        [HttpPost]
        public ActionResult UpdateAdmin(Admin p)
        {
            var values = context.Admins.Find(p.AdminId);
            values.Username = p.Username;
            values.Password = p.Password;
            context.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}