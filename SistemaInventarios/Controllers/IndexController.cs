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
        public ActionResult Index(string Mensaje)
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
                ViewBag.Mensaje = Mensaje;
                return View(user);
            }
            else
            {
                return RedirectToAction("LogIn", "LogIn", null);
            }
        }
    }
}