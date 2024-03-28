using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KidKinder1.Entities;
using KidKinder1.Context;
namespace KidKinder1.Controllers
{
    public class CommunicationController : Controller
    {
        KidKinderContext context = new KidKinderContext();
        public ActionResult Index()
        {
            var values = context.Communications.ToList();
            return View(values);
        }
        [HttpGet]
        public ActionResult CreateCommunication()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateCommunication(Communication p)
        {
            context.Communications.Add(p);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DeleteCommunication(int id)
        {
            var values = context.Communications.Find(id);
            context.Communications.Remove(values);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult UpdateCommunication(int id)
        {
            var values = context.Communications.Find(id);
            return View(values);
        }
        [HttpPost]
        public ActionResult UpdateCommunication(Communication p)
        {
            var values = context.Communications.Find(p.CommunicationId);
            values.Description = p.Description;
            values.Address = p.Address;
            values.Email = p.Email;
            values.Phone = p.Phone;
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}