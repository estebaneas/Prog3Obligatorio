﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DataAccess.Model
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class ControlDeReclamosEntities : DbContext
    {
        public ControlDeReclamosEntities()
            : base("name=ControlDeReclamosEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<tipoReclamo> tipoReclamo { get; set; }
        public virtual DbSet<usuario> usuario { get; set; }
        public virtual DbSet<punto> punto { get; set; }
        public virtual DbSet<cuadrilla> cuadrilla { get; set; }
        public virtual DbSet<reclamo> reclamo { get; set; }
        public virtual DbSet<zona> zona { get; set; }
        public virtual DbSet<historialDeCambios> historialDeCambios { get; set; }
    }
}
