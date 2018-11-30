using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PresentationLayer.Models;
using DataAccessLayer;



namespace PresentationLayer.Controllers
{
    public class TeamsController : Controller
    {
        //Mapper
        static PLMapper _mapper = new PLMapper();
        static DataAccess _TeamDataAccess = new DataAccess();

        // GET: Teams
        public ActionResult Index()
        {
            return View();
        }        
        //Register Team
        [HttpPost]
        public ActionResult TeamRegister(TeamsModel _RegTeam)
        {
            if (ModelState.IsValid)
            {
                _TeamDataAccess.AddTeams(_mapper.Map(_RegTeam));
                return RedirectToAction("Index", "Home");
            }
            return View();
        }
        [HttpGet]
        public ActionResult TeamRegister()
        {
            TeamsModel _Teams = new TeamsModel();
            return View(_Teams);

        }
        //Update Team Information
        [HttpPost]
        public ActionResult TeamUpdate(TeamsModel _UpdateTeams)
        {
            if (ModelState.IsValid)
            {
                _UpdateTeams.TeamName = (string)Session["TeamName"];
                _TeamDataAccess.UpdateTeams(_mapper.Map(_UpdateTeams));
                return RedirectToAction("Index", "Home");
            }
            return View();
        }
        [HttpGet]
        public ActionResult TeamUpdate()
        {
            TeamsModel _UpdateTeam = new TeamsModel();
            return View(_UpdateTeam);

        }
        //TeamList view
        [HttpGet]
        public ActionResult TeamView()
        {

            if (ModelState.IsValid)
            {
                TeamList _ListTeams = new TeamList();
                _ListTeams._TeamsList = _mapper.Map(_TeamDataAccess.GetAllTeams());
                return View(_ListTeams);
            }
            return View();
        }
    }
}
