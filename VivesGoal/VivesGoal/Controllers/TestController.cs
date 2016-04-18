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
    public class TestController : Controller
    {
        private StadionService stadionService;

        public TestController()
        {
            stadionService = new StadionService();
        }
        // GET: Test
        public ActionResult Index()
        {
            var stadions = stadionService.All();
            return View(stadions);
        }

        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Beer/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Beer/Edit/5
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

        // GET: Beer/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Beer/Delete/5
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