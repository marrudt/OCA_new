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
    public class IntervaloPrecioController : Controller
    {
        private DBOCAContext db = new DBOCAContext();

        // GET: IntervaloPrecio
        public ActionResult Index()
        {
            return View(db.IntervaloPrecios.ToList());
        }

        // GET: IntervaloPrecio/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IntervaloPrecio intervaloPrecio = db.IntervaloPrecios.Find(id);
            if (intervaloPrecio == null)
            {
                return HttpNotFound();
            }
            return View(intervaloPrecio);
        }

        // GET: IntervaloPrecio/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: IntervaloPrecio/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,CodIntervalo,DesIntervalo,Activo")] IntervaloPrecio intervaloPrecio)
        {
            if (ModelState.IsValid)
            {
                db.IntervaloPrecios.Add(intervaloPrecio);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(intervaloPrecio);
        }

        // GET: IntervaloPrecio/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IntervaloPrecio intervaloPrecio = db.IntervaloPrecios.Find(id);
            if (intervaloPrecio == null)
            {
                return HttpNotFound();
            }
            return View(intervaloPrecio);
        }

        // POST: IntervaloPrecio/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,CodIntervalo,DesIntervalo,Activo")] IntervaloPrecio intervaloPrecio)
        {
            if (ModelState.IsValid)
            {
                db.Entry(intervaloPrecio).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(intervaloPrecio);
        }

        // GET: IntervaloPrecio/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IntervaloPrecio intervaloPrecio = db.IntervaloPrecios.Find(id);
            if (intervaloPrecio == null)
            {
                return HttpNotFound();
            }
            return View(intervaloPrecio);
        }

        // POST: IntervaloPrecio/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            IntervaloPrecio intervaloPrecio = db.IntervaloPrecios.Find(id);
            db.IntervaloPrecios.Remove(intervaloPrecio);
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
