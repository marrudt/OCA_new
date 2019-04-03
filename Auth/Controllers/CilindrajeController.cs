using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Auth.Models;
using Auth.Repositorio;

namespace Auth.Controllers
{
    public class CilindrajeController : Controller
    {
        private DBOCAContext db = new DBOCAContext();

        // GET: Cilindraje
        public ActionResult Index()
        {
            return View(db.Cilindrajes.ToList());
        }

        // GET: Cilindraje/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cilindraje cilindraje = db.Cilindrajes.Find(id);
            if (cilindraje == null)
            {
                return HttpNotFound();
            }
            return View(cilindraje);
        }

        // GET: Cilindraje/Create
        public ActionResult Create()
        {
            this.ViewBag.ListaSegmentos = new DBOCAContext().Set<Segmento>().Where(m => m.Activo == true).ToList();

            return View();
        }

        // POST: Cilindraje/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,CodCilindraje,DesCilindraje,Activo")] Cilindraje cilindraje)
        {
            if (ModelState.IsValid)
            {
                db.Cilindrajes.Add(cilindraje);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                this.ViewBag.ListaSegmentos = new DBOCAContext().Set<Segmento>().Where(m => m.Activo == true).ToList();
            }

            return View(cilindraje);
        }

        // GET: Cilindraje/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cilindraje cilindraje = db.Cilindrajes.Find(id);
            if (cilindraje == null)
            {
                return HttpNotFound();
            }

            this.ViewBag.ListaSegmentos = new DBOCAContext().Set<Segmento>().Where(m => m.Activo == true).ToList();

            return View(cilindraje);
        }

        // POST: Cilindraje/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,CodCilindraje,DesCilindraje,Activo")] Cilindraje cilindraje)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cilindraje).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cilindraje);
        }

        // GET: Cilindraje/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cilindraje cilindraje = db.Cilindrajes.Find(id);
            if (cilindraje == null)
            {
                return HttpNotFound();
            }
            return View(cilindraje);
        }

        // POST: Cilindraje/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Cilindraje cilindraje = db.Cilindrajes.Find(id);
            db.Cilindrajes.Remove(cilindraje);
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
