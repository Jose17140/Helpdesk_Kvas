using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HelpDesk_Kvas.Models.Datos.Entity
{
    public class BitacorasEntity : UsuariosEntity
    {
        [Key]
        public int IdBitacora { get; set; }

        public int IdRequerimiento { get; set; }

        [Display(Name = "Rol:")]
        public int IdRoles { get; set; }

        [Display(Name = "Rol:")]
        public string Rol { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Nombre:")]
        public string Observaciones { get; set; }

        [Display(Name = "Leido:")]
        public bool Leido { get; set; }

        //[DataType(DataType.Date)]
        //[Display(Name = "Fecha de Registro:")]
        //public DateTime FechaRegistro { get; set; }
    }
}