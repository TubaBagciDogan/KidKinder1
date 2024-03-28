using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KidKinder1.Entities;
using KidKinder1.Context;
namespace KidKinder1.Controllers
{
    public class TestimonialController : Controller
    {
        KidKinderContext context = new KidKinderContext();
        public ActionResult Index()
        {
            var values = context.Testimonials.ToList();
            return View(values);
        }
        public ActionResult DeleteTestimonial(int id)
        {
            var values = context.Testimonials.Find(id);
            context.Testimonials.Remove(values);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult UpdateTestimonial(int id)
        {
            var values = context.Testimonials.Find(id);
            return View(values);
        }
        [HttpPost]
        public ActionResult UpdateTestimonial(Testimonial p)
        {
            var values = context.Testimonials.Find(p.TestimonialId);
            values.NameSurname = p.NameSurname;
            values.ImageUrl = p.ImageUrl;
            values.Title = p.Title;
            values.Comment = p.Comment;
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}