using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KidKinder1.Context;
using KidKinder1.Entities;
namespace KidKinder1.Controllers
{
    [Authorize]
    public class TeacherController : Controller
    {
        KidKinderContext context = new KidKinderContext();
        
        public ActionResult TeacherList()
        {
            var values = context.Teachers.ToList();
            return View(values);
        }
        [HttpGet]
        public ActionResult CreateTeacher()
        {
            List<SelectListItem> values = (from x in context.Branches.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.Name,
                                               Value = x.BranchId.ToString()
                                           }).ToList();
            ViewBag.v = values;                            
            return View();
        }
        [HttpPost]
        public ActionResult CreateTeacher(Teacher p)
        {
           
            context.Teachers.Add(p);
            context.SaveChanges();
            return RedirectToAction("TeacherList");
        }

        public ActionResult DeleteTeacher(int id)
        {
            var values = context.Teachers.Find(id);
            context.Teachers.Remove(values);
            context.SaveChanges();
            return RedirectToAction("TeacherList");
        }

        [HttpGet]
        public ActionResult UpdateTeacher(int id)
        {
            List<SelectListItem> values = (from x in context.Branches.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.Name,
                                               Value = x.BranchId.ToString()
                                           }).ToList();
            ViewBag.v = values;
            var value = context.Teachers.Find(id);
            return View(value);
        }

        [HttpPost]

        public ActionResult UpdateTeacher(Teacher p)
        {
            var value = context.Teachers.Find(p.TeacherId);
            value.BranchId = p.BranchId;
            value.NameSurname = p.NameSurname;
            value.ImageUrl = p.ImageUrl;
            context.SaveChanges();
            return RedirectToAction("TeacherList");

        }
    }
}