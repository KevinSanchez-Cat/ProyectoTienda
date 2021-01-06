using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProyectoTienda.Models;


namespace ProyectoTienda.Controllers
{

    public class CatalogoController : Controller
    {
        private ContextTienda db = new ContextTienda();
        // GET: Catalogo
        public ActionResult Catalogo()
        {
            return View();
        }

        [HttpPost]

    }
}