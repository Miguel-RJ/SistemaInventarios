using SistemaInventarios.Models;
using SistemaInventarios.Models.AppDBContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SistemaInventarios.Controllers
{
    public class LogInController : Controller
    {
        AppDBContext db = new AppDBContext();
        // GET: LogIn
        [HttpGet]
        public ActionResult LogIn(string Mensaje)
        {
            ViewBag.Mensaje = Mensaje;
            return View("LogIn");
        }
        public ActionResult Verify(Usuario user)
        {
            var Busqueda = db.Usuarios.Where(x => x.IdUser == user.IdUser && x.Pass == user.Pass).FirstOrDefault();
            if (Busqueda is null)
            {
                var msj = "Id o usuario incorrecto. Intente de nuevo.";
                return RedirectToAction("LogIn",new { Mensaje = msj});
            }
            else
            {
                var CerradoSesion = db.Usuarios.Where(x => x.Sesion == true).ToList();
                foreach (var item in CerradoSesion)
                {
                    item.Sesion = false;
                }
                Busqueda.Sesion = true;
                db.SaveChanges();

                return RedirectToAction("Index", "Index", null);
            }
        }

        [HttpGet]
        public ActionResult PassForgotten()
        {
            return View();
        }
        [HttpPost]
        public ActionResult PassForgotten(Usuario user)
        {
            var Busqueda = db.Usuarios.Where(x => x.IdUser == user.IdUser && x.Palabra == user.Palabra).FirstOrDefault();
            if (Busqueda is null)
            {
                ViewBag.Mensaje = "Palabra y usuario no coinciden. Intente de nuevo.";
            }
            else
            {
                ViewBag.Mensaje = "La contraseña para el usuario: '" + Busqueda.IdUser + "' es: " + Busqueda.Pass;
            }
            return View(user);
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

            return Redirect("LogIn");
        }

    }
}