//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MiTienda.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class paqueterias
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public paqueterias()
        {
            this.ordenCliente = new HashSet<ordenCliente>();
        }
    
        public int Id_paqueteria { get; set; }
        public string nombre { get; set; }
        public string rfc { get; set; }
        public string telefono { get; set; }
        public string web { get; set; }
        public string direccion { get; set; }
        public Nullable<int> telContacto { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ordenCliente> ordenCliente { get; set; }
    }
}
