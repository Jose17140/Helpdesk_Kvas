namespace HelpDesk_Kvas.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Usuarios
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Usuarios()
        {
            UsuariosRoles = new HashSet<UsuariosRoles>();
        }

        [Key]
        public int IdUsuario { get; set; }

        [StringLength(30)]
        [Display(Name = "Nombre de Usuario")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Nombre de Usuario es Requerido")]
        public string NombreUsuario { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "El número de caracteres de {0} debe ser al menos {2}.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Contraseña")]
        public string Contrasena { get; set; }

        [StringLength(60)]
        [Required]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Correo electrónico")]
        public string IdEmail { get; set; }

        [Display(Name = "Nombre de Usuario")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Debe seleccionar una pregunta de suguridad")]
        public int IdPreguntaSeguridad { get; set; }

        [Display(Name = "Nombre de Usuario")]
        [Required]
        [StringLength(50, ErrorMessage = "La Respuesta debe contener minimo 6 caracteres y maximo 50 caracteres", MinimumLength = 6)]
        public string RespuestaSeguridad { get; set; }

        [Required]
        [StringLength(30)]
        public string Avatar { get; set; }

        public DateTime? FechaLogin { get; set; }

        public int ContadorFallido { get; set; }

        [Display(Name = "Estatus")]
        public bool Estatus { get; set; }

        public DateTime FechaRegistro { get; set; }

        public DateTime? FechaModificacion { get; set; }

        public virtual GruposDetalles PreguntaSeguridad { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<UsuariosRoles> UsuariosRoles { get; set; }
    }

    public class RegisterViewModel : Usuarios
    {

        [DataType(DataType.Password)]
        [Display(Name = "Confirmar contraseña")]
        [Compare("Password", ErrorMessage = "La contraseña y la contraseña de confirmación no coinciden.")]
        public string ConfirmPassword { get; set; }
    }

    public class LoginViewModel
    {
        [Required]
        [Display(Name = "Correo electrónico")]
        [EmailAddress]
        public string NombreUsuario { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Contraseña")]
        public string Password { get; set; }

        [Display(Name = "¿Recordar cuenta?")]
        public bool RememberMe { get; set; }
    }
}