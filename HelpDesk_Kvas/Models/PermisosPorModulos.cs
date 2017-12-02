namespace HelpDesk_Kvas.Models
{
    using HelpDesk_Kvas.Seguridad.Permisos;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PermisosPorModulo")]
    public partial class PermisosPorModulos
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PermisosPorModulos()
        {
            GruposDetalles_IdModulo = new HashSet<GruposDetalles>();
        }

        [Key]
        public int IdPermiso { get; set; }
        //public RolesPermisos IdPermiso { get; set; }

        public int IdModulo { get; set; }

        [Required]
        [StringLength(80)]
        public string Descripcion { get; set; }

        public virtual GruposDetalles GruposDetalles { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GruposDetalles> GruposDetalles_IdModulo { get; set; }
    }
}