using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PagedList;

namespace HelpDesk_Kvas.Models.Datos.Entity
{
    public class ViewModel
    {
        public IEnumerable<GruposDetalles> Nv1 { get; set; }
        public IEnumerable<GruposDetalles> Nv2 { get; set; }
        public IEnumerable<GruposDetalles> Nv3 { get; set; }
        public IEnumerable<GruposEntity> Grupo { get; set; }
    }
}