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
    public class EjecucionOCController : Controller
    {
        private DBOCAContext db = new DBOCAContext();

        // GET: EjecucionOC
        public ActionResult Index(string Busqueda)
        {
            var EjecucionOC = from a in db.EjecucionOC
                              select a;
            if (!string.IsNullOrEmpty(Busqueda))
            {
                EjecucionOC = EjecucionOC.Where(s => s.OC.Contains(Busqueda));

            }
            return View(EjecucionOC);
        }

        // GET: EjecucionOC/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EjecucionOC ejecucionOC = db.EjecucionOC.Find(id);
            if (ejecucionOC == null)
            {
                return HttpNotFound();
            }
            return View(ejecucionOC);
        }

        // GET: EjecucionOC/Create
        public ActionResult Create()
        {
            this.ViewBag.ListaOCs = new DBOCAContext().Set<OrdenCompra>().ToList();
            ViewBag.ListaResponsables = new SelectList(db.Responsables.OrderBy(x => x.Nombre), "Nombre", "Nombre");

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(EjecucionOC ejecucionOC)
        {
            if (ModelState.IsValid)
            {
                List<ArchivoEjecucionOC> archivoEjecucionOCs = new List<ArchivoEjecucionOC>();
                for (int i = 0; i < Request.Files.Count; i++)
                {
                    var Archivo = Request.Files[i];

                    if (Archivo != null && Archivo.ContentLength > 0)
                    {
                        var nombreArchivo = Path.GetFileName(Archivo.FileName);
                        ArchivoEjecucionOC archivoEjecucionOC = new ArchivoEjecucionOC()
                        {
                            NombreArchivo = nombreArchivo,
                            Extension = Path.GetExtension(nombreArchivo),
                            Id = Guid.NewGuid()
                        };
                        archivoEjecucionOCs.Add(archivoEjecucionOC);

                        var path = Path.Combine(Server.MapPath("~/Content/ArchivosEjecucionOC/"), archivoEjecucionOC.Id + archivoEjecucionOC.Extension);
                        Archivo.SaveAs(path);
                    }
                }
                ejecucionOC.ArchivoEjecucionOCs = archivoEjecucionOCs;
                db.EjecucionOC.Add(ejecucionOC);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                this.ViewBag.ListaOcs = new DBOCAContext().Set<OrdenCompra>().ToList();
                ViewBag.ListaResponsables = new SelectList(db.Responsables.OrderBy(x => x.Nombre), "Nombre", "Nombre");
            }

            return View(ejecucionOC);
        }


        // GET: OrdenCompras/Edit/5

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EjecucionOC ejecucionOC = db.EjecucionOC.Include(s => s.ArchivoEjecucionOCs).SingleOrDefault(x => x.Id == id);
            if (ejecucionOC == null)
            {
                return HttpNotFound();
            }

            this.ViewBag.ListaOCs = new DBOCAContext().Set<OrdenCompra>().ToList();
            ViewBag.ListaResponsables = new SelectList(db.Responsables.OrderBy(x => x.Nombre), "Nombre", "Nombre");

            return View(ejecucionOC);
        }

        public FileResult Download(String p, String d)
        {
            return File(Path.Combine(Server.MapPath("~/Content/ArchivosEjecucionOC/"), p), System.Net.Mime.MediaTypeNames.Application.Octet, d);
        }

        // POST: OrdenCompras/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(EjecucionOC ejecucionOC)
        {
            if (ModelState.IsValid)
            {
                for (int i = 0; i < Request.Files.Count; i++)
                {
                    var file = Request.Files[i];

                    if (file != null && file.ContentLength > 0)
                    {
                        var nombreArchivo = Path.GetFileName(file.FileName);
                        ArchivoEjecucionOC archivoEjecucionOC = new ArchivoEjecucionOC()
                        {
                            NombreArchivo = nombreArchivo,
                            Extension = Path.GetExtension(nombreArchivo),
                            Id = Guid.NewGuid(),
                            EjecucionOCId = ejecucionOC.Id
                        };
                        var path = Path.Combine(Server.MapPath("~/Content/ArchivosEjecucionOC/"), archivoEjecucionOC.Id + archivoEjecucionOC.Extension);
                        file.SaveAs(path);

                        db.Entry(archivoEjecucionOC).State = EntityState.Added;
                    }

                    db.Entry(ejecucionOC).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            return View(ejecucionOC);
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
                ArchivoEjecucionOC archivoEjecucionOC = db.ArchivoEjecucionOCs.Find(guid);
                if (archivoEjecucionOC == null)
                {
                    Response.StatusCode = (int)HttpStatusCode.NotFound;
                    return Json(new { Result = "Error" });
                }

                //Remove from database
                db.ArchivoEjecucionOCs.Remove(archivoEjecucionOC);
                db.SaveChanges();

                //Delete file from the file system
                var path = Path.Combine(Server.MapPath("~/Content/ArchivosEjecucionOC/"), archivoEjecucionOC.Id + archivoEjecucionOC.Extension);
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
                EjecucionOC ejecucionOC = db.EjecucionOC.Find(id);
                if (ejecucionOC == null)
                {
                    Response.StatusCode = (int)HttpStatusCode.NotFound;
                    return Json(new { Result = "Error" });
                }
                db.EjecucionOC.Remove(ejecucionOC);
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