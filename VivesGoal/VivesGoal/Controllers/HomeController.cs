﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model;
using Voetbal.DAO;
using Voetbal.Services;

namespace VivesGoal.Controllers
{
    public class HomeController : Controller
    {


        public HomeController() 
        {

        }

        public ActionResult Index()
        {


        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}