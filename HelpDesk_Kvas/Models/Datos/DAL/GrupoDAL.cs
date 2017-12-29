using HelpDesk_Kvas.Models.Datos.Entity;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HelpDesk_Kvas.Models.Datos.DAL
{
    public class GrupoDAL : Obligatorios<GruposEntity>
    {
        dbDataContext db;

        public GrupoDAL()
        {
            db = new dbDataContext();
        }

        public void Insertar(GruposEntity grupo)
        {
            try
            {
                Grupos _grupo = new Grupos()
                {
                    Nombre = grupo.Titulo,
                    Descripcion = grupo.Descripcion,
                    Icono = grupo.Icono,
                    IdPadre = grupo.IdPadre,
                    Estatus = grupo.Estatus,
                    FechaRegistro = DateTime.Now
                };
                db.Grupos.InsertOnSubmit(_grupo);
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

        public void Eliminar(GruposEntity grupo)
        {
            try
            {
                Grupos query = db.Grupos.Where(x => x.IdGrupo == grupo.IdGrupo).SingleOrDefault();
                db.Grupos.DeleteOnSubmit(query);
                db.SubmitChanges();
            }
            catch (Exception)
            {

            }
            finally
            {

            }
        }

        public void Actualizar(GruposEntity grupo)
        {
            try
            {
                Grupos query = db.Grupos.Where(m => m.IdGrupo == grupo.IdGrupo).SingleOrDefault();
                query.Nombre = grupo.Titulo;
                query.Descripcion = grupo.Descripcion;
                query.IdPadre = grupo.IdPadre;
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

        public GruposEntity Buscar(int idGrupo)
        {
            try
            {

                var query = (from m in db.Grupos
                             where m.IdGrupo == idGrupo
                             select m).FirstOrDefault();
                var model = new GruposEntity()
                {
                    IdGrupo = idGrupo,
                    Titulo = query.Nombre,
                    Descripcion = query.Descripcion,
                    Icono = query.Icono,
                    IdPadre = query.IdPadre,
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

        public IEnumerable<GruposEntity> Listar()
        {
            try
            {
                IList<GruposEntity> lista = new List<GruposEntity>();
                var query = (from m in db.Grupos
                             where m.IdGrupo > 0  
                             && m.IdGrupo != 1
                             && m.IdGrupo != 2
                             && m.IdGrupo != 4
                             && m.IdGrupo != 16
                             && m.IdGrupo != 17
                             select m).ToList();
                foreach (var grupos in query)
                {
                    lista.Add(new GruposEntity()
                    {
                        IdGrupo = grupos.IdGrupo,
                        Titulo = grupos.Nombre,
                        Descripcion = grupos.Descripcion,
                        IdPadre = grupos.IdPadre,
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

        public IEnumerable<GruposEntity> ListarNivelGrupo(int IdGrupo)
        {
            try
            {
                IList<GruposEntity> lista = new List<GruposEntity>();
                //var query = (from m in db.Grupos
                //             select m).ToList();
                var query = db.sp_ListarNivelGrupo(IdGrupo);
                foreach (var grupos in query)
                {
                    lista.Add(new GruposEntity()
                    {
                        IdGrupo = Convert.ToInt32(grupos.IdGrupo),
                        Titulo = grupos.Nombre,
                        Descripcion = grupos.Descripcion,
                        IdPadre = grupos.IdPadre,
                        Icono = grupos.Icono,
                        Estatus = Convert.ToBoolean(grupos.Estatus),
                        Nivel = Convert.ToInt32(grupos.LevelGrupo),
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

        public IEnumerable<GruposEntity> ListarUnGrupo(int idGrupo)
        {
            try
            {
                IList<GruposEntity> lista = new List<GruposEntity>();
                var query = (from m in db.Grupos
                             where (m.Estatus == true && m.IdGrupo > 0) & (m.IdGrupo == idGrupo)
                             select m).ToList();
                foreach (var grupos in query)
                {
                    lista.Add(new GruposEntity()
                    {
                        IdGrupo = grupos.IdGrupo,
                        Titulo = grupos.Nombre,
                        Descripcion = grupos.Descripcion,
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

        public GruposEntity BuscarPadre(int idGrupo)
        {
            try
            {

                var query = (from m in db.Grupos
                             where m.IdGrupo == idGrupo
                             select m).FirstOrDefault();
                var model = new GruposEntity()
                {
                    IdGrupo = idGrupo,
                    Titulo = query.Nombre,
                    Descripcion = query.Descripcion,
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
    }
}
