using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SistemaInventarios.Models.AppDBContext;

namespace SistemaInventarios.Controllers
{
    public class UsuariosController : Controller
    {
        private AppDBContext db = new AppDBContext();

        // GET: Usuarios
        public ActionResult Index()
        {
            Response.AppendHeader("Cache-Control", "no-store");
            var SesionIniciadaAdmin = db.Usuarios.Where(x => x.Sesion == true && x.IdRol == "A").ToList();
            if (SesionIniciadaAdmin.Count() > 0)
            {
                var usuarios = db.Usuarios.Include(u => u.RolesUsuarios);
                return View(usuarios.ToList());
            }
            else
            {
                var SesionIniciada = db.Usuarios.Where(x => x.Sesion == true).ToList();
                if (SesionIniciada.Count > 0)
                {
                    return RedirectToAction("Index", "Index", null);
                }
                else
                {
                    return RedirectToAction("LogIn", "LogIn", null);
                }
            }
        }

        // GET: Usuarios/Details/5
        public ActionResult Details(string id)
        {
            Response.AppendHeader("Cache-Control", "no-store");
            var SesionIniciadaAdmin = db.Usuarios.Where(x => x.Sesion == true && x.IdRol == "A").ToList();
            if (SesionIniciadaAdmin.Count() > 0)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Usuarios usuarios = db.Usuarios.Find(id);
                if (usuarios == null)
                {
                    return HttpNotFound();
                }
                return View(usuarios);
            }
            else
            {
                var SesionIniciada = db.Usuarios.Where(x => x.Sesion == true).ToList();
                if (SesionIniciada.Count > 0)
                {
                    return RedirectToAction("Index", "Index", null);
                }
                else
                {
                    return RedirectToAction("LogIn", "LogIn", null);
                }
            }
        }

        // GET: Usuarios/Create
        public ActionResult Create()
        {
            Response.AppendHeader("Cache-Control", "no-store");
            var SesionIniciadaAdmin = db.Usuarios.Where(x => x.Sesion == true && x.IdRol == "A").ToList();
            if (SesionIniciadaAdmin.Count() > 0)
            {
                ViewBag.IdRol = new SelectList(db.RolesUsuarios, "IdRol", "NombreRol");
                return View();
            }
            else
            {
                var SesionIniciada = db.Usuarios.Where(x => x.Sesion == true).ToList();
                if (SesionIniciada.Count > 0)
                {
                    return RedirectToAction("Index", "Index", null);
                }
                else
                {
                    return RedirectToAction("LogIn", "LogIn", null);
                }
            }
        }

        // POST: Usuarios/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdUser,Pass,Nombre,IdRol,Palabra,Sesion")] Usuarios usuarios)
        {
            if (ModelState.IsValid)
            {
                usuarios.Sesion = false;
                db.Usuarios.Add(usuarios);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdRol = new SelectList(db.RolesUsuarios, "IdRol", "NombreRol", usuarios.IdRol);
            return View(usuarios);
        }

        // GET: Usuarios/Edit/5
        public ActionResult Edit(string id)
        {
            Response.AppendHeader("Cache-Control", "no-store");       
            var SesionIniciadaAdmin = db.Usuarios.Where(x => x.Sesion == true && x.IdRol == "A").ToList();
            if (SesionIniciadaAdmin.Count() > 0)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Usuarios usuarios = db.Usuarios.Find(id);
                if (usuarios == null)
                {
                    return HttpNotFound();
                }
                ViewBag.IdRol = new SelectList(db.RolesUsuarios, "IdRol", "NombreRol", usuarios.IdRol);
                return View(usuarios);
            }
            else
            {
                var SesionIniciada = db.Usuarios.Where(x => x.Sesion == true).ToList();
                if (SesionIniciada.Count > 0)
                {
                    return RedirectToAction("Index", "Index", null);
                }
                else
                {
                    return RedirectToAction("LogIn", "LogIn", null);
                }
            }
        }

        // POST: Usuarios/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdUser,Pass,Nombre,IdRol,Palabra,Sesion")] Usuarios usuarios)
        {
            if (ModelState.IsValid)
            {
                db.Entry(usuarios).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdRol = new SelectList(db.RolesUsuarios, "IdRol", "NombreRol", usuarios.IdRol);
            return View(usuarios);
        }

        // GET: Usuarios/Delete/5
        public ActionResult Delete(string id)
        {
            Response.AppendHeader("Cache-Control", "no-store");
            var SesionIniciadaAdmin = db.Usuarios.Where(x => x.Sesion == true && x.IdRol == "A").ToList();
            if (SesionIniciadaAdmin.Count() > 0)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Usuarios usuarios = db.Usuarios.Find(id);
                if (usuarios == null)
                {
                    return HttpNotFound();
                }
                return View(usuarios);
            }
            else
            {
                var SesionIniciada = db.Usuarios.Where(x => x.Sesion == true).ToList();
                if (SesionIniciada.Count > 0)
                {
                    return RedirectToAction("Index", "Index", null);
                }
                else
                {
                    return RedirectToAction("LogIn", "LogIn", null);
                }
            }
        }

        // POST: Usuarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Usuarios usuarios = db.Usuarios.Find(id);
            db.Usuarios.Remove(usuarios);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
