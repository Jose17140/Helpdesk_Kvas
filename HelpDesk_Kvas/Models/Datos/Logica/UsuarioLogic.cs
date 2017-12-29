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
        dbDataContext db;
        public UsuarioLogic()
        {
            objUsuarioDAL = new UsuarioDAL();
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

        public bool IsEmailExist(string emailID)
        {
            var v = db.Usuarios.Where(a => a.Email == emailID).FirstOrDefault();
            return v != null;
        }

        public bool IsUserExist(string UserName)
        {
            var v = db.Usuarios.Where(a => a.NombreUsuario == UserName).FirstOrDefault();
            return v != null;
        }

        public IEnumerable<LoginUserEntity> ListarLogin()
        {
            return objUsuarioDAL.Login();
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
    }
}
