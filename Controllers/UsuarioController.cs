using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProyectoTienda.Models;
namespace ProyectoTienda.Controllers
{

    public class UsuarioController : Controller
    {
        private ContextTienda db = new ContextTienda();
        // GET: Usuario
        [Authorize]
        public ActionResult Index(string email)
        {
            if (User.Identity.IsAuthenticated)
            {

                string correo = email;
                string rol = "";
                if (correo.Contains("admin@Bull.motors.com"))
                {
                    return RedirectToAction("Index", "Administrador");
                }
                else
                {
                    using (db)
                    {
                        var query = from st in db.Empleado
                                    where st.email == correo
                                    select st;
                        var lista = query.ToList();
                        if (lista.Count > 0)
                        {
                            var empleado = query.FirstOrDefault<Empleado>();
                            string[] nombre = empleado.nombre_empleado.ToString().Split(' ');
                            Session["name"] = nombre[0];
                            Session["usr"] = empleado.nombre_empleado;
                            rol = empleado.rol.ToString().TrimEnd();
                        }
                        else
                        {
                            var query1 = from st in db.Cliente
                                         where st.email == correo
                                         select st;
                            var lista1 = query.ToList();
                            if (lista1.Count > 0)
                            {
                                var cliente = query1.FirstOrDefault<Cliente>();
                                string[] nombre = cliente.nombre_cliente.ToString().Split(' ');
                                Session["name"] = nombre[0];
                                Session["usr"] = cliente.nombre_cliente;
                                rol = "cliente";

                            }
                        }
                    }
                    if (rol == "enviador")
                    {
                        return RedirectToAction("Index", "DepEnvios");
                    }
                    if (rol == "despachador")
                    {
                        return RedirectToAction("Index", "DepCompras");
                    }
                    if (rol == "administrador")
                    {
                        return RedirectToAction("Index", "DepAdministracion");
                    }
                    if (rol == "empaquetador")
                    {
                        return RedirectToAction("Index", "DepPaqueteria");
                    }
                    if (rol == "productor")
                    {
                        return RedirectToAction("Index", "DepProduccion");
                    }
                    if (rol == "cliente")
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }
               

            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
            return RedirectToAction("Index", "Home");
        }
    }
}