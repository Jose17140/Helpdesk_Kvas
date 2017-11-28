using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HelpDesk_Kvas.Seguridad.Permisos
{
    public enum RolesPermisos
    {
        /// <summary>
        /// Permisos Por Modulos o en General
        /// C = CREAR
        /// R = LEER
        /// U = ACTUALIZAR
        /// D = ELIMINAR
        /// </summary>
        #region HelpDesk
        C = 2,
        R = 3,
        D = 4,
        #endregion
    }
}