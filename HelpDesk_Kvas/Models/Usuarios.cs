namespace HelpDesk_Kvas.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Usuarios
    {
        [Key]
        public int IdUsuario { get; set; }

        [Required]
        [StringLength(30)]
        public string NombreUsuario { get; set; }

        [Required]
        [StringLength(100)]
        public string Contrasena { get; set; }

        public int IdRol { get; set; }

        public int IdPreguntaSeguridad { get; set; }

        [Required]
        [StringLength(50)]
        public string RespuestaSeguridad { get; set; }

        public DateTime? FechaLogin { get; set; }

        public int ContadorFallido { get; set; }

        public bool Estatus { get; set; }

        public DateTime FechaRegistro { get; set; }

        public DateTime? FechaModificacion { get; set; }

        public virtual GruposDetalles GruposDetalles_Seg { get; set; }

        public virtual GruposDetalles GruposDetalles_Rol { get; set; }

        public Usuarios Obtener(int id)
        {
            var usuario = new Usuarios();
            try
            {

            }
            catch (Exception)
            {
                throw;
            }
            return usuario;
        }
    }
}