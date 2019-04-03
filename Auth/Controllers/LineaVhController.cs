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
    public class LineaVhController : Controller
    {
        private DBOCAContext db = new DBOCAContext();

        // GET: LineaVh
        public ActionResult Index(string Busqueda)
        {
            var LineaVh = from a in db.LineaVh
                          select a;
            if (!string.IsNullOrEmpty(Busqueda))
            {
                LineaVh = LineaVh.Where(s => s.descripcion.Contains(Busqueda));

            }
            return View(LineaVh);
        }

        // GET: LineaVh/Details/5        
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LineaVh lineaVh = db.LineaVh.Find(id);
            if (lineaVh == null)
            {
                return HttpNotFound();
            }
            return View(lineaVh);
        }

        // GET: LineaVh/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LineaVh/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,clase,descripcion")] LineaVh lineaVh)
        {
            if (ModelState.IsValid)
            {
                db.LineaVh.Add(lineaVh);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(lineaVh);
        }

        // GET: LineaVh/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LineaVh lineaVh = db.LineaVh.Find(id);
            if (lineaVh == null)
            {
                return HttpNotFound();
            }
            return View(lineaVh);
        }

        // POST: LineaVh/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,clase,descripcion")] LineaVh lineaVh)
        {
            if (ModelState.IsValid)
            {
                db.Entry(lineaVh).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(lineaVh);
        }

        // POST: /Support/Delete/5

        [HttpPost]
        public JsonResult Delete(int id)
        {
            try
            {
                LineaVh lineaVh = db.LineaVh.Find(id);
                if (lineaVh == null)
                {
                    Response.StatusCode = (int)HttpStatusCode.NotFound;
                    return Json(new { Result = "Error" });
                }
                db.LineaVh.Remove(lineaVh);
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

