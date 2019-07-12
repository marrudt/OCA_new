using System;
using System.Data;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using Auth.Models;
using Auth.Repositorio;
using System.Data.Entity;
using System.Collections.Generic;
using System.IO;

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

        // GET: ControlMatriculas/Create
        public ActionResult Create()
        {
            ViewBag.ListaOCs = new SelectList(db.OrdenCompra.OrderBy(x => x.OC), "OC", "OC");
            ViewBag.ListaLineas = new SelectList(db.LineaVh.OrderBy(x => x.descripcion), "Id", "descripcion");
            ViewBag.ListaTerceros = new SelectList(db.TercerosOCAs.OrderBy(x => x.nombres), "nombres", "nombres");
            ViewBag.ListaEntidades = new SelectList(db.EntidadMatriculas.OrderBy(x => x.nombres), "nombres", "nombres");

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ControlMatriculas controlMatriculas)
        {
            if (ModelState.IsValid)
            {
                List<ArchivoMatriculaOC> archivoMatriculaOCs = new List<ArchivoMatriculaOC>();
                for (int i = 0; i < Request.Files.Count; i++)
                {
                    var Archivo = Request.Files[i];

                    if (Archivo != null && Archivo.ContentLength > 0)
                    {
                        var nombreArchivo = Path.GetFileName(Archivo.FileName);
                        ArchivoMatriculaOC archivoMatriculaOC = new ArchivoMatriculaOC()
                        {
                            NombreArchivo = nombreArchivo,
                            Extension = Path.GetExtension(nombreArchivo),
                            Id = Guid.NewGuid()
                        };
                        archivoMatriculaOCs.Add(archivoMatriculaOC);

                        var path = Path.Combine(Server.MapPath("~/Content/ArchivosMatriculasOC/"), archivoMatriculaOC.Id + archivoMatriculaOC.Extension);
                        Archivo.SaveAs(path);
                    }
                }
                controlMatriculas.ArchivoMatriculaOCs = archivoMatriculaOCs;
                db.ControlMatriculas.Add(controlMatriculas);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.ListaOCs = new SelectList(db.OrdenCompra.OrderBy(x => x.OC), "OC", "OC");
                ViewBag.ListaLineas = new SelectList(db.LineaVh.OrderBy(x => x.descripcion), "Id", "descripcion");
                ViewBag.ListaTerceros = new SelectList(db.TercerosOCAs.OrderBy(x => x.nombres), "nombres", "nombres");
                ViewBag.ListaEntidades = new SelectList(db.EntidadMatriculas.OrderBy(x => x.nombres), "nombres", "nombres");
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
            ControlMatriculas controlMatriculas = db.ControlMatriculas.Include(s => s.ArchivoMatriculaOCs).SingleOrDefault(x => x.Id == id);
            if (controlMatriculas == null)
            {
                return HttpNotFound();
            }
            ViewBag.ListaOCs = new SelectList(db.OrdenCompra.OrderBy(x => x.OC), "OC", "OC");
            ViewBag.ListaLineas = new SelectList(db.LineaVh.OrderBy(x => x.descripcion), "Id", "descripcion");
            ViewBag.ListaTerceros = new SelectList(db.TercerosOCAs.OrderBy(x => x.nombres), "nombres", "nombres");
            ViewBag.ListaEntidades = new SelectList(db.EntidadMatriculas.OrderBy(x => x.nombres), "nombres", "nombres");

            return View(controlMatriculas);
        }
                
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ControlMatriculas controlMatriculas)
        {
            if (ModelState.IsValid)
            {
                for (int i = 0; i < Request.Files.Count; i++)
                {
                    var file = Request.Files[i];

                    if (file != null && file.ContentLength > 0)
                    {
                        var nombreArchivo = Path.GetFileName(file.FileName);
                        ArchivoMatriculaOC archivoMatricula = new ArchivoMatriculaOC()
                        {
                            NombreArchivo = nombreArchivo,
                            Extension = Path.GetExtension(nombreArchivo),
                            Id = Guid.NewGuid(),
                            MatriculaOCId = controlMatriculas.Id
                        };
                        var path = Path.Combine(Server.MapPath("~/Content/ArchivosMatriculasOC/"), archivoMatricula.Id + archivoMatricula.Extension);
                        file.SaveAs(path);

                        db.Entry(archivoMatricula).State = EntityState.Added;
                    }
                    db.Entry(controlMatriculas).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            return View(controlMatriculas);
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
                ArchivoMatriculaOC archivoMatricula = db.ArchivoMatriculaOCs.Find(guid);
                if (archivoMatricula == null)
                {
                    Response.StatusCode = (int)HttpStatusCode.NotFound;
                    return Json(new { Result = "Error" });
                }

                //Remove from database
                db.ArchivoMatriculaOCs.Remove(archivoMatricula);
                db.SaveChanges();

                //Delete file from the file system
                var path = Path.Combine(Server.MapPath("~/Content/ArchivosMatriculasOC/"), archivoMatricula.Id + archivoMatricula.Extension);
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
                ControlMatriculas controlMatriculas= db.ControlMatriculas.Find(id);
                if (controlMatriculas == null)
                {
                    Response.StatusCode = (int)HttpStatusCode.NotFound;
                    return Json(new { Result = "Error" });
                }

                //delete files from the file system

                foreach (var item in controlMatriculas.ArchivoMatriculaOCs)
                {
                    String path = Path.Combine(Server.MapPath("~/Content/ArchivosMatriculasOC/"), item.Id + item.Extension);
                    if (System.IO.File.Exists(path))
                    {
                        System.IO.File.Delete(path);
                    }
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
