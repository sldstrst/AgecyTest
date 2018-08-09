using System.Linq;
using System.Web.Security;
using System.Web.Mvc;
using Agent.Models;

namespace Agent.Controllers
{
    public class ObyavleniyasController : Controller
    {
        ObyavleniyaContext db = new ObyavleniyaContext();

        // GET: Posting
        public ActionResult Posting()
        {
            return View();
        }

        [HttpPost]
        [Authorize]
        public ActionResult Posting(Obyavleniya model)
        {
            if (ModelState.IsValid)
            {
                Obyavleniya postik = null;
                using (ObyavleniyaContext db = new ObyavleniyaContext())
                {
                    postik = db.Obyavleniyas.FirstOrDefault(u => u.Adress == model.Adress);
                }
                if (postik == null)
                {
                    // создаем новое объявление
                    using (ObyavleniyaContext db = new ObyavleniyaContext())
                    {
                        db.Obyavleniyas.Add(new Obyavleniya { Name = model.Name, Adress = model.Adress, ColKomnat = model.ColKomnat, Price = model.Price, Ploshad = model.Ploshad, Opisanie = model.Opisanie });
                        db.SaveChanges();

                        postik = db.Obyavleniyas.Where(u => u.Adress == model.Adress).FirstOrDefault();
                    }
                    // если объявление удачно добавлен в бд
                    if (postik != null)
                    {
                        FormsAuthentication.SetAuthCookie(model.Adress, true);
                        return RedirectToAction("authorization", "main");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Объявление с таким адресом уже есть, извините, попробуйте ещё раз, может в следующий раз у вас наконец-то получится, а может и нет, вы же лох!");
                }
            }
            return View(model);
        }


        public ActionResult ProsmotrKV()
        {
            var posting = db.Obyavleniyas;
            ViewBag.Obyavleniyas = posting;
            return View();
        }
    }
}