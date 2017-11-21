using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KvasDAL
{
    public class MenuDAL
    {
        dbDataContext db;

        public MenuDAL()
        {
            db = new dbDataContext();
        }

        public ICollection<GruposDetalles> Lista()
        {
            var lista = (from m in db.GruposDetalles
                         where m.Estatus == true && (m.IdGrupo == 1 && m.IdPadre == 0)
                         orderby m.Orden ascending
                         select m).ToList();
            return lista;
        }
    }
}
