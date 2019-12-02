using SistemaInventarios.Models;
using SistemaInventarios.Models.AppDBContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace SistemaInventarios.Controllers
{
    public class IndexController : Controller
    {
        AppDBContext db = new AppDBContext();
        // GET: Index
        [HttpGet]
        public ActionResult Index()
        {
            var SesionIniciada = db.Usuarios.Where(x => x.Sesion == true).ToList();
            if (SesionIniciada.Count() > 0)
            {
                Usuario user = (new Usuario
                {
                    IdRol = SesionIniciada.FirstOrDefault().IdRol,
                    Nombre = SesionIniciada.FirstOrDefault().Nombre,
                    IdUser = SesionIniciada.FirstOrDefault().IdUser
                });
                Response.AppendHeader("Cache-Control", "no-store");
                return View(user);
            }
            else
            {
                return RedirectToAction("LogIn", "LogIn", null);
            }
        }

        public ActionResult LogOut()
        {
            var SesionIniciada = db.Usuarios.Where(x => x.Sesion == true).ToList();
            foreach (var item in SesionIniciada)
            {
                item.Sesion = false;
            }
            db.SaveChanges();
            Response.AppendHeader("Cache-Control", "no-store");

            return RedirectToAction("LogIn","LogIn",null);
        }

        public ActionResult CRUDArticulos()
        {
            return View();
        }

        public ActionResult CRUDUsuarios()
        {
            return View();
        }
    }
}