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
            stadionService = new StadionService();
        }

        // GET: Stadion
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ListForm()
        {
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
            ViewBag.StadionId = new SelectList(stadionService.All(), "id", "naam");

            var stadion = stadionService.Get(Convert.ToInt32(stadionId));
            IEnumerable<Stadion> stadions = new List<Stadion>{ stadion };

       
       
            return View(stadions);
        }

        // GET: Stadion/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Stadion/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Stadion/Create
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

        // GET: Stadion/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Stadion/Edit/5
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

        // GET: Stadion/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Stadion/Delete/5
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
