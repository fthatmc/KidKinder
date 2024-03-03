using KidKinder.Context;
using KidKinder.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KidKinder.Controllers
{
    public class TestimonialController : Controller
    {
		// GET: Testimonial
		KidKinderContext context = new KidKinderContext();
		public ActionResult Index()
		{
			var values = context.Testimonials.ToList();
			return View(values);
		}
		[HttpGet]
		public ActionResult CreateTestimonial()
		{
			return View();
		}
		[HttpPost]
		public ActionResult CreateTestimonial(Testimonial p)
		{
			context.Testimonials.Add(p);
			context.SaveChanges();
			return RedirectToAction("Index");
		}

		public ActionResult DeleteTestimonial(int id)
		{
			var value = context.Testimonials.Find(id);
			context.Testimonials.Remove(value);
			context.SaveChanges();
			return RedirectToAction("Index");
		}

		[HttpGet]
		public ActionResult UpdateTestimonial(int id)
		{

			var value = context.Testimonials.Find(id);
			return View(value);
		}
		[HttpPost]
		public ActionResult UpdateTestimonial(Testimonial p)
		{

			var value = context.Testimonials.Find(p.TestimonialId);
			value.Title = p.Title;
			value.ImageUrl = p.ImageUrl;
			value.NameSurname = p.NameSurname;
			value.Comment = p.Comment;
			context.SaveChanges();
			return RedirectToAction("Index");
		}
	}
}