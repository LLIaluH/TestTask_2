using System;
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
            ViewBag.Users = us;
            //я надеюсь, что это в данном случае не так важно, что я тяну все пк из бд, просто если бы можно было пользоваться EF я бы сделал по человечески
            //Ну я ещё хотел вариант с Ajax запросом. Но не стал запариваться. Или ещё чуть более мудрённый вариант с SignalR
            var pcs = new PcContext().Get();
            ViewBag.PCs = pcs;
            return View();
        }
    }
}