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
    
    public partial class Paqueteria
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Paqueteria()
        {
            this.Oden_cliente = new HashSet<Oden_cliente>();
        }
    
        public int id_paqueteria { get; set; }
        public string nombre_paqueteria { get; set; }
        public int telefono { get; set; }
        public string sitio_web { get; set; }
        public int rfc { get; set; }
        public string contacto { get; set; }
        public int telefono_contacto { get; set; }
        public int id_direccion { get; set; }
    
        public virtual Direccion Direccion { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Oden_cliente> Oden_cliente { get; set; }
    }
}
