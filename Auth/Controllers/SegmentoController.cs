using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using Auth.Models;
using Auth.Repositorio;

namespace Auth.Controllers
{
    public class SegmentoController : Controller
    {
        private DBOCAContext db = new DBOCAContext();

        // GET: Segmento
        public ActionResult Index()
        {
            return View(db.Segmento.ToList());
        }

        // GET: Segmento/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Segmento segmento = db.Segmento.Find(id);
            if (segmento == null)
            {
                return HttpNotFound();
            }
            return View(segmento);
        }

        // GET: Segmento/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Segmento/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Segmento segmento)
        {
            if (ModelState.IsValid)
            {
                db.Segmento.Add(segmento);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(segmento);
        }

        // GET: Segmento/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Segmento segmento = db.Segmento.Find(id);
            if (segmento == null)
            {
                return HttpNotFound();
            }
            return View(segmento);
        }

        // POST: Segmento/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Segmento segmento)
        {
            if (ModelState.IsValid)
            {
                db.Entry(segmento).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(segmento);
        }

        // GET: Segmento/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Segmento segmento = db.Segmento.Find(id);
            if (segmento == null)
            {
                return HttpNotFound();
            }
            return View(segmento);
        }

        // POST: Segmento/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Segmento segmento = db.Segmento.Find(id);
            db.Segmento.Remove(segmento);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
