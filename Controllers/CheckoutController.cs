using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProyectoTienda.Models;
namespace ProyectoTienda.Controllers
{
    public class CheckoutController : Controller
    {
        // GET: Checkout
 
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult CrearOrden()
        {

            if (!User.Identity.IsAuthenticated) {
                Session["CrearOrden"] = "pend";
                return RedirectToAction("Login","Account");
            }
            var orden = new Orden_Cliente();
            var bd = new ContextTienda();



            return View();
        }
    }
}