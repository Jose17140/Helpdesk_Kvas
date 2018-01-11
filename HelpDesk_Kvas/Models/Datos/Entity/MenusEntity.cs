using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelpDesk_Kvas.Models.Datos.Entity
{
    public partial class MenusEntity
    {
        public MenusEntity()
        {
            this.GruposDetalles1 = new HashSet<MenusEntity>();
        }

        public int IdGrupoDetalle { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int Orden { get; set; }
        public int IdGrupo { get; set; }
        public int IdPadre { get; set; }
        public string Icono { get; set; }
        public string UrlDetalle { get; set; }
        public bool Estatus { get; set; }
        public System.DateTime FechaRegistro { get; set; }
        public virtual ICollection<MenusEntity> GruposDetalles1 { get; set; }
    }
}
