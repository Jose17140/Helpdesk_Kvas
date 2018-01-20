using HelpDesk_Kvas.Models.Datos.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelpDesk_Kvas.Models.Datos.DAL
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
                Usuarios _user = new Usuarios()
                {
                    NombreUsuario = user.UserName,
                    Contrasena = user.Password,
                    Avatar = user.Avatar,
                    IdRoles = Convert.ToInt32(user.IdRoles),
                    IdPreguntaSeguridad = Convert.ToInt32(user.IdPregunta),
                    RespuestaSeguridad = user.RespuestaSeguridad,
                    Estatus = user.Estatus,
                    FechaRegistro = DateTime.Now
                };
                db.Usuarios.InsertOnSubmit(_user);
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

        public void InsertarCompleto(RegisterUserEntity user)
        {
            try
            {
                Usuarios _user = new Usuarios()
                {
                    NombreUsuario = user.UserName,
                    Contrasena = user.Password,
                    IdPreguntaSeguridad = user.IdPregunta,
                    RespuestaSeguridad = user.RespuestaSeguridad,
                    Avatar = user.Avatar,
                    FechaRegistro = DateTime.Now
                };
                db.Usuarios.InsertOnSubmit(_user);
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

        public void Eliminar(UsuariosEntity user)
        {
            try
            {
                Usuarios _usuario = db.Usuarios.Where(x => x.IdUsuario == user.IdUsuario).SingleOrDefault();
                db.Usuarios.DeleteOnSubmit(_usuario);
                db.SubmitChanges();
            }
            catch (Exception)
            {

            }
            finally
            {

            }
        }

        public void Actualizar(RegisterUserEntity user)
        {
            //try
            //{
            //    var fecha = DateTime.Now;
            //    db.sp_ActualizarUsuario(user.IdUsuario,user.Password,user.IdPregunta,user.RespuestaSeguridad,user.Estatus,fecha,user.IdRoles);
            //    db.SubmitChanges();
            //}
            //catch (Exception)
            //{
            //    throw;
            //}
            //finally
            //{

            //}

            //GruposDetalles query = db.GruposDetalles.Where(m => m.IdGrupoDetalle == grupo.IdGrupoDetalle).SingleOrDefault();
            //query.Nombre = grupo.Titulo;
            //query.Descripcion = grupo.Descripcion;
            //query.Orden = grupo.Orden;
            //query.IdGrupo = Convert.ToInt32(grupo.IdGrupo);
            //query.IdPadre = grupo.IdPadre;
            //query.UrlDetalle = grupo.UrlDetalle;
            //query.Imagen = grupo.Icono;
            //query.Estatus = grupo.Estatus;
            //db.SubmitChanges();
        }

        public UsuariosEntityView Buscar(int idUsuario)
        {
            try
            {
                //var query = db.sp_BuscarUsuarios(idUsuario).SingleOrDefault();
                var query = db.vw_ListarUsuarios.Where(m => m.IdUsuario.Equals(idUsuario)).SingleOrDefault();
                var model = new UsuariosEntityView()
                {
                    IdUsuario = idUsuario,
                    UserName = query.NombreUsuario,
                    Password = query.Contrasena,
                    IdRoles = query.IdRoles,
                    Roles = query.Rol,
                    IdPregunta = query.IdPregunta,
                    Pregunta = query.Pregunta,
                    RespuestaSeguridad = query.RespuestaSeguridad,
                    Avatar = query.Avatar,
                    //FechaLogin = query.FechaLogin,
                    //ContadorFallido = query.ContadorFallido,
                    FechaModificacion = query.FechaModificacion,
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

        public UsuarioLogEntity Buscarview(string _usuario)
        {
            try
            {
                if (_usuario!=null)
                {
                    var query = db.vw_ListarUsuarios.Where(m => m.NombreUsuario.ToUpper().Equals(_usuario.ToUpper())).SingleOrDefault();
                    var model = new UsuarioLogEntity()
                    {
                        IdUsuario = query.IdUsuario,
                        UserName = query.NombreUsuario,
                        Rol = query.Rol,
                        Avatar = query.Avatar,
                        Color = query.FormColor,
                        FechaLogin = Convert.ToDateTime(query.FechaLogin)
                    };
                    return model;
                }
                return null;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {

            }
        }

        public IEnumerable<LoginUserEntity> Login()
        {
            try
            {
                IList<LoginUserEntity> lista = new List<LoginUserEntity>();
                var query = (from m in db.Usuarios
                             select m).ToList();
                foreach (var grupos in query)
                {
                    lista.Add(new LoginUserEntity()
                    {
                        //IdUsuario = grupos.IdUsuario,
                        UserName = grupos.NombreUsuario,
                        //Email = grupos.Email,
                        Password = grupos.Contrasena,
                        ContadorFallido = grupos.ContadorFallido,
                        Estatus = grupos.Estatus,
                        FechaLogin = grupos.FechaLogin
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

        public void LoginFail(LoginUserEntity user)
        {
            try
            {
                var query = db.Usuarios.Where(m => m.NombreUsuario == user.UserName).SingleOrDefault();
                query.ContadorFallido = Convert.ToInt32(user.ContadorFallido);
                query.FechaLogin = DateTime.Now;
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

        public IEnumerable<UsuariosEntityView> Listar()
        {
            try
            {
                IList<UsuariosEntityView> lista = new List<UsuariosEntityView>();
                var query = db.vw_ListarUsuarios;
                foreach (var grupos in query)
                {
                    lista.Add(new UsuariosEntityView()
                    {
                        IdUsuario = grupos.IdUsuario,
                        UserName = grupos.NombreUsuario,
                        //Email = grupos.Correo,
                        IdRoles = grupos.IdRoles,
                        Roles = grupos.Rol,
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
