﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestTask_2.WorkWithDB;

namespace TestTask_2.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var us = new UsersContext().Get();
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}