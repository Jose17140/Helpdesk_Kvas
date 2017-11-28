namespace HelpDesk_Kvas.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class DAL_Main : DbContext
    {
        public DAL_Main()
            : base("name=DefaultConnection")
        {
        }

        public virtual DbSet<GruposDetalles> GruposDetalles { get; set; }
        public virtual DbSet<Usuarios> Usuarios { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GruposDetalles>()
                .Property(e => e.Nombre)
                .IsUnicode(false);

            modelBuilder.Entity<GruposDetalles>()
                .Property(e => e.Descripcion)
                .IsUnicode(false);

            modelBuilder.Entity<GruposDetalles>()
                .Property(e => e.UrlDetalle)
                .IsUnicode(false);

            modelBuilder.Entity<GruposDetalles>()
                .HasMany(e => e.ICollection)
                .WithOptional(e => e.GruposDetallesR)
                .HasForeignKey(e => e.IdPadre);

            modelBuilder.Entity<GruposDetalles>()
                .HasMany(e => e.Usuarios_Seg)
                .WithRequired(e => e.GruposDetalles_Seg)
                .HasForeignKey(e => e.IdPreguntaSeguridad)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<GruposDetalles>()
                .HasMany(e => e.Usuarios_Rol)
                .WithRequired(e => e.GruposDetalles_Rol)
                .HasForeignKey(e => e.IdRol)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<GruposDetalles>()
                .HasMany(e => e.GruposDetalles_Permiso)
                .WithMany(e => e.GruposDetalles_Rol)
                .Map(m => m.ToTable("RolesPermisos").MapLeftKey("IdPermiso").MapRightKey("IdRol"));

            modelBuilder.Entity<Usuarios>()
                .Property(e => e.NombreUsuario)
                .IsUnicode(false);

            modelBuilder.Entity<Usuarios>()
                .Property(e => e.Contrasena)
                .IsUnicode(false);

            modelBuilder.Entity<Usuarios>()
                .Property(e => e.RespuestaSeguridad)
                .IsUnicode(false);
        }
    }
}
