using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelpDesk_Kvas.Models.Datos.Entity
{
    public class UsuariosEntity
    {
        [Key]
        public int IdUsuario { get; set; }

        [Required]
        [StringLength(30)]
        [Display(Name = "Nombre de Usuario")]
        public string UserName { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "El número de caracteres de {0} debe ser al menos {2}.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Contraseña")]
        public string Password { get; set; }

        [Display(Name = "Pregunta de Seguridad")]
        public int? IdPregunta { get; set; }

        [StringLength(50, ErrorMessage = "El número de caracteres de {0} debe ser al menos {2}.", MinimumLength = 6)]
        [Display(Name = "Respuesta:")]
        public string RespuestaSeguridad { get; set; }

        [StringLength(30)]
        [Display(Name = "Avatar")]
        public string Avatar { get; set; }

        [Display(Name = "Estatus")]
        public bool Estatus { get; set; }

        [DataType(DataType.DateTime)]
        [Display(Name = "Fecha de Modificacion:")]
        public DateTime? FechaModificacion { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Fecha de Registro:")]
        public DateTime FechaRegistro { get; set; }

        public int Mensaje { get; set; }
    }

    public class ForgotUserEntity
    {
        [Display(Name = "Pregunta de Seguridad")]
        public int? IdPregunta { get; set; }

        [Required]
        [Display(Name = "Nombre de Usuario")]
        public string UserName { get; set; }

        [StringLength(50, ErrorMessage = "El número de caracteres de {0} debe ser al menos {2}.", MinimumLength = 6)]
        [Display(Name = "Respuesta:")]
        public string RespuestaSeguridad { get; set; }
    }

    public class LoginUserEntity
    {
        [Required]
        [StringLength(30)]
        [Display(Name = "Nombre de Usuario")]
        public string UserName { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "El número de caracteres de {0} debe ser al menos {2}.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Contraseña")]
        public string Password { get; set; }

        [DataType(DataType.DateTime)]
        [Display(Name = "Fecha de Login:")]
        public DateTime? FechaLogin { get; set; }

        public int? ContadorFallido { get; set; }
        
        [Display(Name = "Estatus")]
        public bool Estatus { get; set; }

        [Display(Name = "¿Recordar cuenta?")]
        public bool RememberMe { get; set; }

        public int? Mensaje { get; set; }
    }

    public class RegisterUserEntity : UsuariosEntity
    {
        [Display(Name = "Roles")]
        public int? IdRoles { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirmar contraseña")]
        [Compare("Password", ErrorMessage = "La contraseña y la contraseña de confirmación no coinciden.")]
        public string ConfirmPassword { get; set; }

        [Display(Name = "Color de formularios")]
        public string FormColor { get; set; }
    }

    public class RecuperarContrasenaUserEntity
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Correo electrónico")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "El número de caracteres de {0} debe ser al menos {2}.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Contraseña")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirmar contraseña")]
        [Compare("Password", ErrorMessage = "La contraseña y la contraseña de confirmación no coinciden.")]
        public string ConfirmPassword { get; set; }
    }

    public class ForgotPasswordUserEntity
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Correo electrónico")]
        public string Email { get; set; }
    }

    public class UsuariosEntityView : RegisterUserEntity
    {
        public string Pregunta { get; set; }
        public string Roles { get; set; }
    }
    
    public class UsuarioLogEntity
    {
        public int IdUsuario { get; set; }

        public string UserName { get; set; }

        public string Avatar { get; set; }

        public string Rol { get; set; }

        public string Color { get; set; }

        public DateTime FechaLogin { get; set; }

    }

    public class UsuarioViewEntity 
    {
        #region DATOS DEL USUARIO
        public int IdUsuario { get; set; }
        
        [Display(Name = "Nombre de Usuario")]
        public string UserName { get; set; }

        [Display(Name = "Contrasena")]
        public string Password { get; set; }

        [Display(Name = "Roles")]
        public int IdRoles { get; set; }

        [Display(Name = "Roles")]
        public string Rol { get; set; }

        [Display(Name = "Pregunta de seguridad")]
        public int IdPregunta { get; set; }

        [Display(Name = "Pregunta de seguridad")]
        public string Pregunta { get; set; }

        [Display(Name = "Respuesta de seguridad")]
        public string Respuesta { get; set; }

        [Display(Name = "Avatar")]
        public string Avatar { get; set; }

        [Display(Name = "Fecha de login")]
        public DateTime Fechalogin { get; set; }

        [Display(Name = "Contador de inicio")]
        public int Contador { get; set; }

        [Display(Name = "Estatus")]
        public bool Estatus { get; set; }

        [Display(Name = "Color")]
        public string Color { get; set; }

        [Display(Name = "Fecha de Registro")]
        public DateTime FechaRegistroUsuario { get; set; }

        [Display(Name = "Fecha de Modificacion")]
        public DateTime Modificacion { get; set; }
        #endregion
        #region DATOS CLIENTE
        public int IdPersona { get; set; }
        
        [StringLength(50)]
        [Display(Name = "Nombres:")]
        public string Nombres { get; set; }
        
        [Display(Name = "Identificacion:")]
        public int IdTipoPersona { get; set; }

        [Display(Name = "Identificacion:")]
        public string TipoPersona { get; set; }
        
        [StringLength(11)]
        [Display(Name = "Cedula:")]
        public string CiRif { get; set; }
        
        [StringLength(100)]
        [Display(Name = "Direccion:")]
        public string Direccion { get; set; }
        
        [StringLength(60)]
        [Display(Name = "Telefonos:")]
        public string Telefonos { get; set; }

        [StringLength(60)]
        [Display(Name = "Correo:")]
        [EmailAddress]
        public string Email { get; set; }

        [Display(Name = "Identificacion")]
        public string Identificacion { get { return TipoPersona + CiRif; } }

        [Display(Name = "Fecha de Registro")]
        public DateTime FechaRegistroPersona { get; set; }

        public int Mensaje { get; set; }
        #endregion
    }

    public class UsuarioRegisterA :RegisterUserEntity
    {
        #region DATOS CLIENTE
        public int IdPersona { get; set; }

        [StringLength(50)]
        [Display(Name = "Nombres:")]
        public string Nombres { get; set; }

        [Display(Name = "Identificacion:")]
        public int IdTipoPersona { get; set; }

        [Display(Name = "Identificacion:")]
        public string TipoPersona { get; set; }

        [StringLength(11)]
        [Display(Name = "Cedula:")]
        public string CiRif { get; set; }

        [StringLength(100)]
        [Display(Name = "Direccion:")]
        public string Direccion { get; set; }

        [StringLength(60)]
        [Display(Name = "Telefonos:")]
        public string Telefonos { get; set; }

        [StringLength(60)]
        [Display(Name = "Correo:")]
        [EmailAddress]
        public string Email { get; set; }

        [Display(Name = "Identificacion")]
        public string Identificacion { get { return TipoPersona + CiRif; } }

        [Display(Name = "Fecha de Registro")]
        public DateTime FechaRegistroPersona { get; set; }
        #endregion
    }
}
