using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KidKinder1.Entities;
using KidKinder1.Context;
namespace KidKinder1.Controllers
{
    public class FeatureController : Controller
    {
        KidKinderContext context = new KidKinderContext();
        public ActionResult Index()
        {
            var values = context.Features.ToList();
            return View(values);
        }
        [HttpGet]
        public ActionResult CreateFeature()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateFeature(Feature p)
        {
            context.Features.Add(p);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DeleteFeature(int id)
        {
            var values = context.Features.Find(id);
            context.Features.Remove(values);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult UpdateFeature(int id)
        {
            var values = context.Features.Find(id);
            return View(values);
        }

        [HttpPost]
        public ActionResult UpdateFeature(Feature p)
        {
            var values = context.Features.Find(p.FeatureId);
            values.Title = p.Title;
            values.Header = p.Header;
            values.Description = p.Description;
            values.ImageUrl = p.ImageUrl;
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}