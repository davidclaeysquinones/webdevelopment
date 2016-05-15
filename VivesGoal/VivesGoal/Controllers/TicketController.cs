using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.EnterpriseServices.Internal;
using System.Linq;
using System.Net;
using System.Net.Configuration;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Web;
using System.Web.Configuration;
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
        private UserService userService;


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
        public async Task<ActionResult> Create(int wedstrijdId, int vakId)
        {

            vakService = new VakService();
            ViewBag.VakNr = new SelectList(vakService.All(), "id", "naam");

            var userId = User.Identity.GetUserId();
            klantService = new KlantService();
            ViewBag.klant = klantService.Get(userId);

            zitplaatsService = new ZitplaatsService();
            ZitPlaats zitPlaats = zitplaatsService.GetAvailable(wedstrijdId, vakId);

            wedstrijdService = new WedstrijdService();
            Wedstrijd wedstrijd = wedstrijdService.GetWedstrijd(Convert.ToInt32(wedstrijdId));


            if (zitPlaats != null)
            {
                if (wedstrijd.datum <= DateTime.Now.AddDays(30))
                {
                    Boeking boeking = new Boeking();
                    boeking.Wedstrijd = wedstrijdId;
                    boeking.zitplaats = zitPlaats.id;
                    boeking.klant = userId;

                    boekingService = new BoekingService();

                    try
                    {
                        boekingService.Add(boeking);
                    }
                    catch (Exception)
                    {

                        return new HttpStatusCodeResult(HttpStatusCode.Conflict);
                    }
                    userService = new UserService();
                    AspNetUsers user = userService.Get(userId);


                    var body = "<p>{0}</p>";
                    var message = new MailMessage();
                   // var section = ConfigurationManager.GetSection("system.net/mailSettings/smtp") as SmtpSection;
                    var textmessage = "Beste klant,<br><br>Bedankt voor de aankoop op onze site.<br><br>U heeft het volgende ticket aangekocht : <br>een ticket voor de wedstrijd "+wedstrijd.Club1.naam+"-"+wedstrijd.Club.naam+" op "+wedstrijd.datum.Day+"/"+wedstrijd.datum.Month+"/"+wedstrijd.datum.Year+" voor de prijs van "+zitPlaats.Vak.prijs+" euro.";
                    message.To.Add(new MailAddress(user.Email)); //replace with valid value
                    message.Subject = "Aankoopbevestiging";
                    message.Body = string.Format(body,textmessage);
                    message.IsBodyHtml = true;
                    using (var smtp = new SmtpClient())
                    {
                        await smtp.SendMailAsync(message);

                    }

                }
                else
                {
                    return new HttpStatusCodeResult(HttpStatusCode.MethodNotAllowed);
                }

            }
                
            else
            {
                return new HttpStatusCodeResult(HttpStatusCode.MethodNotAllowed);
            }

            return RedirectToAction("Index", "Home");
        }

        public async Task<ActionResult> CheckoutCart()
        {
            Cart cart;
            try
            {
                cart = (Cart) Session["items"];
            }
            catch (Exception)
            {

                return RedirectToAction("Index", "Home");
            }

            if (cart != null)
            {
                var ticket="";
                wedstrijdService = new WedstrijdService();
                zitplaatsService = new ZitplaatsService();
                var userId = User.Identity.GetUserId();
                foreach (var item in cart.Items)
                {
                    for (int i = 0; i < item.aantal; i++)
                    {
                        Wedstrijd wedstrijd = wedstrijdService.GetWedstrijd(item.wedstrijdId);
                        if (wedstrijd.datum <= DateTime.Now.AddDays(30))
                        {
                            Boeking boeking = new Boeking();
                            boeking.Wedstrijd = item.wedstrijdId;
                            ZitPlaats zitPlaats = zitplaatsService.GetAvailable(item.wedstrijdId, item.vakId);
                            if (zitPlaats != null)
                            {
                                boeking.zitplaats = zitPlaats.id;
                                boeking.klant = userId;

                                boekingService = new BoekingService();

                                try
                                {
                                    boekingService.Add(boeking);                                    
                                }
                                catch (Exception)
                                {

                                    return new HttpStatusCodeResult(HttpStatusCode.Conflict);
                                }
                            }

                        }
                    }
                    wedstrijdService = new WedstrijdService();
                    Wedstrijd huidig = wedstrijdService.Get(item.wedstrijdId);
                    if (item.aantal ==1)
                    {               
                        ticket += "een ticket gekocht voor de wedstrijd " + item.wedstrijd + " op " +
                            huidig.datum.Day + "/" + huidig.datum.Month + "/" + huidig.datum.Year+"<br>";
                    }
                    else
                    {
                        ticket+=item.aantal +" tickets gekocht voor de wedstrijd " + item.wedstrijd + " op " +
                            huidig.datum.Day + "/" + huidig.datum.Month + "/" + huidig.datum.Year + "<br>";
                    }  
                }
                Session["items"] = null;
                var body = "<p>{0}</p>";
                userService = new UserService();
                AspNetUsers user = userService.Get(userId);
                var message = new MailMessage();
                // var section = ConfigurationManager.GetSection("system.net/mailSettings/smtp") as SmtpSection;
                var textmessage = "Beste klant,<br><br>Bedankt voor de aankoop op onze site.<br><br>U heeft de volgende tickets aangekocht : <br>"+ticket;
                message.To.Add(new MailAddress(user.Email)); //replace with valid value
                message.Subject = "Aankoopbevestiging";
                message.Body = string.Format(body, textmessage);
                message.IsBodyHtml = true;
                using (var smtp = new SmtpClient())
                {
                    await smtp.SendMailAsync(message);

                }
            }
            return RedirectToAction("Index", "Home");
        }

    }
}
