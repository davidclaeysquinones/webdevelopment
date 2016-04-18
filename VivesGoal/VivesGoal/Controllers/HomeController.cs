using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model;
using Voetbal.DAO;
using Voetbal.Services;

namespace VivesGoal.Controllers
{
    public class HomeController : Controller
    {

        private StadionDAO stadionDao;

        public HomeController() 
        {
            stadionDao=new StadionDAO();
        }

        public ActionResult Index()
        {

            var stadionlist = stadionDao.All();
            return View(stadionlist);
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