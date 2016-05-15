using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.Owin.Security.DataHandler.Serializer;
using Model;
using VivesGoal.ViewModel;
using Voetbal.DAO;
using Voetbal.Services;

namespace VivesGoal.Controllers
{
    public class ShoppingCartController : Controller
    {
        private WedstrijdService wedstrijdService;
        private VakService vakService;
       
        public ActionResult Index()
        {
            Cart cart = (Cart) Session["cart"];

            // Return the view
            return View(cart);

        }



        public ActionResult AddToCart(int wedstrijdId, int vakId)
        {
            
            Cart cart = new Cart();
            if (Session != null)
            {
               var temp = (Cart)Session["items"];
                if (temp != null)
                {
                    cart = temp;
                }
            }

            Ticket huidig = new Ticket
            {
                wedstrijdId = Convert.ToInt32(wedstrijdId),
                vakId = Convert.ToInt32(vakId)
            };

            if (cart.Items.Contains(huidig))
            {
                cart.Items[cart.Items.IndexOf(huidig)].aantal++;
            }
            else
            {
                wedstrijdService = new WedstrijdService();
                Wedstrijd wedstrijd = wedstrijdService.Get(Convert.ToInt32(wedstrijdId));
                huidig.wedstrijd = wedstrijd.Club.naam + " - " + wedstrijd.Club1.naam;

                vakService = new VakService();
                Vak vak = vakService.Get(Convert.ToInt32(vakId));
                huidig.vakNaam = vak.naam;
                huidig.prijs = vak.prijs;
                huidig.aantal = 1;

                cart.Items.Add(huidig);
            }

            if (Session != null) Session["items"] = cart;
            if (Request.IsAjaxRequest())
            {
                return PartialView("Shoppingcart");
            }

            return RedirectToAction("Index", "ShoppingCart");
        }

        public ActionResult RemoveFromCart(int wedstrijdId,int vakId)
        {
            Cart cart = new Cart();
            if (Session != null)
            {
                var temp = (Cart) Session["items"];
                if (temp != null)
                {
                    cart = temp;
                }
            }

            wedstrijdService = new WedstrijdService();
            vakService = new VakService();

           Ticket huidig = new Ticket
           {
              wedstrijdId = Convert.ToInt32(wedstrijdId),
              vakId = Convert.ToInt32(vakId)
           };

            if (cart.Items.Contains(huidig))
            {
                cart.Items.Remove(huidig);
            }

            if (Session != null) Session["items"] = cart;

            if (Request.IsAjaxRequest())
            {
                return PartialView("Shoppingcart");
            }

            return RedirectToAction("Index", "ShoppingCart");
        }


        public ActionResult ChangeAmount(int wedstrijdId, int vakId,int change)
        {
            Cart cart = new Cart();
            if (Session != null)
            {
                var temp = (Cart)Session["items"];
                if (temp != null)
                {
                    cart = temp;
                }
            }

            wedstrijdService = new WedstrijdService();
            vakService = new VakService();

            Ticket huidig = new Ticket
            {
                wedstrijdId = Convert.ToInt32(wedstrijdId),
                vakId = Convert.ToInt32(vakId)
            };

          

            if (cart.Items.Contains(huidig))
            {
                int atl = cart.Items[cart.Items.IndexOf(huidig)].aantal;
                if (atl + change <= 0)
                {
                    RemoveFromCart(wedstrijdId, vakId);
                }
                else
                {
                    cart.Items[cart.Items.IndexOf(huidig)].aantal += change;
                }
            }

            if (Session != null) Session["items"] = cart;
            if (Request.IsAjaxRequest())
            {
                return PartialView("Shoppingcart");
            }
            return RedirectToAction("Index", "ShoppingCart");
        }


    }
}

