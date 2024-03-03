using KidKinder.Context;
using KidKinder.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KidKinder.Controllers
{
    public class NotificationController : Controller
    {
		// GET: Notification
		KidKinderContext context = new KidKinderContext();
		public ActionResult Index()
		{
			var values = context.Notifications.ToList();
			return View(values);
		}
		[HttpGet]
		public ActionResult CreateNotification()
		{
			return View();
		}
		[HttpPost]
		public ActionResult CreateNotification(Notification p)
		{
			p.Status = false;
			context.Notifications.Add(p);
			context.SaveChanges();
			return RedirectToAction("Index");
		}

		public ActionResult DeleteNotification(int id)
		{
			var value = context.Notifications.Find(id);
			context.Notifications.Remove(value);
			context.SaveChanges();
			return RedirectToAction("Index");
		}

		[HttpGet]
		public ActionResult UpdateNotification(int id)
		{

			var value = context.Notifications.Find(id);
			return View(value);
		}
		[HttpPost]
		public ActionResult UpdateNotification(Notification p)
		{

			var value = context.Notifications.Find(p.NotificationId);
			value.Title = p.Title;
			value.Description = p.Description;
			value.NotificationDate = p.NotificationDate;
			value.ImageUrl = p.ImageUrl;
			context.SaveChanges();
			return RedirectToAction("Index");
		}

		public ActionResult NotificationStatusToFalse(int id)
		{
			Notification c = context.Notifications.Find(id);
			c.Status = false;
			context.SaveChanges();
			return RedirectToAction("Index");


		}

		public ActionResult NotificationStatusToTrue(int id)
		{
			Notification c = context.Notifications.Find(id);
			c.Status = true;
			context.SaveChanges();
			return RedirectToAction("Index");
		}
	}
}