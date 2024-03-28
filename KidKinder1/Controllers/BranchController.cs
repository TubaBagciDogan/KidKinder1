using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KidKinder1.Entities;
using KidKinder1.Context;
namespace KidKinder1.Controllers
{
    public class BranchController : Controller
    {
        KidKinderContext context = new KidKinderContext();

        public ActionResult Index()
        {
            var values = context.Branches.ToList();
            return View(values);
        }
        [HttpGet]
        public ActionResult CreateBranch()
        {
            return View();
        }
        public ActionResult CreateBranch(Branch p)
        {
            context.Branches.Add(p);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DeleteBranch(int id)
        {
            var values = context.Branches.Find(id);
            context.Branches.Remove(values);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult UpdateBranch(int id)
        {
            var values = context.Branches.Find(id);
            return View(values);
        }

        [HttpPost]
        public ActionResult UpdateBranch(Branch p)
        {
            var values = context.Branches.Find(p.BranchId);
            values.Name = p.Name;
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}