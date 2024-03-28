using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KidKinder1.Entities;
using KidKinder1.Context;

namespace KidKinder1.Controllers
{
    public class SocialMediaController : Controller
    {
        KidKinderContext context = new KidKinderContext();
        public ActionResult Index()
        {
            var values = context.SocialMedias.ToList();
            return View(values);
        }
        [HttpGet]
        public ActionResult CreateSocialMedia()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateSocialMedia(SocialMedia p)
        {
            context.SocialMedias.Add(p);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DeleteSocialMedia(int id)
        {
            var values = context.SocialMedias.Find(id);
            context.SocialMedias.Remove(values);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult UpdateSocialMedia(int id)
        {
            var values = context.SocialMedias.Find(id);
            return View(values);
        }

        [HttpPost]
        public ActionResult UpdateSocialMedia(SocialMedia p)
        {
            var values = context.SocialMedias.Find(p.SocialMediaId);
            values.Name = p.Name;
            values.Url = p.Url;
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}