using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoTienda.Models
{
    public class Item
    {
        public Producto Producto
        {
            get;
            set;
        }
        public int Cantidad
        {
            get;
            set;
        }
    }
}