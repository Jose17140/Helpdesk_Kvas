using HelpDesk_Kvas.Models.Datos.DAL;
using HelpDesk_Kvas.Models.Datos.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HelpDesk_Kvas.Models.Datos.Logica
{
    public class MenuLogic
    {
        private GrupoDetalleDAL objDetalleDAL;
        private GrupoDAL objGrupoDAL;
        private MenuDAL objMenu;
        dbDataContext db;

        public MenuLogic()
        {
            objDetalleDAL = new GrupoDetalleDAL();
            objGrupoDAL = new GrupoDAL();
            objMenu = new MenuDAL();
            db = new dbDataContext();
        }

        public void Insertar(GruposDetallesEntity objGrupo)
        {
            try
            {
                objMenu.Insertar(objGrupo);
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
                objMenu.Actualizar(objGrupo);
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
                objMenu.Eliminar(objGrupo);
                objGrupo.Mensaje = 99;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public IEnumerable<GruposDetallesView> Listar()
        {
            return objMenu.Listar();
        }
    }
}