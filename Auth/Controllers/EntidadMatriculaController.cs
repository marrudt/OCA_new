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
    public class EntidadMatriculaController : Controller
    {
        private DBOCAContext db = new DBOCAContext();

        // GET: EntidadMatricula
        public ActionResult Index(string Busqueda)
        {
            var EntidadMatriculas = from a in db.EntidadMatriculas
                                    select a;
            if (!string.IsNullOrEmpty(Busqueda))
            {
                EntidadMatriculas = EntidadMatriculas.Where(s => s.nit.Contains(Busqueda));

            }
            return View(EntidadMatriculas);
        }

        // GET: EntidadMatricula/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EntidadMatricula entidadMatricula = db.EntidadMatriculas.Find(id);
            if (entidadMatricula == null)
            {
                return HttpNotFound();
            }
            return View(entidadMatricula);
        }

        // GET: EntidadMatricula/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EntidadMatricula/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(EntidadMatricula entidadMatricula)
        {
            if (ModelState.IsValid)
            {
                db.EntidadMatriculas.Add(entidadMatricula);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(entidadMatricula);
        }

        // GET: EntidadMatricula/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EntidadMatricula entidadMatricula = db.EntidadMatriculas.Find(id);
            if (entidadMatricula == null)
            {
                return HttpNotFound();
            }
            return View(entidadMatricula);
        }

        // POST: EntidadMatricula/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(EntidadMatricula entidadMatricula)
        {
            if (ModelState.IsValid)
            {
                db.Entry(entidadMatricula).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(entidadMatricula);
        }

        // GET: EntidadMatricula/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EntidadMatricula entidadMatricula = db.EntidadMatriculas.Find(id);
            if (entidadMatricula == null)
            {
                return HttpNotFound();
            }
            return View(entidadMatricula);
        }

        // POST: /Support/Delete/5

        [HttpPost]
        public JsonResult Delete(int id)
        {
            try
            {
                EntidadMatricula entidadMatriculas = db.EntidadMatriculas.Find(id);
                if (entidadMatriculas == null)
                {
                    Response.StatusCode = (int)HttpStatusCode.NotFound;
                    return Json(new { Result = "Error" });
                }
                db.EntidadMatriculas.Remove(entidadMatriculas);
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
