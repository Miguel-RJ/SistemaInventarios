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
    public class ArticulosController : Controller
    {
        private AppDBContext db = new AppDBContext();

        // GET: Articulos
        public ActionResult Index()
        {
            Response.AppendHeader("Cache-Control", "no-store");
            var SesionIniciada = db.Usuarios.Where(x => x.Sesion == true).ToList();
            if (SesionIniciada.Count() > 0)
            {
                return View(db.Articulos.ToList());
            }
            else
            {
                return RedirectToAction("LogIn", "LogIn", null);
            }
        }

        // GET: Articulos/Details/5
        public ActionResult Details(int? id)
        { 
            Response.AppendHeader("Cache-Control", "no-store");
            var SesionIniciada = db.Usuarios.Where(x => x.Sesion == true).ToList();
            if (SesionIniciada.Count() > 0)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Articulos articulos = db.Articulos.Find(id);
                if (articulos == null)
                {
                    return HttpNotFound();
                }
                return View(articulos);
            }
            else
            {
                return RedirectToAction("LogIn", "LogIn", null);
            }
        }

        // GET: Articulos/Create
        public ActionResult Create()
        {
            Response.AppendHeader("Cache-Control", "no-store");
            var SesionIniciada = db.Usuarios.Where(x => x.Sesion == true).ToList();
            if (SesionIniciada.Count() > 0)
            {
                return View();
            }
            else
            {
                return RedirectToAction("LogIn", "LogIn", null);
            }
        }

        // POST: Articulos/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdArticulo,NombreArt,CantidadArt,DescripcionArt")] Articulos articulos)
        {
            if (ModelState.IsValid)
            {
                db.Articulos.Add(articulos);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(articulos);
        }

        // GET: Articulos/Edit/5
        public ActionResult Edit(int? id)
        {
            Response.AppendHeader("Cache-Control", "no-store");
            var SesionIniciada = db.Usuarios.Where(x => x.Sesion == true).ToList();
            if (SesionIniciada.Count() > 0)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Articulos articulos = db.Articulos.Find(id);
                if (articulos == null)
                {
                    return HttpNotFound();
                }
                return View(articulos);
            }
            else
            {
                return RedirectToAction("LogIn", "LogIn", null);
            }

        }

        // POST: Articulos/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdArticulo,NombreArt,CantidadArt,DescripcionArt")] Articulos articulos)
        {
            if (ModelState.IsValid)
            {
                db.Entry(articulos).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(articulos);
        }

        // GET: Articulos/Delete/5
        public ActionResult Delete(int? id)
        {
            Response.AppendHeader("Cache-Control", "no-store");
            var SesionIniciada = db.Usuarios.Where(x => x.Sesion == true).ToList();
            if (SesionIniciada.Count() > 0)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Articulos articulos = db.Articulos.Find(id);
                if (articulos == null)
                {
                    return HttpNotFound();
                }
                return View(articulos);
            }
            else
            {
                return RedirectToAction("LogIn", "LogIn", null);
            }
        }

        // POST: Articulos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Articulos articulos = db.Articulos.Find(id);
            db.Articulos.Remove(articulos);
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
