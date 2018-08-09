using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Agent.Models;
using System.Web.Security;


namespace Agent.Controllers
{
    public class MainController : Controller
    {
        PersonContext db = new PersonContext();
        public ActionResult Mp()
        {
            return View(db.People);
        }
        


        [Authorize]
        public ActionResult Profil()
        {
            var person = db.People;
            ViewBag.People = person;
            return View(db.People);
        }

        public ActionResult Info()
        {

            return View();
        }
        

        [Authorize]
        public ActionResult Exit()
        {
            FormsAuthentication.SignOut();
            return View();
        }

        public ActionResult Authorization()
        {
            return View();
        }
    }
}