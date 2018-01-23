using HelpDesk_Kvas.Models.Datos.DAL;
using HelpDesk_Kvas.Models.Datos.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HelpDesk_Kvas.Models.Datos.Logica
{
    public class PresupuestoLogic
    {
        private GrupoDetalleDAL objDetalleDAL;
        private GrupoDAL objGrupoDAL;
        private RequerimientoDAL objRequerimientoDAL;
        private PresupuestoDAL objPresupuestoDAL;
        dbDataContext db;

        public PresupuestoLogic()
        {
            objDetalleDAL = new GrupoDetalleDAL();
            objGrupoDAL = new GrupoDAL();
            objRequerimientoDAL = new RequerimientoDAL();
            objPresupuestoDAL = new PresupuestoDAL();
            db = new dbDataContext();
        }

        public void Insertar(PresupuestosEntity objRequerimiento)
        {
            try
            {
                objPresupuestoDAL.Insertar(objRequerimiento);
                objRequerimiento.Mensaje = 99;
                return;
            }
            catch
            {
                objRequerimiento.Mensaje = 1;
            }
        }

        public IEnumerable<PresupuestoViewEntity> Listar()
        {
            return objPresupuestoDAL.Listar();
        }
    }
}