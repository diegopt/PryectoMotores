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
    
    public partial class productos
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public productos()
        {
            this.ordenProducto = new HashSet<ordenProducto>();
        }
    
        public int Id_producto { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public Nullable<double> precio { get; set; }
        public Nullable<System.DateTime> ult_actualizacion { get; set; }
        public string imagen { get; set; }
        public Nullable<int> existencia { get; set; }
        public Nullable<int> stock { get; set; }
        public int id_categoria { get; set; }
    
        public virtual categorias categorias { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ordenProducto> ordenProducto { get; set; }
    }
}
