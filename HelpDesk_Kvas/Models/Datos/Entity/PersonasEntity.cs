using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelpDesk_Kvas.Models.Datos.Entity
{
    public class PersonasEntity
    {
        [Key]
        public int IdPersona { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Nombres:")]
        public string Nombres { get; set; }

        [Required]
        [Display(Name = "Identificacion:")]
        public int IdTipoPersona { get; set; }

        [Required]
        [StringLength(11)]
        [Display(Name = "Cedula:")]
        public string CiRif { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "Direccion:")]
        public string Direccion { get; set; }

        [Required]
        [StringLength(60)]
        [Display(Name = "Telefonos:")]
        public string Telefonos { get; set; }

        [StringLength(60)]
        [Required]
        [Display(Name = "Correo:")]
        [EmailAddress]
        public string Email { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Fecha de Registro:")]
        public DateTime FechaRegistro { get; set; }

        [Display(Name = "Identificacion")]
        public string Identificacion { get; set; }

        [Display(Name = "Identificacion")]
        public string FullCedula
        {
            get
            {
                return IdTipoPersona + ", " + CiRif;
            }
        }

        public int Mensaje { get; set; }
    }
}