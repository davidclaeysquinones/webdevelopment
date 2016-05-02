using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Model;
using VivesGoal.ViewModel;
using Voetbal.Services;

namespace VivesGoal.Controllers
{
    public class CalenderController : Controller
    {
        private WedstrijdService wedstrijdService;
        private ClubService clubService;

        public CalenderController()
        {
            wedstrijdService = new WedstrijdService();
            clubService = new ClubService();
        }

        // GET: Calender
        public ActionResult Index()
        {

            ViewBag.ClubId = new SelectList(clubService.All(), "id", "naam");
            IEnumerable<Wedstrijd> wedstrijden = wedstrijdService.Get(DateTime.Now);

           

            return View(wedstrijden);
        }

        [HttpPost]
        public ActionResult Index(int id, string dateField1, string dateField2)
        {
            if (id == null || dateField1 == null || dateField2 == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }


            DateTime date1;
            DateTime date2;
            try
            {
                date1 = DateTime.ParseExact(Convert.ToString(dateField1).Substring(0, 15), "ddd MMM dd yyyy",
                    System.Globalization.CultureInfo.InvariantCulture);
                date2 = DateTime.ParseExact(Convert.ToString(dateField2).Substring(0, 15), "ddd MMM dd yyyy",
                    System.Globalization.CultureInfo.InvariantCulture);
            }
            catch (FormatException e)
            {
                Trace.WriteLine(e.Message);
                return new HttpStatusCodeResult(HttpStatusCode.MethodNotAllowed);
            }
            DateTime current = new DateTime(DateTime.Now.Year,DateTime.Now.Month,DateTime.Now.Day);

            if (date1 < current)
            {
                return new HttpStatusCodeResult(HttpStatusCode.MethodNotAllowed);
            }

            if (date1 > date2)
            {
                return new HttpStatusCodeResult(HttpStatusCode.MethodNotAllowed);
            }

            if (date2 < date1)
            {
                return new HttpStatusCodeResult(HttpStatusCode.MethodNotAllowed);
            }

            IEnumerable<Wedstrijd> wedstrijden = wedstrijdService.Get(Convert.ToInt16(id), date1, date2);
            ViewBag.ClubId = new SelectList(clubService.All(), "id", "naam");
            ViewBag.Begindatum = dateField1;
            ViewBag.EindDatum = dateField2;

            return View(wedstrijden);
        }



    }
}
