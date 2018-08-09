using System.Linq;
using System.Web.Security;
using System.Web.Mvc;
using Agent.Models;

namespace Agent.Controllers
{
    public class PostController : Controller
    {
        PersonContext db = new PersonContext();

        // GET: Posting
        [Authorize]
        public ActionResult Posting()
        {
            return View();
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
        

        [HttpPost]
        public ActionResult Posting(Post model)
        {
            if (ModelState.IsValid)
            {
                Post postik = null;
                using (PersonContext db = new PersonContext())
                {
                    postik = db.Posts.FirstOrDefault(u => u.Adress == model.Adress);
                }
                if (postik == null)
                {
                    // создаем новое объявление
                    using (PersonContext db = new PersonContext())
                    {
                        db.Posts.Add(new Post { Name = model.Name, Adress = model.Adress, ColKomnat = model.ColKomnat, Price = model.Price, Ploshad = model.Ploshad, Opisanie = model.Opisanie });
                        db.SaveChanges();

                        postik = db.Posts.Where(u => u.Adress == model.Adress).FirstOrDefault();
                    }
                    // если объявление удачно добавлен в бд
                    if (postik != null)
                    {
                        FormsAuthentication.SetAuthCookie(model.Adress, true);
                        return RedirectToAction("profil", "main");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Объявление с таким адресом уже есть, извините, попробуйте ещё раз, может в следующий раз у вас наконец-то получится!");
                }
            }
            return View(model);
        }


        public ActionResult ProsmotrKV()
        {
            return View(db.Posts);
        }
    }
}