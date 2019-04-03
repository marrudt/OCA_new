using System;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using Auth.Models;
using Auth.Repositorio;
using System.Web.Routing;
using PagedList;

namespace Auth.Controllers
{
    public class TercerosOCAController : Controller
    {
        private DBOCAContext db = new DBOCAContext();

        // GET: TercerosOCA
        public ActionResult Index(string sortOrder, string currentFilter, string searchString, int? page)
        {
            //var TercerosOCA = from a in db.TercerosOCAs
            //                  select a;
            //if (!string.IsNullOrEmpty(Busqueda))
            //{
            //    TercerosOCA = TercerosOCA.Where(s => s.nit.Contains(Busqueda));

            //}
            //return View(TercerosOCA);

            ViewBag.CurrentSort = sortOrder;
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.NitSortParm = sortOrder == "Nit" ? "nit_desc" : "Nit";

            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;

            var TercerosOCA = from s in db.TercerosOCAs
                              select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                TercerosOCA = TercerosOCA.Where(s => s.nombres.Contains(searchString)
                                       || s.nit.Contains(searchString));
            }
            switch (sortOrder)
            {
                case "name_desc":
                    TercerosOCA = TercerosOCA.OrderByDescending(s => s.nombres);
                    break;
                case "Nit":
                    TercerosOCA = TercerosOCA.OrderBy(s => s.nit);
                    break;
                case "nit_desc":
                    TercerosOCA = TercerosOCA.OrderByDescending(s => s.nit);
                    break;
                default:  // Name ascending 
                    TercerosOCA = TercerosOCA.OrderBy(s => s.nombres);
                    break;
            }

            int pageSize = 500;
            int pageNumber = (page ?? 1);
            //IPagedList<TercerosOCA> ter = null;
            //List<TercerosOCA> ObjTercerosList = new List<TercerosOCA>();

            return View(TercerosOCA.ToPagedList(pageNumber, pageSize));

        }




        // GET: TercerosOCA/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TercerosOCA tercerosOCA = db.TercerosOCAs.Find(id);
            if (tercerosOCA == null)
            {
                return HttpNotFound();
            }
            return View(tercerosOCA);
        }

        // GET: TercerosOCA/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TercerosOCA/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TercerosOCA tercerosOCA)
        {
            if (ModelState.IsValid)
            {
                db.TercerosOCAs.Add(tercerosOCA);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tercerosOCA);
        }

        // GET: TercerosOCA/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TercerosOCA tercerosOCA = db.TercerosOCAs.Find(id);
            if (tercerosOCA == null)
            {
                return HttpNotFound();
            }
            return View(tercerosOCA);
        }

        // POST: TercerosOCA/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(TercerosOCA tercerosOCA)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tercerosOCA).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tercerosOCA);
        }


        [HttpPost]
        public JsonResult Delete(int id)
        {
            try
            {
                TercerosOCA tercerosOCA = db.TercerosOCAs.Find(id);
                if (tercerosOCA == null)
                {
                    Response.StatusCode = (int)HttpStatusCode.NotFound;
                    return Json(new { Result = "Error" });
                }
                db.TercerosOCAs.Remove(tercerosOCA);
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

