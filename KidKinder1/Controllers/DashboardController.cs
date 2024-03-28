using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KidKinder1.Context;
using KidKinder1.Entities;
namespace KidKinder1.Controllers
{
    public class DashboardController : Controller
    {
        KidKinderContext context = new KidKinderContext();
        public ActionResult Index()
        {
            //BraNşı resim çizzme olan öğretmen sayısı

            ViewBag.GuzelSanatlarCount = context.Teachers.Where(x => x.BranchId == context.Branches.Where(z => z.Name == "Güzel Sanatlar").Select(y => y.BranchId).FirstOrDefault()).Count();
            ViewBag.AvgPrice = context.Classrooms.Average(x => x.Price).ToString("0.00");
            ViewBag.BranchesCount = context.Branches.Count();
            ViewBag.MessagesCount = context.Contacts.Count();
            ViewBag.ServicesCount = context.Services.Count();
            ViewBag.ClassroomCount = context.Classrooms.Count();
            ViewBag.NotificaitonCount = context.Notifications.Count();
           ViewBag.RobotikKodlamaCount= context.Teachers.Where(x => x.BranchId == context.Branches.Where(z => z.Name == "Kodlama").Select(y => y.BranchId).FirstOrDefault()).Count();
            ViewBag.TestimonialCount = context.Testimonials.Count();
            ViewBag.StudentCount = context.Students.Count();
            ViewBag.PictureCount = context.Galleries.Count();
            ViewBag.MailSubscribes = context.MailSubscribes.Count();
            ViewBag.TeacherCount = context.Teachers.Count();
            ViewBag.ProdigesCount = context.Teachers.Where(x => x.BranchId == context.Branches.Where(z => z.Name == "Prodiges").Select(y => y.BranchId).FirstOrDefault()).Count();
            ViewBag.chart1 = context.Students.Where(x => x.ClassroomId == 1).Count().ToString();
            ViewBag.chart2 = context.Students.Where(x => x.ClassroomId == 2).Count().ToString();
            ViewBag.chart3 = context.Students.Where(x => x.ClassroomId == 4).Count().ToString();
            ViewBag.chart4 = context.Students.Where(x => x.ClassroomId == 5).Count().ToString();
            ViewBag.chart5 = context.Students.Where(x => x.ClassroomId == 6).Count().ToString();
            ViewBag.chart6 = context.Students.Where(x => x.ClassroomId == 7).Count().ToString();
            ViewBag.chart7 = context.Students.Where(x => x.ClassroomId == 8).Count().ToString();
            ViewBag.chart8 = context.Students.Where(x => x.ClassroomId == 9).Count().ToString();
           
            return View();
        }
    }
}