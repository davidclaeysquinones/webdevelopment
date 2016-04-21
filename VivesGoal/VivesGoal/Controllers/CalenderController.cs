using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model;
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
        
            IEnumerable<Wedstrijd> wedstrijden = wedstrijdService.All();
            ViewBag.ClubId = new SelectList(clubService.All(), "id","naam");
            return View(wedstrijden);
        }

        // GET: Calender/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Calender/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Calender/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Calender/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Calender/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Calender/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Calender/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
