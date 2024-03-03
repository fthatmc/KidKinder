using KidKinder.Context;
using KidKinder.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KidKinder.Controllers
{
	[AllowAnonymous]
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
		public PartialViewResult PartialAboutList()
		{
			var values = context.AboutLists.ToList();
			return PartialView(values);
		}

		public PartialViewResult PartialClassRooms()
		{
			var values = context.ClassRooms.ToList();
			return PartialView(values);
		}

		[HttpGet]
		public PartialViewResult PartialBookASeat()
		{
            
            return PartialView();
        }
		[HttpPost]
		public PartialViewResult PartialBookASeat(BookASeat p)
		{
			context.BookASeats.Add(p);
			context.SaveChanges();
			return PartialView();
		}

		public PartialViewResult PartialTeacher()
		{
            var values = context.Teachers.ToList();
            return PartialView(values);
        }

		public PartialViewResult PartialTestimonial()
		{
            var values = context.Testimonials.ToList();
            return PartialView(values);
        }
		public PartialViewResult PartialFooter()
		{
			var values = context.Addresses.ToList();
			return PartialView(values);
		}
		public PartialViewResult PartialScript()
		{
			return PartialView();
		}
	}
}