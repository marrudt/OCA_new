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
    public class TransmisionController : Controller
    {
        private DBOCAContext db = new DBOCAContext();

        // GET: Transmision
        public ActionResult Index()
        {
            return View(db.Transmisiones.ToList());
        }

        // GET: Transmision/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Transmision transmision = db.Transmisiones.Find(id);
            if (transmision == null)
            {
                return HttpNotFound();
            }
            return View(transmision);
        }

        // GET: Transmision/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Transmision/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,CodTransmision,DesTransmision,Activo")] Transmision transmision)
        {
            if (ModelState.IsValid)
            {
                db.Transmisiones.Add(transmision);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(transmision);
        }

        // GET: Transmision/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Transmision transmision = db.Transmisiones.Find(id);
            if (transmision == null)
            {
                return HttpNotFound();
            }
            return View(transmision);
        }

        // POST: Transmision/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,CodTransmision,DesTransmision,Activo")] Transmision transmision)
        {
            if (ModelState.IsValid)
            {
                db.Entry(transmision).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(transmision);
        }

        // GET: Transmision/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Transmision transmision = db.Transmisiones.Find(id);
            if (transmision == null)
            {
                return HttpNotFound();
            }
            return View(transmision);
        }

        // POST: Transmision/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Transmision transmision = db.Transmisiones.Find(id);
            db.Transmisiones.Remove(transmision);
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
