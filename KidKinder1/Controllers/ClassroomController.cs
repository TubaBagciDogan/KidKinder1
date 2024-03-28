using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KidKinder1.Entities;
using KidKinder1.Context;
namespace KidKinder1.Controllers
{
    public class ClassroomController : Controller
    {
        KidKinderContext context = new KidKinderContext();
        public ActionResult Index()
        {
            var values = context.Classrooms.ToList();
            return View(values);
        }
        [HttpGet]
        public ActionResult CreateClassRoom()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateClassRoom(Classroom p)
        {
            context.Classrooms.Add(p);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DeleteClassRoom(int id)
        {
            var value = context.Classrooms.Find(id);
            context.Classrooms.Remove(value);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult UpdateClassRoom(int id)
        {
            var values = context.Classrooms.Find(id);
            return View(values);
        }
        [HttpPost]
        public ActionResult UpdateClassRoom(Classroom p)
        {
            var values = context.Classrooms.Find(p.ClassroomId);
            values.Title = p.Title;
            values.Description = p.Description;
            values.AgeofKids = p.AgeofKids;
            values.TotalSeat = p.TotalSeat;
            values.ClassTime = p.ClassTime;
            values.Price = p.Price;
            values.ImageUrl = p.ImageUrl;
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}