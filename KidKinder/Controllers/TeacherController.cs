﻿using KidKinder.Context;
using KidKinder.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KidKinder.Controllers
{
    
    public class TeacherController : Controller
    {
        KidKinderContext context = new KidKinderContext();
        public ActionResult TeacherList()
        {
            var values = context.Teachers.ToList();
            return View(values);
        }
        [HttpGet]
        public ActionResult CreateTeacher()
        {
            List<SelectListItem> values = (from x in context.Branchs.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.Name,
                                               Value= x.BranchId.ToString(),
                                           }).ToList();
            ViewBag.v = values;
            return View();
        }
        [HttpPost]
        public ActionResult CreateTeacher(Teacher teacher)
        {
            context.Teachers.Add(teacher);
            context.SaveChanges();
            return RedirectToAction("TeacherList");
        }

        public ActionResult DeleteTeacher(int id)
        {
            var value = context.Teachers.Find(id);
            context.Teachers.Remove(value);
            context.SaveChanges();
            return RedirectToAction("TeacherList");
        }

        [HttpGet]
        public ActionResult UpdateTeacher(int id)
        {
			

			List<SelectListItem> values = (from x in context.Branchs.ToList()
										   select new SelectListItem
										   {
											   Text = x.Name,
											   Value = x.BranchId.ToString(),
										   }).ToList();
			ViewBag.v = values;
			var value = context.Teachers.Find(id);
			return View(value);
        }
        [HttpPost]
        public ActionResult UpdateTeacher(Teacher teacher)
        {

            var value = context.Teachers.Find(teacher.TeacherId);
            value.BranchId= teacher.BranchId;
            value.NameSurname = teacher.NameSurname;
            value.ImageUrl = teacher.ImageUrl;
            context.SaveChanges();
            return RedirectToAction("TeacherList");
        }
    }
}