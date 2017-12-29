using System;
using System.Linq;
using System.Collections.Generic;
using HelpDesk_Kvas.Models.Datos.Entity;
using HelpDesk_Kvas.Models.Datos.DAL;

namespace HelpDesk_Kvas.Models.Datos.Logica
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

        public IEnumerable<GruposEntity> ListarNivel(int _id)
        {
            return objGrupoDAL.ListarNivelGrupo(_id);
        }

        public GruposEntity Buscar(int _id)
        {
            return objGrupoDAL.Buscar(_id);
            
        }

        public IEnumerable<GruposEntity> ListarUnGrupo(int _id)
        {
            return objGrupoDAL.ListarUnGrupo(_id);
        }
    }
}
