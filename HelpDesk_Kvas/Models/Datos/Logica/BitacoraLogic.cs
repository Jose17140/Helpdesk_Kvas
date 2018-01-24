using HelpDesk_Kvas.Models.Datos.DAL;
using HelpDesk_Kvas.Models.Datos.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HelpDesk_Kvas.Models.Datos.Logica
{
    public class BitacoraLogic
    {
        private OxRDAL objBitacoraDAL;

        public BitacoraLogic()
        {
            objBitacoraDAL = new OxRDAL();
        }

        public void Insertar(ObservacionesEntity objBitacora)
        {
            try
            {
                objBitacoraDAL.Insertar(objBitacora);
                return;
            }
            catch
            {
                
            }
        }

        public void Actualizar(BitacorasEntity objBitacora)
        {
            try
            {
                objBitacoraDAL.Actualizar(objBitacora);
                objBitacora.Mensaje = 98;
            }
            catch (Exception)
            {
                throw;
            }
        }
        
        public IEnumerable<BitacorasEntity> Listar()
        {
            return objBitacoraDAL.Listar();
        }
    }
}