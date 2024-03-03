using KidKinder.Context;
using KidKinder.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KidKinder.Controllers
{
    public class CommunicationController : Controller
    {
		// GET: Communication
		KidKinderContext context = new KidKinderContext();
		public ActionResult Index()
		{
			var values = context.Communications.ToList();
			return View(values);
		}
		[HttpGet]
		public ActionResult CreateCommunication()
		{
			return View();
		}
		[HttpPost]
		public ActionResult CreateCommunication(Communication p)
		{
			context.Communications.Add(p);
			context.SaveChanges();
			return RedirectToAction("Index");
		}

		public ActionResult DeleteCommunication(int id)
		{
			var value = context.Communications.Find(id);
			context.Communications.Remove(value);
			context.SaveChanges();
			return RedirectToAction("Index");
		}

		[HttpGet]
		public ActionResult UpdateCommunication(int id)
		{

			var value = context.Communications.Find(id);
			return View(value);
		}
		[HttpPost]
		public ActionResult UpdateCommunication(Communication p)
		{

			var value = context.Communications.Find(p.CommunicationId);
			value.Decription=p.Decription;
			value.Address=p.Address;
			value.Email=p.Email;
			value.Phone = p.Phone;
			context.SaveChanges();
			return RedirectToAction("Index");
		}
	}
}