using KidKinder1.Context;
using KidKinder1.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace KidKinder1.Controllers
{
    public class LoginController : Controller
    {
        KidKinderContext context = new KidKinderContext();
        [HttpGet]
        public ActionResult AdminLogin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AdminLogin(Admin admin)
        {
            var result = context.Admins.FirstOrDefault(x => x.Username == admin.Username && x.Password == admin.Password);
            if (result != null)
            {
                FormsAuthentication.SetAuthCookie(admin.Username, true);
                Session["Username"] = result.Username;
                return RedirectToAction("TeacherList", "Teacher");
            }
            return View();

        }

        public ActionResult AdminLogout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("AdminLogin");
        }

       
    }
}