//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MiTienda.Controllers
{
    using System;
    using System.Collections.Generic;
    
    public partial class MetodoPago
    {
        public int Id { get; set; }
        public Nullable<int> id_usuario { get; set; }
        public Nullable<int> numeracion { get; set; }
        public string fecha { get; set; }
        public Nullable<int> cvv { get; set; }
    
        public virtual Usuarios Usuarios { get; set; }
    }
}
