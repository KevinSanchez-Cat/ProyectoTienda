//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ProyectoTienda.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Detalle_compra
    {
        public int Id_compra { get; set; }
        public int id_producto { get; set; }
        public int cantidad { get; set; }
        public decimal subtotal { get; set; }
    
        public virtual Compra Compra { get; set; }
        public virtual Producto Producto { get; set; }
    }
}
