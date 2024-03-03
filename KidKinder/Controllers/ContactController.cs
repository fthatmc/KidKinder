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
    public class ContactController : Controller
    {
       

        KidKinderContext context = new KidKinderContext();
        public ActionResult Index()
        {
            return View();
        }
		public ActionResult AdminIndex()
		{
			var values = context.Contacts.ToList();
			return PartialView(values);
		}

		public ActionResult DeleteContact(int id)
		{
			var value = context.Contacts.Find(id);
			context.Contacts.Remove(value);
			context.SaveChanges();
			return RedirectToAction("AdminIndex");
		}
		public PartialViewResult ContactHeaderPartial()
        {
            return PartialView();
        }

        public PartialViewResult ContactAddressPartial()
        {
            var values = context.Addresses.ToList();
            return PartialView(values);
        }

		[HttpGet]
		public PartialViewResult CreateMessage()
		{
			return PartialView();
		}
		[HttpPost]
		public PartialViewResult CreateMessage(Contact p)
		{
			context.Contacts.Add(p);
            p.SendDate = DateTime.Now;
            p.IsRead = false;
			context.SaveChanges();
			return PartialView();
		}

		public ActionResult ContactStatusToFalse(int id)
		{
			Contact c = context.Contacts.Find(id);
			c.IsRead = false;
			context.SaveChanges();
			return RedirectToAction("AdminIndex");


		}

		public ActionResult ContactStatusToTrue(int id)
		{
			Contact c = context.Contacts.Find(id);
			c.IsRead = true;
			context.SaveChanges();
			return RedirectToAction("AdminIndex");
		}

	}
}