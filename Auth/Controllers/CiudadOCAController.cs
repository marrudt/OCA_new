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
    public class CiudadOCAController : Controller
    {
        private DBOCAContext db = new DBOCAContext();

        // GET: CiudadOCA
        public ActionResult Index()
        {
            return View(db.CiudadOCA.ToList());
        }

        // GET: CiudadOCA/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CiudadOCA ciudadOCA = db.CiudadOCA.Find(id);
            if (ciudadOCA == null)
            {
                return HttpNotFound();
            }
            return View(ciudadOCA);
        }

        // GET: CiudadOCA/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CiudadOCA/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CiudadOCA ciudadOCA)
        {
            if (ModelState.IsValid)
            {
                db.CiudadOCA.Add(ciudadOCA);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(ciudadOCA);
        }

        // GET: CiudadOCA/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CiudadOCA ciudadOCA = db.CiudadOCA.Find(id);
            if (ciudadOCA == null)
            {
                return HttpNotFound();
            }
            return View(ciudadOCA);
        }

        // POST: CiudadOCA/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(CiudadOCA ciudadOCA)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ciudadOCA).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(ciudadOCA);
        }

        // GET: CiudadOCA/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CiudadOCA ciudadOCA = db.CiudadOCA.Find(id);
            if (ciudadOCA == null)
            {
                return HttpNotFound();
            }
            return View(ciudadOCA);
        }

        // POST: CiudadOCA/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CiudadOCA ciudadOCA = db.CiudadOCA.Find(id);
            db.CiudadOCA.Remove(ciudadOCA);
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
