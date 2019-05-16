using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Auth.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity;
using Auth.Repositorio;
using System.Web.Security;

namespace Auth.Controllers
{
    [Authorize]
    public class RoleController : Controller
    {
        ApplicationDbContext context;

        public RoleController()
        {
            context = new ApplicationDbContext();
        }

        /// <summary> 
        /// Get All Roles 
        /// </summary> 
        /// <returns></returns> 
        public ActionResult Index()
        {

            if (User.Identity.IsAuthenticated)
            {


                if (!isAdminUser())
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }

            var Roles = context.Roles.ToList();
            return View(Roles);

        }
        public Boolean isAdminUser()
        {
            if (User.Identity.IsAuthenticated)
            {
                var user = User.Identity;
                var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
                var s = UserManager.GetRoles(user.GetUserId());
                if (s[0].ToString() == "Admin")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return false;
        }
        // <summary> 
        // Create a New role 
        // </summary> 
        // <returns></returns> 
        public ActionResult Create()
        {
            if (User.Identity.IsAuthenticated)
            {


                if (!isAdminUser())
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }

            var Role = new IdentityRole();
            return View(Role);
        }

        /// <summary> 
        /// Create a New Role 
        /// </summary> 
        /// <param name="Role"></param> 
        /// <returns></returns> 
        [HttpPost]
        public ActionResult Create(IdentityRole Role)
        {
            if (User.Identity.IsAuthenticated)
            {
                if (!isAdminUser())
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }

            context.Roles.Add(Role);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        //[HttpPost]
        //public ActionResult RoleCreate(Role role)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        if (Roles.RoleExists(role.Nombre))
        //        {
        //            ModelState.AddModelError("Error", "El Rol ya existe");
        //            return View(role);
        //        }
        //        else
        //        {
        //            Roles.CreateRole(role.Nombre);
        //            return RedirectToAction("DisplayAllRoles", "Account");
        //        }
        //    }
        //    else
        //    {
        //        ModelState.AddModelError("Error", "Por favor, ingrese un Usuario y una Contraseña");
        //    }
        //    return View(role);
        //}

        //[HttpGet]
        //public ActionResult DisplayAllRoles()
        //{
        //    IEnumerable<Role> ListRoles;
        //    using (DBOCAContext db = new DBOCAContext())
        //    {
        //        ListRoles = db.Roles.ToList();
        //    }
        //    return View(ListRoles);
        //}


    }
}