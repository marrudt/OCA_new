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
    public class MttoPreventivoController : Controller
    {
        private DBOCAContext db = new DBOCAContext();

        // GET: MttoPreventivo
        public ActionResult Index()
        {
            return View(db.MttoPreventivos.ToList());
        }

        // GET: MttoPreventivo/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MttoPreventivo mttoPreventivo = db.MttoPreventivos.Find(id);
            if (mttoPreventivo == null)
            {
                return HttpNotFound();
            }
            return View(mttoPreventivo);
        }

        // GET: MttoPreventivo/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MttoPreventivo/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,CodMtto,DesMtto,Activo")] MttoPreventivo mttoPreventivo)
        {
            if (ModelState.IsValid)
            {
                db.MttoPreventivos.Add(mttoPreventivo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(mttoPreventivo);
        }

        // GET: MttoPreventivo/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MttoPreventivo mttoPreventivo = db.MttoPreventivos.Find(id);
            if (mttoPreventivo == null)
            {
                return HttpNotFound();
            }
            return View(mttoPreventivo);
        }

        // POST: MttoPreventivo/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,CodMtto,DesMtto,Activo")] MttoPreventivo mttoPreventivo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mttoPreventivo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(mttoPreventivo);
        }

        // GET: MttoPreventivo/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MttoPreventivo mttoPreventivo = db.MttoPreventivos.Find(id);
            if (mttoPreventivo == null)
            {
                return HttpNotFound();
            }
            return View(mttoPreventivo);
        }

        // POST: MttoPreventivo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MttoPreventivo mttoPreventivo = db.MttoPreventivos.Find(id);
            db.MttoPreventivos.Remove(mttoPreventivo);
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
