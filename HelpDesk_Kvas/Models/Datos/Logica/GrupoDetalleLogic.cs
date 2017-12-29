using HelpDesk_Kvas.Models.Datos.DAL;
using HelpDesk_Kvas.Models.Datos.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelpDesk_Kvas.Models.Datos.Logica
{
    public class GrupoDetalleLogic
    {
        private GrupoDetalleDAL objDetalleDAL;
        private GrupoDAL objGrupoDAL;
        dbDataContext db;
        public GrupoDetalleLogic()
        {
            objDetalleDAL = new GrupoDetalleDAL();
            objGrupoDAL = new GrupoDAL();
            db = new dbDataContext();
        }

        public void Insertar(GruposDetallesEntity objGrupo)
        {
            try
            {
                objDetalleDAL.Insertar(objGrupo);
                objGrupo.Mensaje = 99;
                return;
            }
            catch
            {
                objGrupo.Mensaje = 1;
            }
        }

        public void Actualizar(GruposDetallesEntity objGrupo)
        {
            try
            {
                objDetalleDAL.Actualizar(objGrupo);
                objGrupo.Mensaje = 98;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Eliminar(GruposDetallesEntity objGrupo)
        {
            try
            {
                objDetalleDAL.Eliminar(objGrupo);
                objGrupo.Mensaje = 99;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public IEnumerable<GruposDetallesEntity> Listar()
        {
            return objDetalleDAL.Listar();
        }

        public GruposDetallesEntity Buscar(int _idGrupo)
        {
            return objDetalleDAL.Buscar(_idGrupo);

        }

        public IEnumerable<GruposDetallesView> ListarPorGrupo(int _idGrupo)
        {
            return objDetalleDAL.ListaPorGrupoSP(_idGrupo);
        }

        public IEnumerable<GruposDetallesView> ListarView()
        {
            return objDetalleDAL.ListarView();
        }

        public GruposDetallesView BuscarPadre(int _IdGrupo)
        {
            return objDetalleDAL.BuscarPadre(_IdGrupo);
        }
    }
}
