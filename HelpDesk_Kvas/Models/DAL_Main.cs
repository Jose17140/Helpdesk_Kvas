namespace HelpDesk_Kvas.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class DAL_Main : DbContext
    {
        public DAL_Main()
            : base("name=Helpdesk_KvasConnectionString")
        {
        }

        public virtual DbSet<GruposDetalles> GruposDetalles { get; set; }
        public virtual DbSet<Usuarios> Usuarios { get; set; }
        public virtual DbSet<UsuariosRoles> UsuariosRoles { get; set; }

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
                .WithRequired(e => e.PreguntaSeguridad)
                .HasForeignKey(e => e.IdPreguntaSeguridad)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<GruposDetalles>()
                .HasMany(e => e.Usuarios_Rol)
                .WithRequired(e => e.Roles)
                .HasForeignKey(e => e.IdRoles)
                .WillCascadeOnDelete(false);
           
            modelBuilder.Entity<Usuarios>()
                .Property(e => e.NombreUsuario)
                .IsUnicode(false);

            modelBuilder.Entity<Usuarios>()
                .Property(e => e.Contrasena)
                .IsUnicode(false);

            modelBuilder.Entity<Usuarios>()
               .Property(e => e.IdEmail)
               .IsUnicode(false);

            modelBuilder.Entity<Usuarios>()
                .Property(e => e.RespuestaSeguridad)
                .IsUnicode(false);

            modelBuilder.Entity<Usuarios>()
                .Property(e => e.Avatar)
                .IsUnicode(false);

            modelBuilder.Entity<Usuarios>()
                .HasMany(e => e.UsuariosRoles)
                .WithRequired(e => e.Usuarios)
                .WillCascadeOnDelete(false);
        }
    }
}
