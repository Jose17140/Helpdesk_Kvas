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
            try
            {
                var fecha = DateTime.Now;
                db.sp_ActualizarUsuario(user.IdUsuario,user.Password,user.Email,user.IdPregunta,user.RespuestaSeguridad,user.Estatus,fecha,user.IdRoles);
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

        public UsuariosEntityView Buscar(int idUsuario)
        {
            try
            {
                var query = db.sp_BuscarUsuarios(idUsuario).SingleOrDefault();
                var model = new UsuariosEntityView()
                {
                    IdUsuario = idUsuario,
                    UserName = query.NombreUsuario,
                    Password = query.Contrasena,
                    Email = query.Correo,
                    IdRoles = query.IdRoles,
                    Roles = query.NombreRol,
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
                var query = db.vw_Usuarios.Where(m=>m.NombreUsuario.ToUpper().Contains(_usuario.ToUpper())).SingleOrDefault();
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
                        Email = grupos.Correo,
                        IdRoles = grupos.IdRoles,
                        Roles = grupos.NombreRol,
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
