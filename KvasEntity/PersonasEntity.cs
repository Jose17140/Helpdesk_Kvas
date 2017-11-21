using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KvasEntity
{
    public class PersonasEntity
    {
        [Key]
        public int IdPersona { get; set; }

        [Required]
        public string Nombres { get; set; }

        [Required]
        public int IdTipoPersona { get; set; }

        [Required]
        public string CiRif { get; set; }

        [Required]
        public string Direccion { get; set; }

        [Required]
        public string Telefonos { get; set; }

        public string Email { get; set; }
        
        public string Imagen { get; set; }

        public DateTime FechaRegistro { get; set; }

        public int Mensaje { get; set; }
    }
}
