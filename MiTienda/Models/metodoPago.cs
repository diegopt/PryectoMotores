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
    
    public partial class metodoPago
    {
        public int Id_pago { get; set; }
        public Nullable<int> numeracion { get; set; }
        public Nullable<System.DateTime> fecha { get; set; }
        public Nullable<int> cvv { get; set; }
        public int id_cliente { get; set; }
    
        public virtual clientes clientes { get; set; }
    }
}
