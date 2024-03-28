using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KidKinder1.Entities;
using KidKinder1.Context;
namespace KidKinder1.Controllers
{
    public class NotificationController : Controller
    {
        KidKinderContext context = new KidKinderContext();
        public ActionResult Index()
        {
            var values = context.Notifications.ToList();
            return View(values);
        }
        [HttpGet]
        public ActionResult CreateNotification()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateNotification(Notification p)
        {
            context.Notifications.Add(p);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DeleteNotification(int id)
        {
            var values = context.Notifications.Find(id);
            context.Notifications.Remove(values);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult UpdateNotification(int id)
        {
            var values = context.Notifications.Find(id);
            return View(values);
        }

        [HttpPost]
        public ActionResult UpdateNotification(Notification p)
        {
            var values = context.Notifications.Find(p.NotificationId);
            values.Title = p.Title;
            values.ImageUrl = p.ImageUrl;
            values.Description = p.Description;
            values.NotificationDate = p.NotificationDate;
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}