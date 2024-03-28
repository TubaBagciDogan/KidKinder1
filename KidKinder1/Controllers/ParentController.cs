using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KidKinder1.Entities;
using KidKinder1.Context;

namespace KidKinder1.Controllers
{
    public class ParentController : Controller
    {
        KidKinderContext context = new KidKinderContext();

        public ActionResult Index()
        {
            var values = context.Parents.ToList();
            return View(values);
        }
        [HttpGet]
        public ActionResult CreateParent()
        {
            List<SelectListItem> values = (from x in context.Students.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.NameSurname,
                                               Value = x.StudentId.ToString()

                                           }).ToList();
            ViewBag.v = values;
            return View();

        }
        [HttpPost]
        public ActionResult CreateParent(Parent p)
        {
            context.Parents.Add(p);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DeleteParent(int id)
        {
            var values = context.Parents.Find(id);
            context.Parents.Remove(values);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult UpdateParent(int id)
        {
            List<SelectListItem> values = (from x in context.Students.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.NameSurname,
                                               Value = x.StudentId.ToString()
                                           }).ToList();
            ViewBag.v = values;
            var value = context.Parents.Find(id);
            return View(value);
        }

        [HttpPost]
        public ActionResult UpdateParent(Parent p)
        {
            var values = context.Parents.Find(p.ParentId);
            values.NameSurname = p.NameSurname;
            values.Phone = p.Phone;
            values.StudentId = p.StudentId;
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}