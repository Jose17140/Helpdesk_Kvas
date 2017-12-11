using KvasEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KvasDAL
{
    public class UsuarioDAL
    {
        dbDataContext db;

        public UsuarioDAL()
        {
            db = new dbDataContext();
        }

        public void Insertar(RegisterUserEntity user)
        {
            try
            {
                var fecha = DateTime.Now;
                db.sp_AgregarUsuario(user.UserName, user.Password, user.Email, user.IdPregunta, user.RespuestaSeguridad, user.Avatar,
                                    user.Estatus, fecha, user.IdRoles);
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

        public bool IsEmailExist(string emailID)
        {
            var v = db.Usuarios.Where(a => a.IdEmail == emailID).FirstOrDefault();
            return v != null;
        }

        public bool IsUserExist(string UserName)
        {
            var v = db.Usuarios.Where(a => a.NombreUsuario == UserName).FirstOrDefault();
            return v != null;
        }

        public void Eliminar(GruposEntity grupo)
        {
            try
            {
                db.sp_EliminarGrupo(grupo.IdGrupo);
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
                db.sp_ActualizarGrupo(grupo.IdGrupo, grupo.Titulo, grupo.Descripcion, grupo.Orden, grupo.Icono, grupo.UrlGrupo, grupo.Estatus);
                //Grupos query = db.Grupos.Where(m => m.IdGrupo == grupo.IdGrupo).SingleOrDefault();
                //query.Nombre = grupo.Titulo;
                //query.Descripcion = grupo.Descripcion;
                //query.Orden = grupo.Orden;
                //query.Icono = grupo.Icono;
                //query.UrlGrupo = grupo.UrlGrupo;
                //query.Estatus = grupo.Estatus;
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
                    Orden = query.Orden,
                    Icono = query.Icono,
                    UrlGrupo = query.UrlGrupo,
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
                //var query = db.sp_ListarGrupo().ToList();
                var query = (from m in db.Grupos
                             where m.Estatus == true && m.IdGrupo > 0 && m.IdGrupo != 9 && m.IdGrupo != 3 && m.IdGrupo != 8
                             select m).ToList();
                foreach (var grupos in query)
                {
                    lista.Add(new GruposEntity()
                    {
                        IdGrupo = grupos.IdGrupo,
                        Titulo = grupos.Nombre,
                        Descripcion = grupos.Descripcion,
                        Orden = grupos.Orden,
                        Icono = grupos.Icono,
                        UrlGrupo = grupos.UrlGrupo,
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

        public IEnumerable<GruposEntity> ListarUnGrupo(int idGrupo)
        {
            try
            {
                IList<GruposEntity> lista = new List<GruposEntity>();
                //var query = db.sp_ListarGrupo().ToList();
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
                        Orden = grupos.Orden,
                        Icono = grupos.Icono,
                        UrlGrupo = grupos.UrlGrupo,
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
    }
}
