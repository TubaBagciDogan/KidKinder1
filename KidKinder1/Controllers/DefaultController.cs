using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KidKinder1.Entities;
using KidKinder1.Context;
namespace KidKinder1.Controllers
{
    public class DefaultController : Controller
    {
        KidKinderContext context = new KidKinderContext();
        public ActionResult Index()
        {
            
            return View();
        }
        
        public PartialViewResult PartialHead()
        {
            return PartialView();
        }
        public PartialViewResult PartialNavbar()
        {
            return PartialView();
        }
        public PartialViewResult PartialFeature()
        {
            var values = context.Features.ToList();
            return PartialView(values);
        }
        public PartialViewResult PartialService()
        {
            var values = context.Services.ToList();
            return PartialView(values);
        }
        public PartialViewResult PartialAbout()
        {
            var values = context.Abouts.ToList();
            return PartialView(values);
        }
        public PartialViewResult PartialClassRooms()
        {
            var values = context.Classrooms.Take(3).OrderByDescending(x => x.ClassroomId).ToList();
            return PartialView(values);
        }
        [HttpGet]
        public PartialViewResult PartialBookASeat()
        {
            
            List<SelectListItem> values = (from x in context.Classrooms.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.Title,
                                               Value = x.ClassroomId.ToString()

                                           }).ToList();
            ViewBag.v = values;
            
            return PartialView();
        }
        [HttpPost]
        public ActionResult PartialBookASeat(BookASeat p)
        {
            context.BookASeats.Add(p);
            context.SaveChanges();
            List<SelectListItem> values = (from x in context.Classrooms.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.Title,
                                               Value = x.ClassroomId.ToString()

                                           }).ToList();
            ViewBag.v = values;
            return RedirectToAction("Index");
            
        }
        public PartialViewResult PartialTeacher()
        {
            var values = context.Teachers.Take(4).ToList();
            return PartialView(values);
        }
        public PartialViewResult PartialTestimonial()
        {
            var values = context.Testimonials.ToList();
            return PartialView(values);
        }
        [HttpGet]
        public PartialViewResult PartialFooter()
        {
            ViewBag.description = context.Communications.Select(x => x.Description).FirstOrDefault();
            ViewBag.address = context.Communications.Select(x => x.Address).FirstOrDefault();
            ViewBag.email = context.Communications.Select(x => x.Email).FirstOrDefault();
            ViewBag.phone = context.Communications.Select(x => x.Phone).FirstOrDefault();
            return PartialView();
        }
        [HttpPost]
        public ActionResult MailSubscribe(MailSubscribe p)
        {
            context.MailSubscribes.Add(p);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        public PartialViewResult PartialScript()
        {
            return PartialView();
        }
        public ActionResult PartialAboutList()
        {
            var values = context.AboutLists.ToList();
            return PartialView(values);
        }
        public ActionResult ClassroomAllList()
        {
            var values = context.Classrooms.ToList();
            return View(values);
        }
    }
}