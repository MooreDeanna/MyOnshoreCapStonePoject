using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PresentationLayer.Models;
using DataAccessLayer;

namespace PresentationLayer.Controllers
{
    public class StatsController : Controller
    {        
            //Mappers
            static PLMapper _mapper = new PLMapper();
            static DataAccess _StatDataAccess = new DataAccess();

            // GET: Stats
            public ActionResult Index()
            {
                return View();
            }
        //Adding Stats
        [HttpPost]
        public ActionResult StatsAdd(StatsModel _AddStats)
        {
            if (ModelState.IsValid)
            {
                _StatDataAccess.AddStats(_mapper.Map(_AddStats));
                return RedirectToAction("Index", "Home");
            }
            return View();
        }
        [HttpGet]
        public ActionResult AddInput()
        {
            StatsModel _Stats = new StatsModel();
            return View(_Stats);

        }
        //Update Team Information
        [HttpPost]
        public ActionResult StatsUpdate(StatsModel _UpdateStats)
        {
            if (ModelState.IsValid)
            {
                _UpdateStats.FKPlayerName = (string)Session["FKPlayerName"];
                _StatDataAccess.UpdateStats(_mapper.Map(_UpdateStats));
                return RedirectToAction("Index", "Home");
            }
            return View();
        }
        [HttpGet]
        public ActionResult StatsUpdate()
        {
            StatsModel _UpdateStats = new StatsModel();
            return View(_UpdateStats);

        }
    }
}
