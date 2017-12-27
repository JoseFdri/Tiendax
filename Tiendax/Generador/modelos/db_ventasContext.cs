namespace Generador.modelos
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class db_ventasContext : DbContext
    {
        public db_ventasContext()
            : base("name=db_ventasContext")
        {
        }

        public virtual DbSet<boleta_cab> boleta_cab { get; set; }
        public virtual DbSet<boleta_det> boleta_det { get; set; }
        public virtual DbSet<categoria> categoria { get; set; }
        public virtual DbSet<factura_cab> factura_cab { get; set; }
        public virtual DbSet<factura_det> factura_det { get; set; }
        public virtual DbSet<producto> producto { get; set; }
        public virtual DbSet<usuario> usuario { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<boleta_cab>()
                .Property(e => e.nombre)
                .IsUnicode(false);

            modelBuilder.Entity<boleta_cab>()
                .Property(e => e.direccion)
                .IsUnicode(false);

            modelBuilder.Entity<categoria>()
                .Property(e => e.descripcion)
                .IsUnicode(false);

            modelBuilder.Entity<factura_cab>()
                .Property(e => e.ruc)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<factura_cab>()
                .Property(e => e.razon_social)
                .IsUnicode(false);

            modelBuilder.Entity<factura_cab>()
                .Property(e => e.direccion)
                .IsUnicode(false);

            modelBuilder.Entity<producto>()
                .Property(e => e.codigo)
                .IsUnicode(false);

            modelBuilder.Entity<producto>()
                .Property(e => e.nombre)
                .IsUnicode(false);

            modelBuilder.Entity<producto>()
                .Property(e => e.descripcion)
                .IsUnicode(false);

            modelBuilder.Entity<producto>()
                .Property(e => e.precio)
                .HasPrecision(19, 4);

            modelBuilder.Entity<usuario>()
                .Property(e => e.nombre)
                .IsUnicode(false);

            modelBuilder.Entity<usuario>()
                .Property(e => e.password)
                .IsUnicode(false);
        }
    }
}
