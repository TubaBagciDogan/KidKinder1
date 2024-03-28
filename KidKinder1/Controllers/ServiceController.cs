using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KidKinder1.Entities;
using KidKinder1.Context;
namespace KidKinder1.Controllers
{
    public class ServiceController : Controller
    {
        KidKinderContext context = new KidKinderContext();
        public ActionResult Index()
        {
            var values = context.Services.ToList();
            return View(values);
        }
        [HttpGet]
        public ActionResult CreateService()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateService(Service p)
        {
            context.Services.Add(p);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DeleteService(int id)
        {
            var values = context.Services.Find(id);
            context.Services.Remove(values);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult UpdateService(int id)
        {
            var values = context.Services.Find(id);
            return View(values);
        }

        [HttpPost]
        public ActionResult UpdateService(Service p)
        {
            var values = context.Services.Find(p.ServiceId);
            values.Title = p.Title;
            values.Description = p.Description;
            values.IconUrl = p.IconUrl;
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}