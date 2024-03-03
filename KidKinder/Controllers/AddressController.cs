using KidKinder.Context;
using KidKinder.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KidKinder.Controllers
{
    public class AddressController : Controller
    {
		
		// GET: Address
		KidKinderContext context = new KidKinderContext();
		public ActionResult Index()
		{
			var values = context.Addresses.ToList();
			return View(values);
		}
		[HttpGet]
		public ActionResult CreateAddress()
		{
			return View();
		}
		[HttpPost]
		public ActionResult CreateAddress(Address p)
		{
			context.Addresses.Add(p);
			context.SaveChanges();
			return RedirectToAction("Index");
		}

		public ActionResult DeleteAddress(int id)
		{
			var value = context.Addresses.Find(id);
			context.Addresses.Remove(value);
			context.SaveChanges();
			return RedirectToAction("Index");
		}

		[HttpGet]
		public ActionResult UpdateAddress(int id)
		{

			var value = context.Addresses.Find(id);
			return View(value);
		}
		[HttpPost]
		public ActionResult UpdateAddress(Address p)
		{

			var value = context.Addresses.Find(p.AddressID);
			value.Description = p.Description;
			value.AddressDetail = p.AddressDetail;
			value.Email = p.Email;
			value.Phone = p.Phone;
			value.OpeningHours = p.OpeningHours;
			context.SaveChanges();
			return RedirectToAction("Index");
		}
	}
}