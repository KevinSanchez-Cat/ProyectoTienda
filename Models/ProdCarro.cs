using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoTienda.Models
{
    public class ProdCarro
    {
        private ContextTienda db = new ContextTienda();
        private List<Producto> products;

        public ProdCarro()
        {
            products = db.Producto.ToList();

        }
        public List<Producto> findAll()
        {
            return this.products;
        }
        public Producto find(int id)
        {
            Producto pp = this.products.Single(p => p.Id_producto.Equals(id));
            return pp;
        }

    }
}