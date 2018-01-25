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
                    IdUsuario = Convert.ToInt32(objPresupuesto.IdEmpleado),
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

        public IEnumerable<PresupuestoViewEntity> Listar()
        {
            try
            {
                IList<PresupuestoViewEntity> lista = new List<PresupuestoViewEntity>();
                var query = (from m in db.vw_Presupuestos
                             select m).ToList();
                foreach (var req in query)
                {
                    lista.Add(new PresupuestoViewEntity()
                    {
                        IdPresupuesto = req.IdPresupuesto,
                        IdRequerimiento = req.IdRequerimiento,
                        IdEmpleado = req.IdUsuario,
                        FechaEmision = req.FechaEmision,
                        FechaVencimiento = Convert.ToDateTime(req.FechaVencimiento),
                        IdPoS = req.IdPoS,
                        Sku = req.Sku,
                        NombreProducto = req.Nombre,
                        Descripcion = req.Descripcion,
                        Cantidad = req.Cant,
                        PrecioUnitario = req.PrecioUnit,
                        Subtotal = Convert.ToDecimal(req.SubTotal),
                        Iva = Convert.ToDecimal(req.Iva),
                        IdEstatus = req.IdEstatus
                    });
                }
                return lista;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {

            }

        }

        public IEnumerable<PresupuestoDetalleEntity> ListarDetalle()
        {
            try
            {
                IList<PresupuestoDetalleEntity> lista = new List<PresupuestoDetalleEntity>();
                var query = (from m in db.vw_PresupuestoDetalle
                             select m).ToList();
                foreach (var req in query)
                {
                    lista.Add(new PresupuestoDetalleEntity()
                    {
                        IdPresupuesto = req.IdPresupuesto,
                        IdRequerimiento = req.IdRequerimiento,
                        //IdEmpleado = req.IdUsuario,
                        FechaEmision = req.FechaEmision,
                        FechaVencimiento = Convert.ToDateTime(req.FechaVencimiento),
                        IdEmpleado = req.IdEmpleado,
                        NombreEmpleado = req.NombreEmpleado,
                        NombreCliente = req.NombreCliente,
                        Cedula = req.Cedula,
                        Telefono = req.Telefonos,
                        Direccion = req.Direccion,
                        Email = req.Email,
                        IdPoS = req.IdPoS,
                        Sku = req.Sku,
                        NombreProducto = req.NombreProducto,
                        Descripcion = req.Descripcion,
                        Cantidad = req.Cant,
                        PUnitario = req.PrecioUnit,
                        SubTotal = Convert.ToDecimal(req.SubTotal),
                        Iva = Convert.ToDecimal(req.Iva),
                        IdEstatus = req.IdEstatus
                    });
                }
                return lista;
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