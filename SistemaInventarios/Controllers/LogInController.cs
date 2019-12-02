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
        public ActionResult LogIn()
        {
            return View();
        }
        public ActionResult Verify(Usuarios user)
        {
            var Busqueda = db.Usuarios.Where(x => x.IdUser == user.IdUser && x.Pass == user.Pass).FirstOrDefault();
            if (Busqueda is null)
            {
                return View("LogIn");
            }
            else
            {
                user.Nombre = Busqueda.Nombre;
                user.IdRol = Busqueda.IdRol;
                user.Palabra = Busqueda.Palabra;
                return RedirectToAction("Index", "Index", user);
            }
        }
    }
}