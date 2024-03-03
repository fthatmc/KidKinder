using KidKinder.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KidKinder.Controllers
{
    public class DashboardController : Controller
    {
        // GET: Dashboard

        KidKinderContext context = new KidKinderContext();
        public ActionResult Index()
        {
			//branşı resim olan öğretmen sayısı
			ViewBag.CizimSınıfı = context.ClassRooms.Where(y => y.Title == "Çizim Sınıfı").Select(z=>z.TotalSeats).FirstOrDefault();
			ViewBag.DilSınıfı = context.ClassRooms.Where(y => y.Title == "Dil Sınıfı").Select(z => z.TotalSeats).FirstOrDefault();
			ViewBag.BilimSınıfı = context.ClassRooms.Where(y => y.Title == "Temel Bilimler").Select(z => z.TotalSeats).FirstOrDefault();

			ViewBag.ToplamMevcut = context.ClassRooms.Sum(z => z.TotalSeats).ToString();

			ViewBag.AvgPrice = context.ClassRooms.Average(x => x.Price).ToString("0.00");

            ViewBag.BranchCount = context.Branchs.Count();
			ViewBag.TeacherCount = context.Teachers.Count();
			ViewBag.BigClassroom = context.ClassRooms.OrderByDescending(x => x.TotalSeats).Select(x => x.Title).FirstOrDefault();
            ViewBag.ServiceCount = context.Services.Count();
            ViewBag.ReferanceCount = context.Testimonials.Count();



			return View();
        }

		public PartialViewResult TeacherList()
        {
            var values = context.Teachers.ToList();
            return PartialView(values);
        }


	}
}