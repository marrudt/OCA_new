using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using Auth.Models;
using Auth.Repositorio;

namespace Auth.Controllers
{
    public class EventoController : Controller
    {
        private DBOCAContext db = new DBOCAContext();

        // GET: Evento
        public ActionResult Index(string Busqueda)
        {
            var Numero = from a in db.Eventoes
                         select a;
            if (!string.IsNullOrEmpty(Busqueda))
            {
                Numero = Numero.Where(s => s.Numero.Contains(Busqueda));

            }
            return View(Numero);
        }

        //public JsonResult GetSegmento()
        //{
        //    var segmentoData = db.Segmentoes.ToList().OrderBy(x => x.DesSegmento);
        //    return Json(segmentoData, JsonRequestBehavior.AllowGet);
        //}
        //public JsonResult GetCilindraje(int Id)
        //{
        //    var cilindrajeData = db.Cilindrajes.Where(x => x.IdSegmento == Id).OrderBy(x => x.DesCilindraje);
        //    return Json(cilindrajeData);
        //}
        //public JsonResult GetAdecuacion(int Id)
        //{
        //    var adecuacionData = db.Adecuacions.Where(x => x.IdCilindraje == Id).OrderBy(x => x.DesAdecuacion);
        //    return Json(adecuacionData);
        //}

        // GET: Evento/Create
        public ActionResult Create()
        {
            
            //ViewBag.ListaSegmentos = new SelectList(db.Segmentoes.OrderBy(x => x.DesSegmento), "Id", "DesSegmento");
            //ViewBag.ListaCilindrajes = new SelectList(db.Cilindrajes.OrderBy(x => x.DesCilindraje), "Id", "DesCilindraje");
            //ViewBag.ListaAdecuacion = new SelectList(db.Adecuacions.OrderBy(x => x.DesAdecuacion), "Id", "DesAdecuacion");
            ViewBag.ListaIntervalos = new SelectList(db.IntervaloPrecios.OrderBy(x => x.DesIntervalo).Where(m => m.Activo == true), "CodIntervalo", "Desintervalo");
            ViewBag.ListaVigencias = new SelectList(db.VigenciaSoats.OrderBy(x => x.DesVigencia).Where(m => m.Activo == true), "CodVigencia", "DesVigencia");
            ViewBag.ListaMttos = new SelectList(db.MttoPreventivos.OrderBy(x => x.DesMtto).Where(m => m.Activo == true), "CodMtto", "DesMtto");
            ViewBag.ListaEventos = new SelectList(db.Eventoes.OrderBy(x => x.Numero), "Id", "Numero");
            ViewBag.ListaCiudades = new SelectList(db.CiudadOCA.OrderBy(x => x.Descripcion), "Codigo", "Descripcion");
            ViewBag.ListaTerceros = new SelectList(db.TercerosOCAs.OrderBy(x => x.nombres), "nit", "nombres");
            ViewBag.ListaTransmision = new SelectList(db.Transmisiones.OrderBy(x => x.DesTransmision).Where(m => m.Activo == true), "CodTransmision", "DesTransmision");            

            return View();
        }        

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Evento evento)
        {
            if (ModelState.IsValid)
            {
                db.Eventoes.Add(evento);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                //ViewBag.ddlSegmento = new SelectList(db.Segmentoes, "Id", "DesSegmento", evento.Id);
                ////ViewBag.ddlSegmento = new SelectList(db.Segmentoes.ToList().OrderBy(x => x.DesSegmento), "Id", "DesSegmento");
                //ViewBag.ddlCilindraje = new SelectList(db.Cilindrajes.ToList().OrderBy(x => x.DesCilindraje), "Id", "DesCilindraje");
                //ViewBag.ddlAdecuacion = new SelectList(db.Adecuacions.ToList().OrderBy(x => x.DesAdecuacion), "Id", "DesAdecuacion");
                //ViewBag.ListaSegmentos = new SelectList(db.Segmentoes.OrderBy(x => x.DesSegmento), "Id", "DesSegmento");
                //ViewBag.ListaCilindrajes = new SelectList(db.Cilindrajes.OrderBy(x => x.DesCilindraje), "Id", "DesCilindraje");
                //ViewBag.ListaAdecuacion = new SelectList(db.Adecuacions.OrderBy(x => x.DesAdecuacion), "Id", "DesAdecuacion");
                ViewBag.ListaIntervalos = new SelectList(db.IntervaloPrecios.OrderBy(x => x.DesIntervalo).Where(m => m.Activo == true), "CodIntervalo", "Desintervalo");
                ViewBag.ListaVigencias = new SelectList(db.VigenciaSoats.OrderBy(x => x.DesVigencia).Where(m => m.Activo == true), "CodVigencia", "DesVigencia");
                ViewBag.ListaMttos = new SelectList(db.MttoPreventivos.OrderBy(x => x.DesMtto).Where(m => m.Activo == true), "CodMtto", "DesMtto");
                ViewBag.ListaEventos = new SelectList(db.Eventoes.OrderBy(x => x.Numero), "Id", "Numero");
                ViewBag.ListaCiudades = new SelectList(db.CiudadOCA.OrderBy(x => x.Descripcion), "Codigo", "Descripcion");
                ViewBag.ListaTerceros = new SelectList(db.TercerosOCAs.OrderBy(x => x.nombres), "nit", "nombres");
                ViewBag.ListaTransmision = new SelectList(db.Transmisiones.OrderBy(x => x.DesTransmision).Where(m => m.Activo == true), "CodTransmision", "DesTransmision");
            }         
            
            return View(evento);
        }

