using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using Auth.Repositorio;
using Auth.Models;


namespace Auth.Controllers
{
    public class CarteraOCController : Controller
    {
        private DBOCAContext db = new DBOCAContext();

        // GET: CarteraOC
        public ActionResult Index(string Busqueda)
        {
            var CarteraOC = from a in db.CarteraOC
                            select a;
            if (!string.IsNullOrEmpty(Busqueda))
            {
                CarteraOC = CarteraOC.Where(s => s.OC.Contains(Busqueda));

            }
            return View(CarteraOC);
        }

        // GET: CarteraOC/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CarteraOC carteraOC = db.CarteraOC.Find(id);
            if (carteraOC == null)
            {
                return HttpNotFound();
            }
            return View(carteraOC);
        }

        // GET: CarteraOC/Create
        public ActionResult Create()
        {
            this.ViewBag.ListaOCs = new DBOCAContext().Set<OrdenCompra>().ToList();

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CarteraOC carteraOC)
        {
            if (ModelState.IsValid)
            {
                List<ArchivoCarteraOC> archivoCarteraOCs = new List<ArchivoCarteraOC>();
                for (int i = 0; i < Request.Files.Count; i++)
                {
                    var Archivo = Request.Files[i];

                    if (Archivo != null && Archivo.ContentLength > 0)
                    {
                        var nombreArchivo = Path.GetFileName(Archivo.FileName);
                        ArchivoCarteraOC archivoCarteraOC = new ArchivoCarteraOC()
                        {
                            NombreArchivo = nombreArchivo,
                            Extension = Path.GetExtension(nombreArchivo),
                            Id = Guid.NewGuid()
                        };
                        archivoCarteraOCs.Add(archivoCarteraOC);

                        var path = Path.Combine(Server.MapPath("~/Content/ArchivosCarteraOC/"), archivoCarteraOC.Id + archivoCarteraOC.Extension);
                        Archivo.SaveAs(path);
                    }
                }
                carteraOC.ArchivoCarteraOCs = archivoCarteraOCs;
                db.CarteraOC.Add(carteraOC);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                this.ViewBag.ListaOcs = new DBOCAContext().Set<OrdenCompra>().ToList();
            }

            return View(carteraOC);
        }


        // GET: OrdenCompras/Edit/5

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CarteraOC carteraOC = db.CarteraOC.Include(s => s.ArchivoCarteraOCs).SingleOrDefault(x => x.Id == id);
            if (carteraOC == null)
            {
                return HttpNotFound();
            }

            this.ViewBag.ListaOCs = new DBOCAContext().Set<OrdenCompra>().ToList();

            return View(carteraOC);
        }

        public FileResult Download(String a, String b)
        {
            return File(Path.Combine(Server.MapPath("~/Content/ArchivosCarteraOC/"), a), System.Net.Mime.MediaTypeNames.Application.Octet, b);
        }

        // POST: OrdenCompras/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(CarteraOC carteraOC)
        {
            if (ModelState.IsValid)
            {
                for (int i = 0; i < Request.Files.Count; i++)
                {
                    var file = Request.Files[i];

                    if (file != null && file.ContentLength > 0)
                    {
                        var nombreArchivo = Path.GetFileName(file.FileName);
                        ArchivoCarteraOC archivoCarteraOC = new ArchivoCarteraOC()
                        {
                            NombreArchivo = nombreArchivo,
                            Extension = Path.GetExtension(nombreArchivo),
                            Id = Guid.NewGuid(),
                            CarteraOCId = carteraOC.Id
                        };
                        var path = Path.Combine(Server.MapPath("~/Content/ArchivosCarteraOC/"), archivoCarteraOC.Id + archivoCarteraOC.Extension);
                        file.SaveAs(path);

                        db.Entry(archivoCarteraOC).State = EntityState.Added;
                    }

                    db.Entry(carteraOC).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            return View(carteraOC);
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
                ArchivoCarteraOC archivoCarteraOC = db.ArchivoCarteraOCs.Find(guid);
                if (archivoCarteraOC == null)
                {
                    Response.StatusCode = (int)HttpStatusCode.NotFound;
                    return Json(new { Result = "Error" });
                }

                //Remove from database
                db.ArchivoCarteraOCs.Remove(archivoCarteraOC);
                db.SaveChanges();

                //Delete file from the file system
                var path = Path.Combine(Server.MapPath("~/Content/ArchivosCarteraOC/"), archivoCarteraOC.Id + archivoCarteraOC.Extension);
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
                CarteraOC carteraOC = db.CarteraOC.Find(id);
                if (carteraOC == null)
                {
                    Response.StatusCode = (int)HttpStatusCode.NotFound;
                    return Json(new { Result = "Error" });
                }
                db.CarteraOC.Remove(carteraOC);
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
