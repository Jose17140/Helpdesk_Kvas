using HelpDesk_Kvas.Models.Datos.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HelpDesk_Kvas.Models.Datos.DAL
{
    /// <summary>
    /// OBSERVACIONES POR REQUERIMEINTO O BITACORA
    /// </summary>
    public class OxRDAL
    {
        dbDataContext db;

        public OxRDAL()
        {
            db = new dbDataContext();
        }

        public void Insertar(BitacorasEntity _bitacora)
        {
            try
            {
                Observaciones_x_Requerimiento m = new Observaciones_x_Requerimiento()
                {
                    IdRequerimiento = _bitacora.IdRequerimiento,
                    IdUsuario = _bitacora.IdUsuario,
                    Observaciones = _bitacora.Observaciones,
                    FechaRegistro = DateTime.Now
                };
                db.Observaciones_x_Requerimiento.InsertOnSubmit(m);
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

        //public void Eliminar(BitacorasEntity _bitacora)
        //{
        //    try
        //    {
        //        Observaciones_x_Requerimiento query = db.Grupos.Where(x => x.IdGrupo == grupo.IdGrupo).SingleOrDefault();
        //        db.Observaciones_x_Requerimiento.DeleteOnSubmit(query);
        //        db.SubmitChanges();
        //    }
        //    catch (Exception)
        //    {

        //    }
        //    finally
        //    {

        //    }
        //}

        public void Actualizar(BitacorasEntity _bitacora)
        {
            try
            {
                Observaciones_x_Requerimiento query = db.Observaciones_x_Requerimiento.Where(m => m.IdOxR == _bitacora.IdBitacora).SingleOrDefault();
                query.IdRequerimiento = _bitacora.IdRequerimiento;
                query.IdUsuario = _bitacora.IdUsuario;
                query.Observaciones = _bitacora.Observaciones;
                query.FechaRegistro = DateTime.Now;
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

        //public BitacorasEntity Buscar(int idGrupo)
        //{
        //    try
        //    {

        //        var query = (from m in db.Observaciones_x_Requerimiento
        //                     where m.IdGrupo == idGrupo
        //                     select m).FirstOrDefault();
        //        var model = new BitacorasEntity()
        //        {
        //            IdGrupo = idGrupo,
        //            Titulo = query.Nombre,
        //            Descripcion = query.Descripcion,
        //            Icono = query.Icono,
        //            IdPadre = query.IdPadre,
        //            Estatus = query.Estatus,
        //            FechaRegistro = query.FechaRegistro
        //        };
        //        return model;
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //    finally
        //    {

        //    }
        //}

        public IEnumerable<BitacorasEntity> Listar()
        {
            try
            {
                IList<BitacorasEntity> lista = new List<BitacorasEntity>();
                var query = db.vw_Bitacora.ToList();
                foreach (var _bitacora in query)
                {
                    lista.Add(new BitacorasEntity()
                    {
                        IdBitacora = _bitacora.IdOxR,
                        IdRequerimiento = _bitacora.IdRequerimiento,
                        IdUsuario = _bitacora.IdUsuario,
                        UserName = _bitacora.NombreUsuario,
                        Avatar = _bitacora.Avatar,
                        IdRoles = _bitacora.IdRoles,
                        Rol = _bitacora.Rol,
                        Observaciones = _bitacora.Observaciones,
                        Leido = _bitacora.Leido,
                        FechaRegistro = _bitacora.FechaRegistro
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