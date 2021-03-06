﻿using System;
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
    public class DetalleController : Controller
    {
        private DBOCAContext db = new DBOCAContext();

        // GET: Detalle
        public ActionResult Index()
        {
            return View(db.Detalles.ToList());
        }

        // GET: Detalle/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Detalle detalle = db.Detalles.Find(id);
            if (detalle == null)
            {
                return HttpNotFound();
            }
            return View(detalle);
        }

        // GET: Detalle/Create
        public ActionResult Create()
        {
            ViewBag.ListaSegmentos = new SelectList(db.Segmentoes.OrderBy(x => x.DesSegmento).Where(m => m.Activo == true), "IdSegmento", "DesSegmento");

            return View();
        }

        // POST: Detalle/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Detalle detalle)
        {
            if (ModelState.IsValid)
            {
                db.Detalles.Add(detalle);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.ListaSegmentos = new SelectList(db.Segmentoes.OrderBy(x => x.DesSegmento).Where(m => m.Activo == true), "IdSegmento", "DesSegmento");
            }

            return View(detalle);
        }

        // GET: Detalle/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Detalle detalle = db.Detalles.Find(id);
            if (detalle == null)
            {
                return HttpNotFound();
            }
            ViewBag.ListaSegmentos = new SelectList(db.Segmentoes.OrderBy(x => x.DesSegmento).Where(m => m.Activo == true), "IdSegmento", "DesSegmento");

            return View(detalle);
        }

        // POST: Detalle/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Detalle detalle)
        {
            if (ModelState.IsValid)
            {
                db.Entry(detalle).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(detalle);
        }

        // GET: Detalle/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Detalle detalle = db.Detalles.Find(id);
            if (detalle == null)
            {
                return HttpNotFound();
            }
            return View(detalle);
        }

        // POST: Detalle/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Detalle detalle = db.Detalles.Find(id);
            db.Detalles.Remove(detalle);
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
