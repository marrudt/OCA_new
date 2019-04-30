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
    public class ProveedorOCController : Controller
    {
        private DBOCAContext db = new DBOCAContext();

        // GET: ProveedorOC
        public ActionResult Index(string Busqueda)
        {
            var ProveedorOCs = from a in db.ProveedorOCs
                               select a;
            if (!string.IsNullOrEmpty(Busqueda))
            {
                ProveedorOCs = ProveedorOCs.Where(s => s.OC.Contains(Busqueda));

            }
            return View(ProveedorOCs);
        }

        // GET: ProveedorOC/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProveedorOC proveedorOC = db.ProveedorOCs.Find(id);
            if (proveedorOC == null)
            {
                return HttpNotFound();
            }
            return View(proveedorOC);
        }

        // GET: ProveedorOC/Create
        public ActionResult Create()
        {
            ViewBag.ListaOCs = new SelectList(db.OrdenCompra.OrderBy(x => x.OC), "OC", "OC");
            ViewBag.ListaProveedores = new SelectList(db.Proveedors.OrderBy(x => x.nombres), "nombres", "nombres");
            ViewBag.ListaReferencias = new SelectList(db.ReferenciasOC.OrderBy(x => x.descripcion), "descripcion", "descripcion");
            
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProveedorOC proveedorOC)
        {
            if (ModelState.IsValid)
            {
                List<ArchivoProveedorOC> archivoProveedorOCs = new List<ArchivoProveedorOC>();
                for (int i = 0; i < Request.Files.Count; i++)
                {
                    var Archivo = Request.Files[i];

                    if (Archivo != null && Archivo.ContentLength > 0)
                    {
                        var nombreArchivo = Path.GetFileName(Archivo.FileName);
                        ArchivoProveedorOC archivoProveedorOC = new ArchivoProveedorOC()
                        {
                            NombreArchivo = nombreArchivo,
                            Extension = Path.GetExtension(nombreArchivo),
                            Id = Guid.NewGuid()
                        };
                        archivoProveedorOCs.Add(archivoProveedorOC);

                        var path = Path.Combine(Server.MapPath("~/Content/ArchivosOC/"), archivoProveedorOC.Id + archivoProveedorOC.Extension);
                        Archivo.SaveAs(path);
                    }
                }
                proveedorOC.ArchivoProveedorOCs = archivoProveedorOCs;
                db.ProveedorOCs.Add(proveedorOC);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.ListaOCs = new SelectList(db.OrdenCompra.OrderBy(x => x.OC), "OC", "OC");
                ViewBag.ListaProveedores = new SelectList(db.Proveedors.OrderBy(x => x.nombres), "nombres", "nombres");
                ViewBag.ListaReferencias = new SelectList(db.ReferenciasOC.OrderBy(x => x.descripcion), "descripcion", "descripcion");
            }

            return View(proveedorOC);
        }


        // GET: OrdenCompras/Edit/5

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProveedorOC proveedorOC = db.ProveedorOCs.Include(s => s.ArchivoProveedorOCs).SingleOrDefault(x => x.Id == id);
            if (proveedorOC == null)
            {
                return HttpNotFound();
            }

            ViewBag.ListaOCs = new SelectList(db.OrdenCompra.OrderBy(x => x.OC), "OC", "OC");
            ViewBag.ListaProveedores = new SelectList(db.Proveedors.OrderBy(x => x.nombres), "nombres", "nombres");
            ViewBag.ListaReferencias = new SelectList(db.ReferenciasOC.OrderBy(x => x.descripcion), "descripcion", "descripcion");

            return View(proveedorOC);
        }

        public FileResult Download(String p, String d)
        {
            return File(Path.Combine(Server.MapPath("~/Content/ArchivosProveedorOC/"), p), System.Net.Mime.MediaTypeNames.Application.Octet, d);
        }

        // POST: OrdenCompras/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ProveedorOC proveedorOC)
        {
            if (ModelState.IsValid)
            {
                for (int i = 0; i < Request.Files.Count; i++)
                {
                    var file = Request.Files[i];

                    if (file != null && file.ContentLength > 0)
                    {
                        var nombreArchivo = Path.GetFileName(file.FileName);
                        ArchivoProveedorOC archivoProveedorOC = new ArchivoProveedorOC()
                        {
                            NombreArchivo = nombreArchivo,
                            Extension = Path.GetExtension(nombreArchivo),
                            Id = Guid.NewGuid(),
                            ProveedorOCId = proveedorOC.Id
                        };
                        var path = Path.Combine(Server.MapPath("~/Content/ArchivosProveedorOC/"), archivoProveedorOC.Id + archivoProveedorOC.Extension);
                        file.SaveAs(path);

                        db.Entry(archivoProveedorOC).State = EntityState.Added;
                    }

                    db.Entry(proveedorOC).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            return View(proveedorOC);
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
                ArchivoProveedorOC archivoProveedorOC = db.ArchivoProveedorOCs.Find(guid);
                if (archivoProveedorOC == null)
                {
                    Response.StatusCode = (int)HttpStatusCode.NotFound;
                    return Json(new { Result = "Error" });
                }

                //Remove from database
                db.ArchivoProveedorOCs.Remove(archivoProveedorOC);
                db.SaveChanges();

                //Delete file from the file system
                var path = Path.Combine(Server.MapPath("~/Content/ArchivosProveedorOC/"), archivoProveedorOC.Id + archivoProveedorOC.Extension);
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
                ProveedorOC proveedorOC = db.ProveedorOCs.Find(id);
                if (proveedorOC == null)
                {
                    Response.StatusCode = (int)HttpStatusCode.NotFound;
                    return Json(new { Result = "Error" });
                }

                //delete files from the file system

                foreach (var item in proveedorOC.ArchivoProveedorOCs)
                {
                    String path = Path.Combine(Server.MapPath("~/Content/ArchivosProveedorOC/"), item.Id + item.Extension);
                    if (System.IO.File.Exists(path))
                    {
                        System.IO.File.Delete(path);
                    }
                }

                db.ProveedorOCs.Remove(proveedorOC);
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
