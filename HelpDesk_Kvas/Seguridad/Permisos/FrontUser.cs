using HelpDesk_Kvas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HelpDesk_Kvas.Seguridad.Permisos
{
    public class FrontUser
    {
        public static bool TienePermiso(RolesPermisos valor)
        {
            var usuario = FrontUser.Get();
            return !usuario.GruposDetalles_Rol.GruposDetalles_Permiso.Where(x => x.PermisoID == valor)
                               .Any();
        }

        public static Usuarios Get()
        {
            return new Usuarios().Obtener(SessionHelper.GetUser());
        }
    }
}