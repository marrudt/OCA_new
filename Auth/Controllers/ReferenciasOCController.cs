using System;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using Auth.Models;
using Auth.Repositorio;

namespace Auth.Controllers
{
    public class ReferenciasOCController : Controller
    {
        private DBOCAContext db = new DBOCAContext();

        // GET: ReferenciasOC
        public ActionResult Index(string Busqueda)
        {
            var ReferenciasOC = from a in db.ReferenciasOC
                                select a;
            if (!string.IsNullOrEmpty(Busqueda))
            {
                ReferenciasOC = ReferenciasOC.Where(s => s.descripcion.Contains(Busqueda));

            }
            return View(ReferenciasOC);
        }

        // GET: ReferenciasOC/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ReferenciasOC referenciasOC = db.ReferenciasOC.Find(id);
            if (referenciasOC == null)
            {
                return HttpNotFound();
            }
            return View(referenciasOC);
        }

        // GET: ReferenciasOC/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ReferenciasOC/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ReferenciasOC referenciasOC)
        {
            if (ModelState.IsValid)
            {
                db.ReferenciasOC.Add(referenciasOC);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(referenciasOC);
        }

        // GET: ReferenciasOC/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ReferenciasOC referenciasOC = db.ReferenciasOC.Find(id);
            if (referenciasOC == null)
            {
                return HttpNotFound();
            }
            return View(referenciasOC);
        }

        // POST: ReferenciasOC/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ReferenciasOC referenciasOC)
        {
            if (ModelState.IsValid)
            {
                db.Entry(referenciasOC).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(referenciasOC);
        }

        // GET: ReferenciasOC/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ReferenciasOC referenciasOC = db.ReferenciasOC.Find(id);
            if (referenciasOC == null)
            {
                return HttpNotFound();
            }
            return View(referenciasOC);
        }

        // POST: /Support/Delete/5

        [HttpPost]
        public JsonResult Delete(int id)
        {
            try
            {
                ReferenciasOC referenciasOC = db.ReferenciasOC.Find(id);
                if (referenciasOC == null)
                {
                    Response.StatusCode = (int)HttpStatusCode.NotFound;
                    return Json(new { Result = "Error" });
                }
                db.ReferenciasOC.Remove(referenciasOC);
                db.SaveChanges();
                return Json(new { Result = "OK" });
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", Message = ex.Message });
            }
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}
