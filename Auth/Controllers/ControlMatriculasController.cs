using System;
using System.Data;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using Auth.Models;
using Auth.Repositorio;
using EntityState = System.Data.Entity.EntityState;

namespace Auth.Controllers
{
    public class ControlMatriculasController : Controller
    {
        private DBOCAContext db = new DBOCAContext();

        // GET: ControlMatriculas
        public ActionResult Index(string Busqueda)
        {
            var OC = from a in db.ControlMatriculas
                     select a;
            if (!string.IsNullOrEmpty(Busqueda))
            {
                OC = OC.Where(s => s.OC.Contains(Busqueda));

            }
            return View(OC);
        }

        // GET: ControlMatriculas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ControlMatriculas controlMatriculas = db.ControlMatriculas.Find(id);
            if (controlMatriculas == null)
            {
                return HttpNotFound();
            }
            return View(controlMatriculas);
        }

        // GET: ControlMatriculas/Create
        public ActionResult Create()
        {
            ViewBag.ListaOCs = new SelectList(db.OrdenCompra.OrderBy(x => x.OC), "OC", "OC");
            ViewBag.ListaLineas = new SelectList(db.LineaVh.OrderBy(x => x.descripcion), "Id", "descripcion");
            ViewBag.ListaTerceros = new SelectList(db.TercerosOCAs.OrderBy(x => x.nombres), "nombres", "nombres");
           
            return View();
        }

        // POST: ControlMatriculas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ControlMatriculas controlMatriculas)
        {
            if (ModelState.IsValid)
            {
                db.ControlMatriculas.Add(controlMatriculas);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.ListaOCs = new SelectList(db.OrdenCompra.OrderBy(x => x.OC), "OC", "OC");
                ViewBag.ListaLineas = new SelectList(db.LineaVh.OrderBy(x => x.descripcion), "Id", "descripcion");
                ViewBag.ListaTerceros = new SelectList(db.TercerosOCAs.OrderBy(x => x.nombres), "nombres", "nombres");
            }
            return View(controlMatriculas);
        }

        // GET: ControlMatriculas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ControlMatriculas controlMatriculas = db.ControlMatriculas.Find(id);
            if (controlMatriculas == null)
            {
                return HttpNotFound();
            }
            ViewBag.ListaOCs = new SelectList(db.OrdenCompra.OrderBy(x => x.OC), "OC", "OC");
            ViewBag.ListaLineas = new SelectList(db.LineaVh.OrderBy(x => x.descripcion), "Id", "descripcion");
            ViewBag.ListaTerceros = new SelectList(db.TercerosOCAs.OrderBy(x => x.nombres), "nombres", "nombres");

            return View(controlMatriculas);
        }

        // POST: ControlMatriculas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ControlMatriculas controlMatriculas)
        {
            if (ModelState.IsValid)
            {
                db.Entry(controlMatriculas).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(controlMatriculas);
        }

        // POST: /Support/Delete/5

        [HttpPost]
        public JsonResult Delete(int id)
        {
            try
            {
                ControlMatriculas controlMatriculas = db.ControlMatriculas.Find(id);
                if (controlMatriculas == null)
                {
                    Response.StatusCode = (int)HttpStatusCode.NotFound;
                    return Json(new { Result = "Error" });
                }
                db.ControlMatriculas.Remove(controlMatriculas);
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

