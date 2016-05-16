using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model;
using Voetbal.Services;

namespace VivesGoal.Controllers
{
    public class ClubController : Controller
    {
        private ClubService clubService;
        // GET: Club
        public ActionResult Index()
        {
            clubService=new ClubService();

            return View(clubService.All());
        }

        // GET: Club/Details/5
        public ActionResult Details(int id)
        {
            clubService = new ClubService();
            Club club = clubService.Get(id);
            if (club != null)
            {
                return View(club);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
            
        }

      
        }
    }

