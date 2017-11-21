using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KvasEntity
{
    public class GruposDetallesEntity
    {
        [Key]
        public int IdGrupoDetalle { get; set; }

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

        [Required(ErrorMessage = "Seleccione sin Categoria")]
        [Display(Name = "Entidad:")]
        public int IdGrupo { get; set; }

        [Required(ErrorMessage = "Seleccione sin Grupo")]
        [Display(Name = "Grupo Superior:")]
        public int IdPadre { get; set; }

        [StringLength(30)]
        [Display(Name = "Icono:")]
        public string Icono { get; set; }

        [Required]
        [StringLength(30)]
        [Display(Name = "Url de la Entidad:")]
        public string UrlDetalle { get; set; }

        [Display(Name = "Estatus:")]
        public bool Estatus { get; set; }

        [DataType(DataType.DateTime)]
        [Display(Name = "Fecha de Registro:")]
        public DateTime FechaRegistro { get; set; }

        public int Mensaje { get; set; }
    }

    public class GruposDetallesView
    {
        [Key]
        public int IdGrupoDetalle { get; set; }

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

        [Required(ErrorMessage = "Seleccione sin Categoria")]
        [Display(Name = "Entidad:")]
        public string IdGrupo { get; set; }

        [Required(ErrorMessage = "Seleccione sin Grupo")]
        [Display(Name = "Grupo Superior:")]
        public int IdPadre { get; set; }

        [StringLength(30)]
        [Display(Name = "Icono:")]
        public string Icono { get; set; }

        [Required]
        [StringLength(30)]
        [Display(Name = "Url de la Entidad:")]
        public string UrlDetalle { get; set; }

        [Display(Name = "Estatus:")]
        public bool Estatus { get; set; }

        [DataType(DataType.DateTime)]
        [Display(Name = "Fecha de Registro:")]
        public DateTime FechaRegistro { get; set; }

        public int Mensaje { get; set; }

    }
}
