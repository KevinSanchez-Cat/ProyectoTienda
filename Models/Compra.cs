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
    
    public partial class Compra
    {
        public int Id_compra { get; set; }
        public Nullable<double> total { get; set; }
        public Nullable<int> id_cliente { get; set; }
        public Nullable<System.DateTime> fecha_compra { get; set; }
        public Nullable<int> id_direccion_entrega { get; set; }
    }
}
