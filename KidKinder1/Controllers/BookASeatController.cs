using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KidKinder1.Context;
using KidKinder1.Entities;
namespace KidKinder1.Controllers
{
    public class BookASeatController : Controller
    {
        KidKinderContext contex = new KidKinderContext();
        public ActionResult Index()
        {
            var values = contex.BookASeats.ToList();
            return View(values);
        }
        
    }
}