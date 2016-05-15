using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Model;
using Voetbal.Services;

namespace VivesGoal.Controllers
{
    public class StadionController : Controller
    {
        
        private StadionService stadionService;
        public StadionController()
        {
            
        }

        // GET: Stadion
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ListForm()
        {
            stadionService = new StadionService();
            ViewBag.StadionId = new SelectList(stadionService.All(),"id","naam");

            return View(stadionService.All());
        }

        [HttpPost] //lijst van stadion wordt naar deze methode teruggestuurd
        public ActionResult ListForm(int ?stadionId)
        {
            if (stadionId == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            stadionService = new StadionService();
            ViewBag.StadionId = new SelectList(stadionService.All(), "id", "naam");

            var stadion = stadionService.Get(Convert.ToInt32(stadionId));
            IEnumerable<Stadion> stadions = new List<Stadion>{ stadion };

       
       
            return View(stadions);
        }


        }
    
    }


