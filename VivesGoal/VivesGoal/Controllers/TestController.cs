using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Voetbal.Services;
using Voetbal.DAO;

namespace VivesGoal.Controllers
{
    public class TestController : Controller
    {
        private StadionService stadionService;

        public TestController()
        {
            stadionService = new StadionService();
        }
        // GET: Test
        public ActionResult Index()
        {
         
            var stadions = stadionService.All();
            return View(stadions);
        }
    }
}