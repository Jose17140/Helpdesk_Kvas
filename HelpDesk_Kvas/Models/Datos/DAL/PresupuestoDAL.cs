using HelpDesk_Kvas.Models.Datos.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HelpDesk_Kvas.Models.Datos.DAL
{
    public class PresupuestoDAL
    {
        dbDataContext db;
        public PresupuestoDAL()
        {
            db = new dbDataContext();
        }
        public void Insertar(PresupuestosEntity objPresupuesto)
        {
            try
            {
                var date = DateTime.Now;
                Presupuestos i = new Presupuestos()
                {
                    IdRequerimiento = Convert.ToInt32(objPresupuesto.IdRequerimiento),
                    IdUsuario = objPresupuesto.IdEmpleado,
                    FechaEmision = DateTime.Now,
                    FechaVencimiento = date.AddDays(5),
                    IdPoS = objPresupuesto.IdPoS,
                    Cant = objPresupuesto.Cantidad,
                    PrecioUnit = objPresupuesto.PrecioUnitario,
                    IdEstatus = objPresupuesto.IdEstatus
                };
                db.Presupuestos.InsertOnSubmit(i);
                db.SubmitChanges();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {

            }
        }
    }
}