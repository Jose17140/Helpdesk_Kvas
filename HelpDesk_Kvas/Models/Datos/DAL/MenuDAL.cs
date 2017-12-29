using HelpDesk_Kvas.Models.Datos.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HelpDesk_Kvas.Models.Datos.DAL
{
    public class MenuDAL
    {
        dbDataContext db;

        public MenuDAL()
        {
            db = new dbDataContext();
        }

        public void Insertar(GruposDetallesEntity grupo)
        {
            try
            {
                if (grupo.IdPadre == null)
                {
                    grupo.IdPadre = 0;
                }
                GruposDetalles _grupo = new GruposDetalles()
                {
                    Nombre = grupo.Titulo,
                    Descripcion = grupo.Descripcion,
                    Orden = grupo.Orden,
                    IdGrupo = Convert.ToInt32(grupo.IdGrupo),
                    IdPadre = grupo.IdPadre,
                    Imagen = grupo.Icono,
                    UrlDetalle = grupo.UrlDetalle,
                    Estatus = grupo.Estatus,
                    FechaRegistro = DateTime.Now
                };
                db.GruposDetalles.InsertOnSubmit(_grupo);
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
                query.Imagen = grupo.Icono;
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
                var query = (from m in db.vw_Menu
                             where m.IdGrupoDetalle == idGrupo
                             select m).FirstOrDefault();
                var model = new GruposDetallesEntity()
                {
                    IdGrupoDetalle = idGrupo,
                    Titulo = query.Nombre,
                    Descripcion = query.Descripcion,
                    Orden = Convert.ToInt32(query.Orden),
                    IdGrupo = query.IdGrupo,
                    IdPadre = Convert.ToInt32(query.IdPadre),
                    UrlDetalle = query.UrlDetalle,
                    Icono = query.Imagen,
                    Estatus = Convert.ToBoolean(query.Estatus),
                    FechaRegistro = Convert.ToDateTime(query.FechaRegistro)
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

        public IEnumerable<GruposDetallesView> Listar()
        {
            try
            {
                IList<GruposDetallesView> lista = new List<GruposDetallesView>();
                var query = (from m in db.vw_Menu
                             select m).ToList();
                foreach (var grupos in query)
                {
                    lista.Add(new GruposDetallesView()
                    {
                        IdGrupoDetalle = Convert.ToInt32(grupos.IdGrupoDetalle),
                        Titulo = grupos.Nombre,
                        Descripcion = grupos.Descripcion,
                        Orden = Convert.ToInt32(grupos.Orden),
                        IdGrupo = grupos.IdGrupo,
                        IdPadre = grupos.IdPadre,
                        Padre = grupos.Categoria,
                        UrlDetalle = grupos.UrlDetalle,
                        Icono = grupos.Imagen,
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