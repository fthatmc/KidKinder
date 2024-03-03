using KidKinder.Context;
using KidKinder.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KidKinder.Controllers
{
    public class AdminController : Controller
    {
		// GET: Admin
		KidKinderContext context = new KidKinderContext();
		public ActionResult Index()
		{
			var values = context.Admins.ToList();
			return View(values);
		}
		[HttpGet]
		public ActionResult CreateAdmin()
		{
			return View();
		}
		[HttpPost]
		public ActionResult CreateAdmin(Admin p)
		{
			context.Admins.Add(p);
			context.SaveChanges();
			return RedirectToAction("Index");
		}

		public ActionResult DeleteAdmin(int id)
		{
			var value = context.Admins.Find(id);
			context.Admins.Remove(value);
			context.SaveChanges();
			return RedirectToAction("Index");
		}

		[HttpGet]
		public ActionResult UpdateAdmin(int id)
		{

			var value = context.Admins.Find(id);
			return View(value);
		}
		[HttpPost]
		public ActionResult UpdateAdmin(Admin p)
		{

			var value = context.Admins.Find(p.AdminId);
			value.UserName = p.UserName;
			value.Password = p.Password;
			context.SaveChanges();
			return RedirectToAction("Index");
		}
	}
}