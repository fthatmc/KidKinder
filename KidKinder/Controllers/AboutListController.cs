using KidKinder.Context;
using KidKinder.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KidKinder.Controllers
{
    public class AboutListController : Controller
    {
		// GET: AboutList
		KidKinderContext context = new KidKinderContext();
		public ActionResult Index()
		{
			var values = context.AboutLists.ToList();
			return View(values);
		}
		[HttpGet]
		public ActionResult CreateAboutList()
		{
			return View();
		}
		[HttpPost]
		public ActionResult CreateAboutList(AboutList about)
		{
			context.AboutLists.Add(about);
			context.SaveChanges();
			return RedirectToAction("Index");
		}

		public ActionResult DeleteAboutList(int id)
		{
			var value = context.AboutLists.Find(id);
			context.AboutLists.Remove(value);
			context.SaveChanges();
			return RedirectToAction("Index");
		}

		[HttpGet]
		public ActionResult UpdateAboutList(int id)
		{

			var value = context.AboutLists.Find(id);
			return View(value);
		}
		[HttpPost]
		public ActionResult UpdateAboutList(AboutList about)
		{

			var value = context.AboutLists.Find(about.AboutListId);
			value.Description = about.Description;
			context.SaveChanges();
			return RedirectToAction("Index");
		}
	}
}