using HelpDesk_Kvas.Models.Datos.DAL;
using HelpDesk_Kvas.Models.Datos.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelpDesk_Kvas.Models.Datos.Logica
{
    public class UsuarioLogic
    {
        private UsuarioDAL objUsuarioDAL;
        PersonaDAL objPersonaDAL; 
        dbDataContext db;
        public UsuarioLogic()
        {
            objUsuarioDAL = new UsuarioDAL();
            objPersonaDAL = new PersonaDAL();
            db = new dbDataContext();
        }

        public void Insertar(RegisterUserEntity objUsuario)
        {
            try
            {
                objUsuarioDAL.Insertar(objUsuario);
                objUsuario.Mensaje = 99;
                return;
            }
            catch
            {
                objUsuario.Mensaje = 1;
            }
        }

        public void InsertarCompletoA(UsuarioRegisterA objUsuario)
        {
            try
            {
                objUsuarioDAL.InsertarCompleto(objUsuario);
                objUsuario.Mensaje = 99;
                return;
            }
            catch
            {
                objUsuario.Mensaje = 1;
            }
        }

        public bool IsEmailExist(string emailID)
        {
            var v = db.Personas.Where(a => a.Email.ToUpper().Contains(emailID.ToUpper())).FirstOrDefault();
            return v != null;
        }

        public bool IsUserExist(string UserName)
        {
            var v = db.Usuarios.Where(a => a.NombreUsuario.ToUpper().Contains(UserName.ToUpper())).FirstOrDefault();
            return v != null;
        }

        public bool IsCiExist(string _ci)
        {
            var v = db.Personas.Where(a => a.CiRif.ToUpper().Contains(_ci.ToUpper())).FirstOrDefault();
            return v != null;
        }

        public bool ConfirQuestion(string answer)
        {
            var v = db.Usuarios.Where(a => a.RespuestaSeguridad.ToUpper().Equals(answer.ToUpper())).FirstOrDefault();
            return v != null;
        }

        public UsuarioLogEntity Buscar_x_Nombre(string _usuario)
        {
            return objUsuarioDAL.Buscarview(_usuario);
            
        }

        public IEnumerable<LoginUserEntity> ListarLogin()
        {
            return objUsuarioDAL.Login();
        }

        public IEnumerable<UsuarioViewEntity> Listar()
        {
            return objUsuarioDAL.Listar();
        }

        public void LoginControl(LoginUserEntity objUsuario)
        {
            try
            {
                objUsuarioDAL.LoginFail(objUsuario);
                objUsuario.Mensaje = 99;
                return;
            }
            catch
            {
                objUsuario.Mensaje = 1;
            }
        }

        public void Actualizar(EditarUsuario objUser)
        {
            try
            {
                objUsuarioDAL.Actualizar(objUser);
                objUser.Mensaje = 98;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void ActualizarPerfil(EditarUsuario objUser)
        {
            try
            {
                objUsuarioDAL.ActualizarPerfil(objUser);
                objUser.Mensaje = 98;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void EliminarUsuario(EditarUsuario objUser)
        {
            try
            {
                objUsuarioDAL.EmilinarUsuario(objUser);
                objUser.Mensaje = 98;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void ActualizarPassId(RecuperarContrasenaIdEntity objUser)
        {
            try
            {
                objUsuarioDAL.ActualizarPassId(objUser);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void ActualizarPassUser(RecuperarContrasenaUserNameEntity objUser)
        {
            try
            {
                objUsuarioDAL.ActualizarPassUser(objUser);
            }
            catch (Exception)
            {
                throw;
            }
        }

        #region RECUPERACION DE CONTRASENA
        public IEnumerable<ForgotQuestionUserEntity> ListarPregunta()
        {
            return objUsuarioDAL.ListarPregunta();
        }

        public void CambiarPass(ChanagePasswordEntity objUser)
        {
            try
            {
                objUsuarioDAL.CambiarPass(objUser);
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion
    }
}
