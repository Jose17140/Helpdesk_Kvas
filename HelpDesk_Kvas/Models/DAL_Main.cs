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

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GruposDetalles>()
                .Property(e => e.Nombre)
                .IsUnicode(false);

            modelBuilder.Entity<GruposDetalles>()
                .Property(e => e.Descripcion)
                .IsUnicode(false);

            modelBuilder.Entity<GruposDetalles>()
                .HasMany(e => e.ICollection)
                .WithRequired(e => e.GruposDetallesR)
                .HasForeignKey(e => e.IdPadre);
        }
    }
}
