using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
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


            if (wedstrijd.datum <= DateTime.Now.AddDays(30))
            {
                return View(wedstrijd);
            }
            else
            {
                return new HttpStatusCodeResult(HttpStatusCode.MethodNotAllowed);
            }

        }


        [HttpPost]
        public ActionResult Create(int wedstrijdId, int vakId)
        {

            vakService = new VakService();
            ViewBag.VakNr = new SelectList(vakService.All(), "id", "naam");

            var userId = User.Identity.GetUserId();
            klantService = new KlantService();
            ViewBag.klant = klantService.Get(userId);

            ZitplaatsService zitplaatsService = new ZitplaatsService();
            ZitPlaats zitPlaats = zitplaatsService.GetAvailable(wedstrijdId, vakId);

            wedstrijdService = new WedstrijdService();
            Wedstrijd wedstrijd = wedstrijdService.GetWedstrijd(Convert.ToInt32(wedstrijdId));

         

            if (wedstrijd.datum <= DateTime.Now.AddDays(30))
            {
                Boeking boeking = new Boeking();
                boeking.Wedstrijd = wedstrijdId;
                boeking.zitplaats = zitPlaats.id;
                boeking.klant = userId;
                
                boekingService = new BoekingService();

                //try
                //{
                    boekingService.Add(boeking);
                //}
                //catch (Exception )
                //{

                //    return new HttpStatusCodeResult(HttpStatusCode.Conflict);
                //}
                    
                }
               
            else
            {
                return new HttpStatusCodeResult(HttpStatusCode.MethodNotAllowed);
            }

            return RedirectToAction("Index", "Home");
        }

    }
}
