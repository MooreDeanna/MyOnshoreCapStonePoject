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
        public ActionResult PlayerLogin(PlayerModel _LogPlayer)
        {
            if (ModelState.IsValid)
            {
                //Creating a new Player object to house our return from the Player login
                PlayerModel _PlayerMod = new PlayerModel();
                //Filling the UserPO object with the value from mapped data Access
                _PlayerMod = _mapper.Map(_PlayerDataAccess.LoginPlayer(_mapper.Map(_LogPlayer)));
                //use _UserMod to fill session variable                
                Session["UserName"] = _PlayerMod.PlayerName;
                Session["UserPassword"] = _PlayerMod.PlayerPassword;
                Session["FKRoleID"] = _PlayerMod.FKRoleID;
                //if successfully logged in redirect to the home page             
                if (Session["UserName"] is null)
                {
                    return View();
                }
                else
                {
                    if ((int)Session["FKRoleID"] <= 0)
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
            return View();
        }
        [HttpGet]
        public ActionResult Register()
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
        public ActionResult UserUpdate()
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
    }
}