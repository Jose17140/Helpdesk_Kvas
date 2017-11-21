using KvasDAL;
using KvasEntity;
using System;
using System.Linq;
using System.Collections.Generic;

namespace KvasLogic
{
    public class GrupoLogic
    {
        private GrupoDAL objGrupoDAL;
        dbDataContext db;
        public GrupoLogic()
        {
            objGrupoDAL = new GrupoDAL();
            db = new dbDataContext();
        }

        public void Insertar(GruposEntity objGrupo)
        {
            try
            {
                objGrupoDAL.Insertar(objGrupo);
                objGrupo.Mensaje = 99;
                return;
            }
            catch
            {
                objGrupo.Mensaje = 1;
            }
        }

        public void Actualizar(GruposEntity objGrupo)
        {
            try
            {
                objGrupoDAL.Actualizar(objGrupo);
                objGrupo.Mensaje = 98;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Eliminar(GruposEntity objGrupo)
        {
            try
            {
                objGrupoDAL.Eliminar(objGrupo);
                objGrupo.Mensaje = 99;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public IEnumerable<GruposEntity> Listar()
        {
            return objGrupoDAL.Listar();
        }

        public GruposEntity Buscar(int _id)
        {
            return objGrupoDAL.Buscar(_id);
            
        } 
    }
}
