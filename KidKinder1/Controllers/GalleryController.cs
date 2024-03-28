using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KidKinder1.Entities;
using KidKinder1.Context;
namespace KidKinder1.Controllers
{
    public class GalleryController : Controller
    {
        KidKinderContext context = new KidKinderContext();
        public ActionResult Index()
        {
            var values = context.Galleries.Where(x => x.Status == true).ToList();
            return View(values);
        }
        
        public ActionResult AdminGalleryList()
        {
            var values = context.Galleries.ToList();
            return View(values);
        }

        public ActionResult AdminGalleryDelete(int id)
        {
            var values = context.Galleries.Find(id);
            values.Status = false;
            context.SaveChanges();
            return RedirectToAction("AdminGalleryList");
        }
       
    }
}