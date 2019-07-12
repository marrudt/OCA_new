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
    public class ModelosOCAController : Controller
    {
        private DBOCAContext db = new DBOCAContext();

        // GET: ModelosOCA
        public ActionResult Index()
        {
            return View(db.ModelosOCAs.ToList());
        }

        // GET: ModelosOCA/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ModelosOCA modelosOCA = db.ModelosOCAs.Find(id);
            if (modelosOCA == null)
            {
                return HttpNotFound();
            }
            return View(modelosOCA);
        }

        // GET: ModelosOCA/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ModelosOCA/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ModelosOCA modelosOCA)
        {
            if (ModelState.IsValid)
            {
                db.ModelosOCAs.Add(modelosOCA);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(modelosOCA);
        }

        // GET: ModelosOCA/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ModelosOCA modelosOCA = db.ModelosOCAs.Find(id);
            if (modelosOCA == null)
            {
                return HttpNotFound();
            }
            return View(modelosOCA);
        }

        // POST: ModelosOCA/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ModelosOCA modelosOCA)
        {
            if (ModelState.IsValid)
            {
                db.Entry(modelosOCA).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(modelosOCA);
        }

        // GET: ModelosOCA/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ModelosOCA modelosOCA = db.ModelosOCAs.Find(id);
            if (modelosOCA == null)
            {
                return HttpNotFound();
            }
            return View(modelosOCA);
        }

        // POST: ModelosOCA/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ModelosOCA modelosOCA = db.ModelosOCAs.Find(id);
            db.ModelosOCAs.Remove(modelosOCA);
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
