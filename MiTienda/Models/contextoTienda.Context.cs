﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class MotoresEntities : DbContext
    {
        public MotoresEntities()
            : base("name=MotoresEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<categorias> categorias { get; set; }
        public virtual DbSet<datosEnvio> datosEnvio { get; set; }
        public virtual DbSet<Empleado> Empleado { get; set; }
        public virtual DbSet<metodoPago> metodoPago { get; set; }
        public virtual DbSet<ordenCliente> ordenCliente { get; set; }
        public virtual DbSet<ordenProducto> ordenProducto { get; set; }
        public virtual DbSet<paqueterias> paqueterias { get; set; }
        public virtual DbSet<productos> productos { get; set; }
        public virtual DbSet<Roles> Roles { get; set; }
        public virtual DbSet<usuarios> usuarios { get; set; }
    }
}