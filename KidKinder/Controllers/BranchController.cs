using KidKinder.Context;
using KidKinder.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KidKinder.Controllers
{
    public class BranchController : Controller
    {
		// GET: Branch
		KidKinderContext context = new KidKinderContext();
		public ActionResult Index()
		{
			var values = context.Branchs.ToList();
			return View(values);
		}
		[HttpGet]
		public ActionResult CreateBranch()
		{
			return View();
		}
		[HttpPost]
		public ActionResult CreateBranch(Branch p)
		{
			context.Branchs.Add(p);
			context.SaveChanges();
			return RedirectToAction("Index");
		}

		public ActionResult DeleteBranch(int id)
		{
			var value = context.Branchs.Find(id);
			context.Branchs.Remove(value);
			context.SaveChanges();
			return RedirectToAction("Index");
		}

		[HttpGet]
		public ActionResult UpdateBranch(int id)
		{

			var value = context.Branchs.Find(id);
			return View(value);
		}
		[HttpPost]
		public ActionResult UpdateBranch(Branch p)
		{

			var value = context.Branchs.Find(p.BranchId);
			value.Name = p.Name;
			context.SaveChanges();
			return RedirectToAction("Index");
		}
	}
}