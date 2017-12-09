namespace HelpDesk_Kvas.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Web;

    public partial class UsuariosRoles
    {
        [Key]
        public int IdUserRoles { get; set; }

        public int IdUsuario { get; set; }

        public int IdRoles { get; set; }

        public virtual GruposDetalles Roles { get; set; }

        public virtual Usuarios Usuarios { get; set; }
    }
}