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
    public class VigenciaSoatController : Controller
    {
        private DBOCAContext db = new DBOCAContext();

        // GET: VigenciaSoat
        public ActionResult Index()
        {
            return View(db.VigenciaSoats.ToList());
        }

        // GET: VigenciaSoat/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VigenciaSoat vigenciaSoat = db.VigenciaSoats.Find(id);
            if (vigenciaSoat == null)
            {
                return HttpNotFound();
            }
            return View(vigenciaSoat);
        }

        // GET: VigenciaSoat/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: VigenciaSoat/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,CodVigencia,DesVigencia,Activo")] VigenciaSoat vigenciaSoat)
        {
            if (ModelState.IsValid)
            {
                db.VigenciaSoats.Add(vigenciaSoat);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(vigenciaSoat);
        }

        // GET: VigenciaSoat/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VigenciaSoat vigenciaSoat = db.VigenciaSoats.Find(id);
            if (vigenciaSoat == null)
            {
                return HttpNotFound();
            }
            return View(vigenciaSoat);
        }

        // POST: VigenciaSoat/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,CodVigencia,DesVigencia,Activo")] VigenciaSoat vigenciaSoat)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vigenciaSoat).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(vigenciaSoat);
        }

        // GET: VigenciaSoat/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VigenciaSoat vigenciaSoat = db.VigenciaSoats.Find(id);
            if (vigenciaSoat == null)
            {
                return HttpNotFound();
            }
            return View(vigenciaSoat);
        }

        // POST: VigenciaSoat/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            VigenciaSoat vigenciaSoat = db.VigenciaSoats.Find(id);
            db.VigenciaSoats.Remove(vigenciaSoat);
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
