﻿//------------------------------------------------------------------------------
// <auto-generated>
//    Este código se generó a partir de una plantilla.
//
//    Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//    Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MadScienceAdo
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class MADSCIENCEEntities : DbContext
    {
        public MADSCIENCEEntities()
            : base("name=MADSCIENCEEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<tb_asignacion> tb_asignacion { get; set; }
        public DbSet<tb_detalle_reserva> tb_detalle_reserva { get; set; }
        public DbSet<tb_disponibilidad> tb_disponibilidad { get; set; }
        public DbSet<tb_especialidad> tb_especialidad { get; set; }
        public DbSet<tb_fiesta> tb_fiesta { get; set; }
        public DbSet<tb_fiesta_evento> tb_fiesta_evento { get; set; }
        public DbSet<tb_horario> tb_horario { get; set; }
        public DbSet<tb_pago_fiesta> tb_pago_fiesta { get; set; }
        public DbSet<tb_reserva> tb_reserva { get; set; }
        public DbSet<tb_sabor> tb_sabor { get; set; }
        public DbSet<tb_tienda> tb_tienda { get; set; }
        public DbSet<tb_tipo_evento> tb_tipo_evento { get; set; }
        public DbSet<tb_tipo_fiesta> tb_tipo_fiesta { get; set; }
        public DbSet<tb_tipo_pago> tb_tipo_pago { get; set; }
        public DbSet<tb_torta> tb_torta { get; set; }
        public DbSet<tb_trabajador> tb_trabajador { get; set; }
        public DbSet<tb_usuario> tb_usuario { get; set; }
        public DbSet<tb_zona> tb_zona { get; set; }
    }
}
