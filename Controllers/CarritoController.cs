using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProyectoTienda.Models;
namespace ProyectoTienda.Controllers
{
    public class CarritoController : Controller
    {
        // GET: Carrito
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Agregar(int id)
        {
            ProdCarro carro = new ProdCarro();
            if (Session["cart"] == null)
            {
                List<Item> cart = new List<Item>();
                Producto p = carro.find(id);
                string nam = p.nombre_producto;
                cart.Add(new Item { Producto = carro.find(id), Cantidad = 1 });
                Session["cart"] = cart;
            }
            else
            {
                List<Item> cart = (List<Item>)Session["cart"];
                int index = isExist(id);
                if (index != -1)
                {
                    cart[index].Cantidad++;
                }
                else
                {
                    Producto p = carro.find(id);
                    string nam = p.nombre_producto;
                    cart.Add(new Item { Producto = carro.find(id), Cantidad = 1 });
                }
                Session["cart"] = cart;
            }
            return RedirectToAction("Index");
        }
        private int isExist(int id)
        {
            List<Item> cart = (List<Item>)Session["cart"];
            for (int i = 0; i < cart.Count; i++)
            {
                if (cart[i].Producto.Id_producto.Equals(id))
                {
                    return i;
                }

            }
            return -1;
        }
        public ActionResult Quitar(int id)
        {
            List<Item> cart = (List<Item>)Session["cart"];
            int index = isExist(id);
            cart.RemoveAt(index);
            Session["cart"] = cart;
            return RedirectToAction("Index");
        }
    }
}
