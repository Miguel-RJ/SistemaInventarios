using SistemaInventarios.Models;
using SistemaInventarios.Models.AppDBContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SistemaInventarios.Controllers
{
    public class IndexController : Controller
    {
        // GET: Index
        public ActionResult Index(Usuarios user)
        {
            return View(user);
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