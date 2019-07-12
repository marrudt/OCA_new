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
    public class GestionCarteraController : Controller
    {
        private DBOCAContext db = new DBOCAContext();

        // GET: GestionCartera
        public ActionResult Index(string Busqueda)
        {
            var GestionCartera = from a in db.GestionCartera
                                 select a;
            if (!string.IsNullOrEmpty(Busqueda))
            {
                GestionCartera = GestionCartera.Where(s => s.OC.Contains(Busqueda));

            }
            return View(GestionCartera);
        }

        // GET: GestionCartera/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GestionCartera gestionCartera = db.GestionCartera.Find(id);
            if (gestionCartera == null)
            {
                return HttpNotFound();
            }
            return View(gestionCartera);
        }

        // GET: GestionCartera/Create
        public ActionResult Create()
        {
            this.ViewBag.ListaOCs = new DBOCAContext().Set<OrdenCompra>().ToList();
            ViewBag.ListaResponsables = new SelectList(db.Responsables.OrderBy(x => x.Nombre), "Nombre", "Nombre");

            return View();
        }

        // POST: GestionCartera/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(GestionCartera gestionCartera)
        {
            if (ModelState.IsValid)
            {
                db.GestionCartera.Add(gestionCartera);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                this.ViewBag.ListaOCs = new DBOCAContext().Set<OrdenCompra>().ToList();
                ViewBag.ListaResponsables = new SelectList(db.Responsables.OrderBy(x => x.Nombre), "Nombre", "Nombre");
            }
            return View(gestionCartera);
        }

        // GET: GestionCartera/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GestionCartera gestionCartera = db.GestionCartera.Find(id);
            if (gestionCartera == null)
            {
                return HttpNotFound();
            }

            this.ViewBag.ListaOCs = new DBOCAContext().Set<OrdenCompra>().ToList();
            ViewBag.ListaResponsables = new SelectList(db.Responsables.OrderBy(x => x.Nombre), "Nombre", "Nombre");

            return View(gestionCartera);
        }

        // POST: GestionCartera/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(GestionCartera gestionCartera)
        {
            if (ModelState.IsValid)
            {
                db.Entry(gestionCartera).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(gestionCartera);
        }

        // POST: /Support/Delete/5

        [HttpPost]
        public JsonResult Delete(int id)
        {
            try
            {
                GestionCartera gestionCartera = db.GestionCartera.Find(id);
                if (gestionCartera == null)
                {
                    Response.StatusCode = (int)HttpStatusCode.NotFound;
                    return Json(new { Result = "Error" });
                }
                db.GestionCartera.Remove(gestionCartera);
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

