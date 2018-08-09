using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.Mvc;
using Agent.Models;

namespace Agent.Controllers
{
    public class AccountController : Controller
    {
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                // поиск пользователя в бд
                Person user = null;
                using (PersonContext db = new PersonContext())
                {
                    user = db.People.FirstOrDefault(u => u.Email == model.Email && u.Password == model.Password);
                }

                if (user != null)
                {
                    FormsAuthentication.SetAuthCookie(model.Email, true);
                    return RedirectToAction("Authorization", "main");
                }
                else
                {
                    ModelState.AddModelError("", "Пользователя с таким логином и паролем нет");
                }
            }

            return View(model);
        }

        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                Person user = null;
                using (PersonContext db = new PersonContext())
                {
                    user = db.People.FirstOrDefault(u => u.Email == model.Email);
                }
                if (user == null)
                {
                    // создаем нового пользователя
                    using (PersonContext db = new PersonContext())
                    {
                        db.People.Add(new Person { FullName = model.FullName, Email = model.Email, Password = model.Password, Age = model.Age });
                        db.SaveChanges();

                        user = db.People.Where(u => u.Email == model.Email && u.Password == model.Password).FirstOrDefault();
                    }
                    // если пользователь удачно добавлен в бд
                    if (user != null)
                    {
                        FormsAuthentication.SetAuthCookie(model.Email, true);
                        return RedirectToAction("authorization", "main");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Пользователь с таким логином уже существует");
                }
            }
            return View(model);
        }

        [Authorize]
        public ActionResult Logoff()
        {
            FormsAuthentication.SignOut();
            return View();
        }
    }
}