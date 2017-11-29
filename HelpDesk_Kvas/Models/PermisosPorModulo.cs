namespace HelpDesk_Kvas.Models
{
    using HelpDesk_Kvas.Seguridad.Permisos;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PermisosPorModulo")]
    public partial class PermisosPorModulo
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IdPermiso { get; set; }
        //public RolesPermisos IdPermiso { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IdModulo { get; set; }

        [Required]
        [StringLength(80)]
        public string Descripcion { get; set; }

        public virtual GruposDetalles GruposDetalles_IdModulo { get; set; }

        public virtual GruposDetalles GruposDetalles_IdPermiso { get; set; }
    }
}