        // GET: Evento/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Evento evento = db.Eventoes.Find(id);
            if (evento == null)
            {
                return HttpNotFound();
            }
            //ViewBag.ddlSegmento = new SelectList(db.Segmentoes.OrderBy(x => x.DesSegmento), "Value", "Text");
            //ViewBag.ddlCilindraje = new SelectList(db.Cilindrajes.OrderBy(x => x.DesCilindraje), "Value", "Text");
            //ViewBag.ddlAdecuacion = new SelectList(db.Adecuacions.OrderBy(x => x.DesAdecuacion), "Value", "Text");
            ViewBag.ListaIntervalos = new SelectList(db.IntervaloPrecios.OrderBy(x => x.DesIntervalo).Where(m => m.Activo == true), "CodIntervalo", "Desintervalo");
            ViewBag.ListaVigencias = new SelectList(db.VigenciaSoats.OrderBy(x => x.DesVigencia).Where(m => m.Activo == true), "CodVigencia", "DesVigencia");
            ViewBag.ListaMttos = new SelectList(db.MttoPreventivos.OrderBy(x => x.DesMtto).Where(m => m.Activo == true), "CodMtto", "DesMtto");
            ViewBag.ListaEventos = new SelectList(db.Eventoes.OrderBy(x => x.Numero), "Id", "Numero");
            ViewBag.ListaCiudades = new SelectList(db.CiudadOCA.OrderBy(x => x.Descripcion), "Codigo", "Descripcion");
            ViewBag.ListaTerceros = new SelectList(db.TercerosOCAs.OrderBy(x => x.nombres), "nit", "nombres");
            ViewBag.ListaTransmision = new SelectList(db.Transmisiones.OrderBy(x => x.DesTransmision).Where(m => m.Activo == true), "CodTransmision", "DesTransmision");

            return View(evento);
        }   
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Evento evento)
        {
            if (ModelState.IsValid)
            {
                db.Entry(evento).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(evento);
        }

        // GET: Evento/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Evento evento = db.Eventoes.Find(id);
            if (evento == null)
            {
                return HttpNotFound();
            }
            return View(evento);
        }

        // POST: /Support/Delete/5

        [HttpPost]
        public JsonResult Delete(int id)
        {
            try
            {
                Evento evento = db.Eventoes.Find(id);
                if (evento == null)
                {
                    Response.StatusCode = (int)HttpStatusCode.NotFound;
                    return Json(new { Result = "Error" });
                }
                db.Eventoes.Remove(evento);
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

