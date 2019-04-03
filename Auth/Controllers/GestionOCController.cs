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
    public class GestionOCController : Controller
    {
        private DBOCAContext db = new DBOCAContext();

        // GET: GestionOC
        public ActionResult Index(string Busqueda)
        {
            var GestionOC = from a in db.GestionOC
                            select a;
            if (!string.IsNullOrEmpty(Busqueda))
            {
                GestionOC = GestionOC.Where(s => s.OC.Contains(Busqueda));

            }
            return View(GestionOC);
        }

        // GET: GestionOC/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GestionOC gestionOC = db.GestionOC.Find(id);
            if (gestionOC == null)
            {
                return HttpNotFound();
            }
            return View(gestionOC);
        }

        // GET: GestionOC/Create
        public ActionResult Create()
        {
            ViewBag.ListaOCs = new SelectList(db.OrdenCompra.OrderBy(x => x.OC), "Id", "OC");
            ViewBag.ListaEntidades = new SelectList(db.EntidadMatriculas.OrderBy(x => x.nombres), "nit", "nombres");

            return View();
        }

        // POST: GestionOC/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(GestionOC gestionOC)
        {
            if (ModelState.IsValid)
            {
                db.GestionOC.Add(gestionOC);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.ListaOCs = new SelectList(db.OrdenCompra.OrderBy(x => x.OC), "Id", "OC");
                ViewBag.ListaEntidades = new SelectList(db.EntidadMatriculas.OrderBy(x => x.nombres), "nit", "nombres");
            }

            return View(gestionOC);
        }

        // GET: GestionOC/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GestionOC gestionOC = db.GestionOC.Find(id);
            if (gestionOC == null)
            {
                return HttpNotFound();
            }

            ViewBag.ListaOCs = new SelectList(db.OrdenCompra.OrderBy(x => x.OC), "Id", "OC");
            ViewBag.ListaEntidades = new SelectList(db.EntidadMatriculas.OrderBy(x => x.nombres), "nit", "nombres");

            return View(gestionOC);
        }

        // POST: GestionOC/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(GestionOC gestionOC)
        {
            if (ModelState.IsValid)
            {
                db.Entry(gestionOC).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(gestionOC);
        }

        // POST: /Support/Delete/5

        [HttpPost]
        public JsonResult Delete(int id)
        {
            try
            {
                GestionOC gestionOC = db.GestionOC.Find(id);
                if (gestionOC == null)
                {
                    Response.StatusCode = (int)HttpStatusCode.NotFound;
                    return Json(new { Result = "Error" });
                }
                db.GestionOC.Remove(gestionOC);
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
