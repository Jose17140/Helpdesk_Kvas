using KvasDAL;
using KvasEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KvasLogic
{
    public class GruposDetalleLogic
    {
        private GrupoDetalleDAL objDetalleDAL;
        private bool validacion = true;
        public GruposDetalleLogic()
        {
            objDetalleDAL = new GrupoDetalleDAL();
        }

        public IEnumerable<GruposDetallesEntity> Listar()
        {
            return objDetalleDAL.Listar();
        }
    }
}
