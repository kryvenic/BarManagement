﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace InfoBAR
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class InfobarEntities : DbContext
    {
        public InfobarEntities()
            : base("name=InfobarEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Detalle_Pedido> Detalle_Pedido { get; set; }
        public virtual DbSet<Pedido> Pedidoes { get; set; }
        public virtual DbSet<Producto> Productoes { get; set; }
        public virtual DbSet<TipoPago> TipoPagoes { get; set; }
        public virtual DbSet<TipoProducto> TipoProductoes { get; set; }
        public virtual DbSet<TipoUsuario> TipoUsuarios { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }
    }
}
