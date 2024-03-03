using KidKinder.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KidKinder.Controllers
{
    public class GaleryController : Controller
    {
		// GET: Galery
		KidKinderContext context = new KidKinderContext();
		public ActionResult Index()
        {
            var values = context.Galeries.ToList();
            return View(values);
        }
    }
}