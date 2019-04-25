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
    public class AdecuacionController : Controller
    {
        private DBOCAContext db = new DBOCAContext();

        // GET: Adecuacion
        public ActionResult Index()
        {
            return View(db.Adecuacions.ToList());
        }

        // GET: Adecuacion/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Adecuacion adecuacion = db.Adecuacions.Find(id);
            if (adecuacion == null)
            {
                return HttpNotFound();
            }
            return View(adecuacion);
        }

        // GET: Adecuacion/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Adecuacion/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdAdecuacion,DesAdecuacion,IdDetalle")] Adecuacion adecuacion)
        {
            if (ModelState.IsValid)
            {
                db.Adecuacions.Add(adecuacion);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(adecuacion);
        }

        // GET: Adecuacion/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Adecuacion adecuacion = db.Adecuacions.Find(id);
            if (adecuacion == null)
            {
                return HttpNotFound();
            }
            return View(adecuacion);
        }

        // POST: Adecuacion/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdAdecuacion,DesAdecuacion,IdDetalle")] Adecuacion adecuacion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(adecuacion).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(adecuacion);
        }

        // GET: Adecuacion/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Adecuacion adecuacion = db.Adecuacions.Find(id);
            if (adecuacion == null)
            {
                return HttpNotFound();
            }
            return View(adecuacion);
        }

        // POST: Adecuacion/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Adecuacion adecuacion = db.Adecuacions.Find(id);
            db.Adecuacions.Remove(adecuacion);
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
