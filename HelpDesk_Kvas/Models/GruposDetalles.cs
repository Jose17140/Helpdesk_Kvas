namespace HelpDesk_Kvas.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class GruposDetalles
    {
        public GruposDetalles()
        {
            ICollection = new HashSet<GruposDetalles>();
        }

        [Key]
        public int IdGrupoDetalle { get; set; }

        public string Nombre { get; set; }

        public string Descripcion { get; set; }

        public int Orden { get; set; }

        public int IdGrupo { get; set; }

        public int IdPadre { get; set; }

        public string Icono { get; set; }

        public string UrlDetalle { get; set; }

        public bool Estatus { get; set; }

        public DateTime FechaRegistro { get; set; }

        public virtual ICollection<GruposDetalles> ICollection { get; set; }

        public virtual GruposDetalles GruposDetallesR { get; set; }
    }
}
