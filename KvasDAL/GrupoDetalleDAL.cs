using KvasEntity;
using System;
using System.Collections.Generic;
using System.Linq;

namespace KvasDAL
{
    public class GrupoDetalleDAL : Obligatorios<GruposDetallesEntity>
    {
        dbDataContext db;

        public GrupoDetalleDAL()
        {
            db = new dbDataContext();
        }

        public void Insertar(GruposDetallesEntity grupo)
        {
            try
            {
                var fecha = DateTime.Now;
                if (grupo.IdPadre == null)
                {
                    grupo.IdPadre = 0;
                }
                db.sp_AgregarGrupoDetalle(grupo.Titulo,grupo.Descripcion,grupo.Orden,grupo.IdGrupo,grupo.IdPadre,grupo.Icono,grupo.UrlDetalle,grupo.Estatus,fecha);
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

        public void Eliminar(GruposDetallesEntity grupo)
        {
            try
            {
                GruposDetalles query = db.GruposDetalles.Where(m => m.IdGrupoDetalle == grupo.IdGrupoDetalle).SingleOrDefault();
                db.GruposDetalles.DeleteOnSubmit(query);
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

        public void Actualizar(GruposDetallesEntity grupo)
        {
            try
            {
                GruposDetalles query = db.GruposDetalles.Where(m => m.IdGrupoDetalle == grupo.IdGrupoDetalle).SingleOrDefault();
                query.Nombre = grupo.Titulo;
                query.Descripcion = grupo.Descripcion;
                query.Orden = grupo.Orden;
                query.IdGrupo = Convert.ToInt32(grupo.IdGrupo);
                query.IdPadre = grupo.IdPadre;
                query.UrlDetalle = grupo.UrlDetalle;
                query.Icono = grupo.Icono;
                query.Estatus = grupo.Estatus;
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

        public GruposDetallesEntity Buscar(int idGrupo)
        {
            try
            {
                var query = (from m in db.GruposDetalles
                             where m.IdGrupoDetalle == idGrupo & m.IdGrupoDetalle > 0
                             select m).FirstOrDefault();
                var model = new GruposDetallesEntity()
                {
                    IdGrupoDetalle = idGrupo,
                    Titulo = query.Nombre,
                    Descripcion = query.Descripcion,
                    Orden = query.Orden,
                    IdGrupo = query.IdGrupo,
                    IdPadre = Convert.ToInt32(query.IdPadre),
                    UrlDetalle = query.UrlDetalle,
                    Icono = query.Icono,
                    Estatus = query.Estatus,
                    FechaRegistro = query.FechaRegistro
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

        public IEnumerable<GruposDetallesEntity> Listar()
        {
            try
            {
                IList<GruposDetallesEntity> lista = new List<GruposDetallesEntity>();
                var query = (from m in db.GruposDetalles
                             join g in db.Grupos on
                             m.IdGrupo equals g.IdGrupo
                             where m.IdGrupo > 0
                             select m).ToList();
                foreach (var grupos in query)
                {
                    lista.Add(new GruposDetallesEntity()
                    {
                        IdGrupoDetalle = grupos.IdGrupoDetalle,
                        Titulo = grupos.Nombre,
                        Descripcion = grupos.Descripcion,
                        Orden = grupos.Orden,
                        IdGrupo = grupos.IdGrupo,
                        IdPadre = grupos.IdPadre,
                        UrlDetalle = grupos.UrlDetalle,
                        Icono = grupos.Icono,
                        Estatus = grupos.Estatus,
                        FechaRegistro = grupos.FechaRegistro
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

        public IEnumerable<GruposDetallesEntity> ListaPorGrupo(int idGrupo)
        {
            try
            {
                IList<GruposDetallesEntity> lista = new List<GruposDetallesEntity>();
                var query = (from m in db.GruposDetalles
                             join g in db.Grupos on
                             m.IdGrupo equals g.IdGrupo
                             where m.IdGrupo > 0 & m.IdGrupo == idGrupo
                             select m).ToList();
                foreach (var grupos in query)
                {
                    lista.Add(new GruposDetallesEntity()
                    {
                        IdGrupoDetalle = grupos.IdGrupoDetalle,
                        Titulo = grupos.Nombre,
                        Descripcion = grupos.Descripcion,
                        Orden = grupos.Orden,
                        IdGrupo = grupos.IdGrupo,
                        IdPadre = Convert.ToInt32(grupos.IdPadre),
                        UrlDetalle = grupos.UrlDetalle,
                        Icono = grupos.Icono,
                        Estatus = grupos.Estatus,
                        FechaRegistro = grupos.FechaRegistro
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

        public IEnumerable<GruposDetallesView> ListaPorGrupoSP(int idGrupo)
        {
            try
            {
                IList<GruposDetallesView> lista = new List<GruposDetallesView>();
                var query = db.sp_ListarDetalles_x_Grupo(idGrupo);
                foreach (var grupos in query)
                {
                    lista.Add(new GruposDetallesView()
                    {
                        IdGrupoDetalle = Convert.ToInt32(grupos.IdGrupoDetalle),
                        Titulo = grupos.Nombre,
                        Descripcion = grupos.Descripcion,
                        Orden = Convert.ToInt32(grupos.Orden),
                        Padre = grupos.Categoria,
                        Icono = grupos.Icono,
                        Estatus = Convert.ToBoolean(grupos.Estatus),
                        FechaRegistro = Convert.ToDateTime(grupos.FechaRegistro)
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
