using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace VivesGoal.Controllers
{
    public class IntroductieController : Controller
    {
        // GET: Introductie
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Meer info over de site.";

            return View();
        }

        public ActionResult Ticket()
        {
            ViewBag.Message = "Tickets Bestellen.";

            return View();
        }
    }
}