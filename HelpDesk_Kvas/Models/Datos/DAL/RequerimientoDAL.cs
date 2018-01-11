using HelpDesk_Kvas.Models.Datos.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HelpDesk_Kvas.Models.Datos.DAL
{
    public class RequerimientoDAL
    {
        dbDataContext db;

        public RequerimientoDAL()
        {
            db = new dbDataContext();
        }

        public void Insertar(RequerimientosEntity req)
        {
            try
            {
                Requerimientos _requerimiento = new Requerimientos()
                {
                    IdEmpleado = req.IdEmpleado,
                    FechaEntrada = DateTime.Now,
                    //FechaSalida DATETIME NULL,
                    IdCliente = req.IdCliente,
                    IdEquipo = req.IdEquipo,
                    IdMarca = req.IdMarca,
                    IdPrioridad = req.IdPrioridad,
                    IdModelo = req.IdModelo,
                    Falla = req.Falla,
                    //Diagnostico = req.Diagnostico,
                    //Solucion = req.Solucion,
                    Serial = req.Serial,
                    Descripcion = req.Descripcion,
                    Accesorios = req.Accesorio,
                    IdTecnico = req.IdTecnico,
                    IdDeposito = req.IdDeposito,
                    Estatus = req.IdEstatus,
                };
                db.Requerimientos.InsertOnSubmit(_requerimiento);
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

        public void Eliminar(RequerimientosEntity req)
        {
            try
            {
                Requerimientos query = db.Requerimientos.Where(m => m.IdRequerimiento == req.IdRequerimiento).SingleOrDefault();
                db.Requerimientos.DeleteOnSubmit(query);
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

        public void AsignarTecnico(RequerimientosEntity req)
        {
            try
            {
                Requerimientos query = db.Requerimientos.Where(m => m.IdRequerimiento == req.IdRequerimiento).SingleOrDefault();
                query.IdTecnico = req.IdTecnico;
                query.Estatus = 59; // Asignado
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

        public void DiagnosticoSolucion(RequerimientosEntity req)
        {
            try
            {
                Requerimientos query = db.Requerimientos.Where(m => m.IdRequerimiento == req.IdRequerimiento).SingleOrDefault();
                query.Diagnostico = req.Diagnostico;
                query.Solucion = req.Solucion;
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

        public RequerimientoViewEntity Buscar(int idRequerimiento)
        {
            try
            {
                var query = (from m in db.vw_requerimietos
                             where m.IdRequerimiento == idRequerimiento
                             select m).FirstOrDefault();
                var model = new RequerimientoViewEntity()
                {
                    IdRequerimiento = idRequerimiento,
                    IdEmpleado = query.IdEmpleado,
                    Empleado = query.Empleado,
                    FechaEntrada = query.FechaEntrada,
                    FechaSalida = Convert.ToDateTime(query.FechaSalida),
                    IdCliente = query.IdPersona,
                    Cliente = query.Nombres,
                    IdEquipo = query.IdEquipo,
                    Equipo = query.Equipo,
                    IdMarca = query.IdMarca,
                    Marca = query.Marca,
                    IdPrioridad = query.IdPrioridad,
                    Prioridad = query.Prioridad,
                    IdModelo = query.IdModelo,
                    Modelo = query.Modelo,
                    Falla = query.Falla,
                    Diagnostico = query.Diagnostico,
                    Solucion = query.Solucion,
                    Serial = query.Serial,
                    Descripcion = query.Descripcion,
                    Accesorio = query.Accesorios,
                    IdTecnico = query.IdTecnico,
                    Tecnico = query.Tecnico,
                    IdDeposito = Convert.ToInt32(query.IdDeposito),
                    Deposito = query.Deposito,
                    IdEstatus = query.IdEstatus,
                    Estatus = query.Estatus
                };
                return model;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {

            }
        }

        public IEnumerable<RequerimientoViewEntity> Listar()
        {
            try
            {
                IList<RequerimientoViewEntity> lista = new List<RequerimientoViewEntity>();
                var query = (from m in db.vw_requerimietos
                             select m).ToList();
                foreach (var req in query)
                {
                    lista.Add(new RequerimientoViewEntity()
                    {
                        IdRequerimiento = req.IdRequerimiento,
                        IdEmpleado = req.IdEmpleado,
                        Empleado = req.Empleado,
                        FechaEntrada = req.FechaEntrada,
                        FechaSalida = Convert.ToDateTime(req.FechaSalida),
                        IdCliente = req.IdPersona,
                        Cliente = req.Nombres,
                        IdEquipo = req.IdEquipo,
                        Equipo = req.Equipo,
                        IdMarca = req.IdMarca,
                        Marca = req.Marca,
                        IdPrioridad = req.IdPrioridad,
                        Prioridad = req.Prioridad,
                        IdModelo = req.IdModelo,
                        Modelo = req.Modelo,
                        Falla = req.Falla,
                        Diagnostico = req.Diagnostico,
                        Solucion = req.Solucion,
                        Serial = req.Serial,
                        Descripcion = req.Descripcion,
                        Accesorio = req.Accesorios,
                        IdTecnico = req.IdTecnico,
                        Tecnico = req.Tecnico,
                        IdDeposito = Convert.ToInt32(req.IdDeposito),
                        Deposito = req.Deposito,
                        IdEstatus = req.IdEstatus,
                        Estatus = req.Estatus
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