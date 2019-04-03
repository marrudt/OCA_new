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
    public class SegmentosController : Controller
    {
        private DBOCAContext db = new DBOCAContext();

        // GET: Segmentos
        public ActionResult Index()
        {
            return View(db.Segmentoes.ToList());
        }

        // GET: Segmentos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Segmento segmento = db.Segmentoes.Find(id);
            if (segmento == null)
            {
                return HttpNotFound();
            }
            return View(segmento);
        }

        // GET: Segmentos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Segmentos/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,CodSegmento,DesSegmento,Activo")] Segmento segmento)
        {
            if (ModelState.IsValid)
            {
                db.Segmentoes.Add(segmento);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(segmento);
        }

        // GET: Segmentos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Segmento segmento = db.Segmentoes.Find(id);
            if (segmento == null)
            {
                return HttpNotFound();
            }
            return View(segmento);
        }

        // POST: Segmentos/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,CodSegmento,DesSegmento,Activo")] Segmento segmento)
        {
            if (ModelState.IsValid)
            {
                db.Entry(segmento).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(segmento);
        }

        // GET: Segmentos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Segmento segmento = db.Segmentoes.Find(id);
            if (segmento == null)
            {
                return HttpNotFound();
            }
            return View(segmento);
        }

        // POST: Segmentos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Segmento segmento = db.Segmentoes.Find(id);
            db.Segmentoes.Remove(segmento);
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
