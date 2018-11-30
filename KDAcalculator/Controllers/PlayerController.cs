using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PresentationLayer.Models;
using DataAccessLayer;
using PresentationLayer.Controllers;

namespace PresentationLayer.Controllers
{
    public class PlayerController : Controller

    {
        static PLMapper _mapper = new PLMapper();
        static DataAccess _PlayerDataAccess = new DataAccess();

        // GET: User
        public ActionResult Index()
        {
            return View();
        }
        //Log in Player
        [HttpPost]
        public ActionResult Login(PlayerModel _LogPlayer)
        {
            if (ModelState.IsValid)
            {
                //Creating a new Player object to house our return from the Player login
                PlayerModel _PlayerMod = new PlayerModel();
                //Filling the UserPO object with the value from mapped data Access
                _PlayerMod = _mapper.Map(_PlayerDataAccess.LoginPlayer(_mapper.Map(_LogPlayer)));
                //use _PlayerMod to fill session variable                
                Session["PlayerName"] = _PlayerMod.PlayerName;
                Session["PlayerPassword"] = _PlayerMod.PlayerPassword;
                Session["FKRoleID"] = _PlayerMod.FKRoleID;
                //if successfully logged in redirect to the home page             
                if (Session["PlayerName"] is null)
                {
                    return View();
                }
                else
                {
                    if ((int)Session["FKRoleID"] >= 0)
                    {
                        return RedirectToAction("Index", "Home");
                    }
                    return View();
                }

            }
            else

                return View();
        }
        [HttpGet]
        public ActionResult Login()
        {
            PlayerModel _Player = new PlayerModel();
            return View(_Player);
        }

        //Register Player
        [HttpPost]
        public ActionResult PlayerRegister(PlayerModel _RegPlayer)
        {
            if (ModelState.IsValid)
            {
                _PlayerDataAccess.AddPlayer(_mapper.Map(_RegPlayer));
                return RedirectToAction("Index", "Home");
            }
            return View(_RegPlayer);
        }
        [HttpGet]
        public ActionResult PlayerRegister()
        {
            PlayerModel _Player = new PlayerModel();
            return View(_Player);

        }

        //log out 
        [HttpGet]
        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Index", "Home");
        }

        //Update Player Profile Information
        [HttpPost]
        public ActionResult PlayerUpdate(PlayerModel _UpdatePlayer)
        {
            if (ModelState.IsValid)
            {
                _UpdatePlayer.PlayerName = (string)Session["PlayerName"];
                _PlayerDataAccess.UpdatePlayer(_mapper.Map(_UpdatePlayer));
                return RedirectToAction("Index", "Home");
            }
            return View();
        }
        [HttpGet]
        public ActionResult PlayerUpdate()
        {
            PlayerModel _UpdatePlayer = new PlayerModel();
            return View(_UpdatePlayer);

        }
        //PlayerList view
        [HttpGet]
        public ActionResult PlayerView()
        {

            if (ModelState.IsValid)
            {
                PlayerList _ListPlayers = new PlayerList();
                _ListPlayers._PlayerList = _mapper.Map(_PlayerDataAccess.GetAllPlayers());
                return View(_ListPlayers);
            }
            return View();
        }

        //Admin Update Player Information
        [HttpPost]
        public ActionResult AdminUpdate(PlayerList _AdminUpdatePlayer)
        {
            if (ModelState.IsValid)
            {
                foreach (PlayerModel SinglePlayer in _AdminUpdatePlayer._PlayerList)
                {
                    if (SinglePlayer._Update)
                    {  
                        
                    _PlayerDataAccess.UpdatePlayer(_mapper.Map(SinglePlayer));
                        
                    }
                    else if(SinglePlayer._Delete)
                    {                       
                        _PlayerDataAccess.DeletePlayer(SinglePlayer.PlayerName);
                    }
                }

                return RedirectToAction("AdminUpdate", "Player"); ;
                
            }
            return View();
        }
        [HttpGet]
        public ActionResult AdminUpdate()
        {
            if (ModelState.IsValid)
            {
                PlayerList _AdminUpdatePlayer = new PlayerList();
                _AdminUpdatePlayer._PlayerList = (_mapper.Map(_PlayerDataAccess.GetAllPlayers()));
                return View(_AdminUpdatePlayer);
            }
            return View();
        }
       
    }
}