using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KidKinder1.Entities;
using KidKinder1.Context;
namespace KidKinder1.Controllers
{
    public class MailSubscribeController : Controller
    {
        KidKinderContext context = new KidKinderContext();

        public ActionResult Index()
        {
            var values = context.MailSubscribes.ToList();
            return View(values);
        }
        [HttpGet]
        public ActionResult CreateMailSubscribe()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateMailSubscribe(MailSubscribe p)
        {
            context.MailSubscribes.Add(p);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DeleteMailSubscribe(int id)
        {
            var values = context.MailSubscribes.Find(id);
            context.MailSubscribes.Remove(values);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult UpdateMailSubscribe(int id)
        {
            var values = context.MailSubscribes.Find(id);
            return View(values);
        }
        [HttpPost]
        public ActionResult UpdateMailSubscribe(MailSubscribe p)
        {
            var values = context.MailSubscribes.Find(p.MailSubscribeId);
            values.NameSurname = p.NameSurname;
            values.Email = p.Email;
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}