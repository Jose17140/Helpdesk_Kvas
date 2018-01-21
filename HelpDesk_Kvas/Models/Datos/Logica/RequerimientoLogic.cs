using HelpDesk_Kvas.Models.Datos.DAL;
using HelpDesk_Kvas.Models.Datos.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HelpDesk_Kvas.Models.Datos.Logica
{
    public class RequerimientoLogic
    {
        private GrupoDetalleDAL objDetalleDAL;
        private GrupoDAL objGrupoDAL;
        private RequerimientoDAL objRequerimientoDAL;
        dbDataContext db;

        public RequerimientoLogic()
        {
            objDetalleDAL = new GrupoDetalleDAL();
            objGrupoDAL = new GrupoDAL();
            objRequerimientoDAL = new RequerimientoDAL();
            db = new dbDataContext();
        }

        public void Insertar(RequerimientosEntity objRequerimiento)
        {
            try
            {
                objRequerimientoDAL.Insertar(objRequerimiento);
                objRequerimiento.Mensaje = 99;
                return;
            }
            catch
            {
                objRequerimiento.Mensaje = 1;
            }
        }

        public void InsertarCliente(RequerimientosEntity objRequerimiento)
        {
            try
            {
                objRequerimientoDAL.InsertarCliente(objRequerimiento);
                objRequerimiento.Mensaje = 99;
                return;
            }
            catch
            {
                objRequerimiento.Mensaje = 1;
            }
        }

        public void AsignarTecnico(RequerimientosEntity objRequerimiento)
        {
            try
            {
                objRequerimientoDAL.AsignarTecnico(objRequerimiento);
                objRequerimiento.Mensaje = 98;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void DiagnosticoSolucion(RequerimientosEntity objRequerimiento)
        {
            try
            {
                objRequerimientoDAL.DiagnosticoSolucion(objRequerimiento);
                objRequerimiento.Mensaje = 98;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Eliminar(RequerimientosEntity objRequerimiento)
        {
            try
            {
                objRequerimientoDAL.Eliminar(objRequerimiento);
                objRequerimiento.Mensaje = 99;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IEnumerable<RequerimientoViewEntity> Listar()
        {
            return objRequerimientoDAL.Listar();
        }

        public RequerimientoViewEntity Buscar(int _idRequerimiento)
        {
            return objRequerimientoDAL.Buscar(_idRequerimiento);

        }
    }
}