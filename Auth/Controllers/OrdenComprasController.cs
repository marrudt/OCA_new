using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using Auth.Models;
using Auth.Repositorio;

namespace Auth.Controllers
{
    public class OrdenComprasController : Controller
    {
        private DBOCAContext db = new DBOCAContext();

        // GET: OrdenCompras

        public ActionResult Index(string Busqueda)
        {
            var OC = from a in db.OrdenCompra
                     select a;
            if (!string.IsNullOrEmpty(Busqueda))
            {
                OC = OC.Where(s => s.OC.Contains(Busqueda));

            }
            return View(OC);
        }
        
        // GET: OrdenCompras/Create

        public ActionResult Create()
        {
            ViewBag.ListaTerceros = new SelectList(db.TercerosOCAs.OrderBy(x => x.nombres), "nombres", "nombres");
            ViewBag.ListaOCs = new SelectList(db.OrdenCompra.OrderBy(x => x.OC), "Id", "OC");

            return View();
        }
               
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(OrdenCompra ordenCompra)
        {
            if (ModelState.IsValid)
            {
                List<ArchivoOC> archivoOCs = new List<ArchivoOC>();
                for (int i = 0; i < Request.Files.Count; i++)
                {
                    var Archivo = Request.Files[i];

                    if (Archivo != null && Archivo.ContentLength > 0)
                    {
                        var nombreArchivo = Path.GetFileName(Archivo.FileName);
                        ArchivoOC archivoOC = new ArchivoOC()
                        {
                            NombreArchivo = nombreArchivo,
                            Extension = Path.GetExtension(nombreArchivo),
                            Id = Guid.NewGuid()
                        };
                        archivoOCs.Add(archivoOC);

                        var path = Path.Combine(Server.MapPath("~/Content/ArchivosOC/"), archivoOC.Id + archivoOC.Extension);
                        Archivo.SaveAs(path);
                    }
                }
                ordenCompra.ArchivoOCs = archivoOCs;
                db.OrdenCompra.Add(ordenCompra);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                //this.ViewBag.ListaOcs = new DBOCAContext().Set<OrdenCompra>().ToList();
                ViewBag.ListaOCs = new SelectList(db.OrdenCompra.OrderBy(x => x.OC), "Id", "OC");
                ViewBag.ListaTerceros = new SelectList(db.TercerosOCAs.OrderBy(x => x.nombres), "nombres", "nombres");
            }

            return View(ordenCompra);
        }

        // GET: OrdenCompras/Edit/5

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrdenCompra ordenCompra = db.OrdenCompra.Include(s => s.ArchivoOCs).SingleOrDefault(x => x.Id == id);
            if (ordenCompra == null)
            {
                return HttpNotFound();
            }

            ViewBag.ListaOCs = new SelectList(db.OrdenCompra.OrderBy(x => x.OC), "Id", "OC");
            ViewBag.ListaTerceros = new SelectList(db.TercerosOCAs.OrderBy(x => x.nombres), "nombres", "nombres");

            return View(ordenCompra);
        }

        public FileResult Download(String p, String d)
        {
            return File(Path.Combine(Server.MapPath("~/Content/ArchivosOC/"), p), System.Net.Mime.MediaTypeNames.Application.Octet, d);
        }

        // POST: OrdenCompras/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(OrdenCompra ordenCompra)
        {
            if (ModelState.IsValid)
            {
                for (int i = 0; i < Request.Files.Count; i++)
                {
                    var file = Request.Files[i];

                    if (file != null && file.ContentLength > 0)
                    {
                        var nombreArchivo = Path.GetFileName(file.FileName);
                        ArchivoOC archivoOC = new ArchivoOC()
                        {
                            NombreArchivo = nombreArchivo,
                            Extension = Path.GetExtension(nombreArchivo),
                            Id = Guid.NewGuid(),
                            OCId = ordenCompra.Id
                        };
                        var path = Path.Combine(Server.MapPath("~/Content/ArchivosOC/"), archivoOC.Id + archivoOC.Extension);
                        file.SaveAs(path);

                        db.Entry(archivoOC).State = EntityState.Added;
                    }

                    db.Entry(ordenCompra).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            return View(ordenCompra);
        }

        [HttpPost]
        public JsonResult DeleteFile(string id)
        {
            if (String.IsNullOrEmpty(id))
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return Json(new { Result = "Error" });
            }
            try
            {
                Guid guid = new Guid(id);
                ArchivoOC archivoOC = db.ArchivoOCs.Find(guid);
                if (archivoOC == null)
                {
                    Response.StatusCode = (int)HttpStatusCode.NotFound;
                    return Json(new { Result = "Error" });
                }

                //Remove from database
                db.ArchivoOCs.Remove(archivoOC);
                db.SaveChanges();

                //Delete file from the file system
                var path = Path.Combine(Server.MapPath("~/Content/ArchivosOC/"), archivoOC.Id + archivoOC.Extension);
                if (System.IO.File.Exists(path))
                {
                    System.IO.File.Delete(path);
                }
                return Json(new { Result = "OK" });
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", Message = ex.Message });
            }
        }

        // POST: /Support/Delete/5

        [HttpPost]
        public JsonResult Delete(int id)
        {
            try
            {
                OrdenCompra ordenCompra = db.OrdenCompra.Find(id);
                if (ordenCompra == null)
                {
                    Response.StatusCode = (int)HttpStatusCode.NotFound;
                    return Json(new { Result = "Error" });
                }

                //delete files from the file system

                foreach (var item in ordenCompra.ArchivoOCs)
                {
                    String path = Path.Combine(Server.MapPath("~/Content/ArchivosOC/"), item.Id + item.Extension);
                    if (System.IO.File.Exists(path))
                    {
                        System.IO.File.Delete(path);
                    }
                }

                db.OrdenCompra.Remove(ordenCompra);
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
