using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
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
        private KlantService klantService;


        // GET: Ticket/Create
        public ActionResult Create(int wedstrijdId)
        {
            //if (id == null)
            //{
            //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "er is iets fout gelopen");
            //}

            wedstrijdService = new WedstrijdService();
            Wedstrijd wedstrijd = wedstrijdService.GetWedstrijd(Convert.ToInt32(wedstrijdId));
            if (wedstrijd == null)
            {
                return HttpNotFound();
            }

            vakService = new VakService();
            ViewBag.VakNr = new SelectList(vakService.All(), "id", "naam");

            //zitplaatsService = new ZitplaatsService();
            //ViewBag.ZitPlaats = new SelectList(zitplaatsService.All(), "ZitplaatsId","VakNaam");

            var userId = User.Identity.GetUserId();
            klantService = new KlantService();
            ViewBag.klant = klantService.Get(userId);



            return View(wedstrijd);
        }


        [HttpPost]
        public ActionResult Create(int wedstrijdId, int vakId)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    // return RedirectToAction("Index");
                }


            }
            catch (DataException ex)
            {
                ModelState.AddModelError("", "administrator");

            }

            vakService = new VakService();
            ViewBag.VakNr = new SelectList(vakService.All(), "id", "naam");

            var userId = User.Identity.GetUserId();
            klantService = new KlantService();
            ViewBag.klant = klantService.Get(userId);

            ZitplaatsService zitplaatsService = new ZitplaatsService();
            ViewBag.Zitplaats = zitplaatsService.GetAvailable(wedstrijdId, vakId);

            wedstrijdService = new WedstrijdService();
            Wedstrijd wedstrijd = wedstrijdService.GetWedstrijd(Convert.ToInt32(wedstrijdId));

            return View(wedstrijd);
        }

    }
}
