using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PresentationLayer.Models;
using DataAccessLayer;
using LogicLayer;

namespace PresentationLayer.Controllers
{
    public class StatsController : Controller
    {        
            //Mappers
            static PLMapper _mapper = new PLMapper();
            static DataAccess _StatDataAccess = new DataAccess();
            static StatsLogic _StatLogic = new StatsLogic();


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
                _StatLogic.AddStats(_mapper.Map(_AddStats));
                return RedirectToAction("Index", "Home");
            }
            return View();
        }
        [HttpGet]
        public ActionResult StatsAdd()
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
                //send the input information to the Logic Layer for the calculation to happen
                _StatLogic.AddStats(_mapper.Map(_UpdateStats));
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
        [HttpGet]
        public ActionResult StatsView()
        {

            if (ModelState.IsValid)
            {
                StatsList _ListStats = new StatsList();
                _ListStats._StatsList = _mapper.Map(_StatDataAccess.GetAllStats());
                return View(_ListStats);
            }
            return View();
        }
    }
}
