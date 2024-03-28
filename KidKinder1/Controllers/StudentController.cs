using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KidKinder1.Entities;
using KidKinder1.Context;
namespace KidKinder1.Controllers
{
    public class StudentController : Controller
    {
        KidKinderContext context = new KidKinderContext();
        public ActionResult Index()
        {
            var values = context.Students.ToList();
            return View(values);
         
        }
        [HttpGet]
        public ActionResult CreateStudent()
        {
            List<SelectListItem> values = (from x in context.Classrooms.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.Title,
                                               Value = x.ClassroomId.ToString()
                                           }).ToList();
            ViewBag.v = values;
            return View();

        }
        [HttpPost]
        public ActionResult CreateStudent(Student p)
        {
            context.Students.Add(p);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DeleteStudent(int id)
        {
            var values = context.Students.Find(id);
            context.Students.Remove(values);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult UpdateStudent(int id)
        {
            List<SelectListItem> values = (from x in context.Classrooms.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.Title,
                                               Value = x.ClassroomId.ToString()
                                           }).ToList();
            ViewBag.v = values;
            var value = context.Students.Find(id);
            return View(value);
        }

        [HttpPost]
        public ActionResult UpdateStudent(Student p)
        {
            var values = context.Students.Find(p.StudentId);
            values.StudentId = p.StudentId;
            values.NameSurname = p.NameSurname;
            values.Age = p.Age;
            values.Classroom = p.Classroom;
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}