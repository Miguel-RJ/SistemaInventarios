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
        public ActionResult Verify(Usuario user)
        {
            var Busqueda = db.Usuarios.Where(x => x.IdUser == user.IdUser && x.Pass == user.Pass).FirstOrDefault();
            if (Busqueda is null)
            {
                return View("LogIn");
            }
            else
            {
                Busqueda.Sesion = true;
                db.SaveChanges();

                return RedirectToAction("Index", "Index", null);
            }
        }
    }
}