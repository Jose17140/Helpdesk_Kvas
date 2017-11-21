using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KvasEntity
{
    public class GruposEntity
    {
        [Key]
        public int IdGrupo { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Nombre:")]
        public string Titulo { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "Descripcion Completa:")]
        public string Descripcion { get; set; }

        [Display(Name = "Orden:")]
        public int Orden { get; set; }

        [StringLength(30)]
        [Display(Name = "Icono:")]
        public string Icono { get; set; }

        [Required]
        [StringLength(30)]
        [Display(Name = "Url de la tabla:")]
        public string UrlGrupo { get; set; }

        [Display(Name = "Estatus:")]
        public bool Estatus { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Fecha de Registro:")]
        public DateTime FechaRegistro { get; set; }

        public int Mensaje { get; set; }
    }
}
