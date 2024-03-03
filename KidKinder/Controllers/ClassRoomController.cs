using KidKinder.Context;
using KidKinder.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KidKinder.Controllers
{
    public class ClassRoomController : Controller
    {
		// GET: ClassRoom
		KidKinderContext context = new KidKinderContext();
		public ActionResult Index()
		{
			var values = context.ClassRooms.ToList();
			return View(values);
		}
		[HttpGet]
		public ActionResult CreateClassRoom()
		{
			return View();
		}
		[HttpPost]
		public ActionResult CreateClassRoom(ClassRoom p)
		{
			context.ClassRooms.Add(p);
			context.SaveChanges();
			return RedirectToAction("Index");
		}

		public ActionResult DeleteClassRoom(int id)
		{
			var value = context.ClassRooms.Find(id);
			context.ClassRooms.Remove(value);
			context.SaveChanges();
			return RedirectToAction("Index");
		}

		[HttpGet]
		public ActionResult UpdateClassRoom(int id)
		{

			var value = context.ClassRooms.Find(id);
			return View(value);
		}
		[HttpPost]
		public ActionResult UpdateClassRoom(ClassRoom p)
		{

			var value = context.ClassRooms.Find(p.ClassRoomId);
			value.Title = p.Title;
			value.Description = p.Description;
			value.ImageUrl = p.ImageUrl;
			value.AgeOfKids = p.AgeOfKids;
			value.TotalSeats = p.TotalSeats;
			value.ClassTime = p.ClassTime;
			value.Price = p.Price;
			context.SaveChanges();
			return RedirectToAction("Index");
		}
	}
}