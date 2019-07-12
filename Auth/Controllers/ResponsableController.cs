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
    public class ResponsableController : Controller
    {
        private DBOCAContext db = new DBOCAContext();

        // GET: Responsable
        public ActionResult Index()
        {
            return View(db.Responsables.ToList());
        }

        // GET: Responsable/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Responsable responsable = db.Responsables.Find(id);
            if (responsable == null)
            {
                return HttpNotFound();
            }
            return View(responsable);
        }

        // GET: Responsable/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Responsable/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nombre,Activo")] Responsable responsable)
        {
            if (ModelState.IsValid)
            {
                db.Responsables.Add(responsable);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(responsable);
        }

        // GET: Responsable/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Responsable responsable = db.Responsables.Find(id);
            if (responsable == null)
            {
                return HttpNotFound();
            }
            return View(responsable);
        }

        // POST: Responsable/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nombre,Activo")] Responsable responsable)
        {
            if (ModelState.IsValid)
            {
                db.Entry(responsable).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(responsable);
        }

        // GET: Responsable/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Responsable responsable = db.Responsables.Find(id);
            if (responsable == null)
            {
                return HttpNotFound();
            }
            return View(responsable);
        }

        // POST: Responsable/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Responsable responsable = db.Responsables.Find(id);
            db.Responsables.Remove(responsable);
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
