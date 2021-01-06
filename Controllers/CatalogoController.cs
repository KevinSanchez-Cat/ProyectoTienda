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
        public ActionResult BuscaProd(string nomBuscar)
        {
            ViewBag.SearchKey = nomBuscar;
            using (db)
            {
                var query = from st in db.Producto
                            where st.nombre_producto.Contains(nomBuscar)

                            select st;

                var listProd = query.ToList();
                ViewBag.Listado = listProd;
            }

            return View();
        }
        public ActionResult prodCategoria(int idCat)
        {
            List<Producto> mercancia = null;
            var query = from p in db.Producto
                        where p.id_categoria == idCat
                        select p;
            if (idCat == 1)
            {
                List<Producto> motoresE1 = query.ToList();
                mercancia = motoresE1;
                ViewBag.cat = "Motores linea 1";
            }
            if (idCat == 2)
            {
                List<Producto> motoresE2 = query.ToList();
                mercancia = motoresE2;
                ViewBag.cat = "Motores linea 2";
            }
        }

    }
}