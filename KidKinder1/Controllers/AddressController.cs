using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KidKinder1.Entities;
using KidKinder1.Context;
namespace KidKinder1.Controllers
{
    public class AddressController : Controller
    {
        KidKinderContext context = new KidKinderContext();
        public ActionResult Index()
        {
            var values = context.Addresses.ToList();
            return View(values);
        }

        [HttpGet]
        public ActionResult CreateAddress()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateAddress(Address p)
        {
            context.Addresses.Add(p);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DeleteAddress(int id)
        {
            var values = context.Addresses.Find(id);
            context.Addresses.Remove(values);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UpdateAddress(int id)
        {
            var values = context.Addresses.Find(id);
            return View(values);
        }
        [HttpPost]
        public ActionResult UpdateAddress(Address p)
        {
            var values = context.Addresses.Find(p.AddressId);
            values.Description = p.Description;
            values.AddressDetail = p.AddressDetail;
            values.Email = p.Email;
            values.Phone = p.Phone;
            values.OpeningHours = p.OpeningHours;
            context.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}