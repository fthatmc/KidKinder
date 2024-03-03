using KidKinder.Context;
using KidKinder.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KidKinder.Controllers
{
    public class FeatureController : Controller
    {
		// GET: Feature
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
			var value = context.Features.Find(id);
			context.Features.Remove(value);
			context.SaveChanges();
			return RedirectToAction("Index");
		}

		[HttpGet]
		public ActionResult UpdateFeature(int id)
		{

			var value = context.Features.Find(id);
			return View(value);
		}
		[HttpPost]
		public ActionResult UpdateFeature(Feature p)
		{

			var value = context.Features.Find(p.FeatureId);
			value.Title = p.Title;
			value.Description = p.Description;
			value.Header = p.Header;
			value.ImageURL = p.ImageURL;
			context.SaveChanges();
			return RedirectToAction("Index");
		}
	}
}