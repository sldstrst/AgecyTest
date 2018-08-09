using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Agent.Models;

namespace Agent.Controllers
{
    public class ApartamentController : Controller
    {
        PersonContext db = new PersonContext();


        public ActionResult Listfull()
        {
           // var apart = db.Apartaments;
           // ViewBag.Apartaments = apart;
            return View();
           // return View(db.Apartaments);
        }


        // GET: Apartament
        public ActionResult List_Details()
        {
            return View();
        }

        public ActionResult List_Edit()
        {
            return View();
        }

        [Authorize]
        public ActionResult List_Created()
        {
            return View();
        }
        [Authorize]
        public ActionResult Posting()
        {
            return View();
        }

        [HttpPost]
        [Authorize]
        public ActionResult Posting(Apartament model)
        {
            if (ModelState.IsValid)
            {
                Apartament postik = null;
                using (PersonContext db = new PersonContext())
                {
                    //postik = db.Apartaments.FirstOrDefault(u => u.Adress == model.Adress);
                }
                if (postik == null)
                {
                    // создаем новое объявление
                    using (PersonContext db = new PersonContext())
                    {
                       // db.Apartaments.Add(new Apartament { Name = model.Name, Adress = model.Adress, Price = model.Price, Surface = model.Surface, Description = model.Description });
                        db.SaveChanges();

                       // postik = db.Apartaments.Where(u => u.Id == model.Id).FirstOrDefault();
                    }
                    // если объявление удачно добавлен в бд
                    if (postik != null)
                    {
                        FormsAuthentication.SetAuthCookie(model.Adress, true);
                        return RedirectToAction("Posting", "Apartament");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Объявление с таким адресом уже есть, извините, попробуйте ещё раз, может в следующий раз у вас наконец-то получится");
                }
            }
            return View(model);
        }



    }
}