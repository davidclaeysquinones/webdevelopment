using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model;
using Voetbal.Services;

namespace VivesGoal.Controllers
{
    [Authorize]
    public class TicketController : Controller
    {
        private BoekingService boekingService;
        private WedstrijdService wedstrijdService;
        private ZitplaatsService zitplaatsService;
        private VakService vakService;
        // GET: Ticket
        public ActionResult Index()
        {
            return View();
        }

        // GET: Ticket/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Ticket/Create
        public ActionResult Create(int? id)
        {
            //if (id == null)
            //{
            //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "er is iets fout gelopen");
            //}

            wedstrijdService = new WedstrijdService();
            Wedstrijd wedstrijd = wedstrijdService.GetWedstrijd(Convert.ToInt32(id));
            if (wedstrijd == null)
            {
                return HttpNotFound();
            }

            vakService = new VakService();
            ViewBag.VakNr = new SelectList(vakService.All(), "id", "naam");

            //zitplaatsService = new ZitplaatsService();
            //ViewBag.ZitPlaats = new SelectList(zitplaatsService.All(), "ZitplaatsId","VakNaam");

            //var userId = User.Identity.GetUserId();




            return View(wedstrijd);
        }

        // POST: Ticket/Create
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

        // GET: Ticket/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Ticket/Edit/5
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

        // GET: Ticket/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Ticket/Delete/5
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
