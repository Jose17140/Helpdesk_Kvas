using KvasEntity;
using KvasLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace HelpDesk_Kvas.Controllers
{
    public class UsuarioController : Controller
    {
        UsuarioLogic objUsuarioLogic;
        GrupoDetalleLogic objGrupoDetalleLogic;
        public UsuarioController()
        {
            objUsuarioLogic = new UsuarioLogic();
            objGrupoDetalleLogic = new GrupoDetalleLogic();
        }

        // GET: Usuario
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Registrar()
        {
            var _ListaDetalle = objGrupoDetalleLogic.Listar();
            var _Roles = _ListaDetalle.Where(m => m.IdGrupo == 3).ToList();
            var _Preguntas = _ListaDetalle.Where(m => m.IdGrupo == 15).ToList();
            //Departamento Roles
            SelectList listaRoles = new SelectList(_Roles, "IdGrupoDetalle", "Titulo");
            //Departamento hijo
            SelectList listaPreguntas = new SelectList(_Preguntas, "IdGrupoDetalle", "Titulo");
            ViewBag.ListaRoles = listaRoles;
            ViewBag.ListaPreguntas = listaPreguntas;
            return View();
        }
        //Registration POST action 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Registrar([Bind(Exclude = "FechaLogin,ContadorFallido,FechaModificacion")] RegisterUserEntity user)
        {
            string message = "";
            // Model Validation 
            if (ModelState.IsValid)
            {

                #region //Email is already Exist 
                var isExistEmail = objUsuarioLogic.IsEmailExist(user.Email);
                var isExistUser = objUsuarioLogic.IsUserExist(user.UserName);
                //var isExistEmail = IsEmailExist(user.Email);
                //var isExistUser = IsUserExist(user.UserName);
                if (isExistEmail)
                {
                    ModelState.AddModelError("EmailExist", "Correo electronico ya esta registrado");
                    return View(user);
                }
                if (isExistUser)
                {
                    ModelState.AddModelError("UserExist", "El nombre de usuario ya se encuantra registrado");
                    return View(user);
                }
                #endregion
                user.Avatar = "/Content/images/img/avatar.png";
                
                #region  Password Hashing 
                user.Password = Crypto.Hash(user.Password);
                user.ConfirmPassword = Crypto.Hash(user.ConfirmPassword);
                #endregion

                user.Estatus = false;

                #region Save to Database
                objUsuarioLogic.Insertar(user);
                message = "Registro exitoso";
                #endregion
            }
            else
            {
                message = "Verifique los Datos e intente nuevamente";
            }
            //ViewBag.Message = message;
            //ViewBag.Status = Status;
            return View(user);
        }

        //[NonAction]
        //public bool IsEmailExist(string emailID)
        //{
        //    using (DAL_Main dc = new DAL_Main())
        //    {
        //        var v = dc.Usuarios.Where(a => a.IdEmail == emailID).FirstOrDefault();
        //        return v != null;
        //    }
        //}

        //[NonAction]
        //public bool IsUserExist(string UserName)
        //{
        //    using (DAL_Main dc = new DAL_Main())
        //    {
        //        var v = dc.Usuarios.Where(a => a.NombreUsuario == UserName).FirstOrDefault();
        //        return v != null;
        //    }
        //}
        //Verify Account  
        
        //Login 
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        ////Login POST
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Login(LoginViewModel login, string ReturnUrl = "")
        //{
        //    string message = "";
        //    using (DAL_Main dc = new DAL_Main())
        //    {
        //        var v = dc.Usuarios.Where(a => a.NombreUsuario == login.NombreUsuario).FirstOrDefault();
        //        if (v != null)
        //        {
        //            if (!v.Estatus)
        //            {
        //                ViewBag.Message = "Usuario Inactivo, comuniquese con el administrador";
        //                return View();
        //            }

        //            if (string.Compare(Crypto.Hash(login.Password), v.Contrasena) == 0)
        //            {
        //                int timeout = login.RememberMe ? 525600 : 20; // 525600 min = 1 year
        //                var ticket = new FormsAuthenticationTicket(login.NombreUsuario, login.RememberMe, timeout);
        //                string encrypted = FormsAuthentication.Encrypt(ticket);
        //                var cookie = new HttpCookie(FormsAuthentication.FormsCookieName, encrypted);
        //                cookie.Expires = DateTime.Now.AddMinutes(timeout);
        //                cookie.HttpOnly = true;
        //                Response.Cookies.Add(cookie);


        //                if (Url.IsLocalUrl(ReturnUrl))
        //                {
        //                    return Redirect(ReturnUrl);
        //                }
        //                else
        //                {
        //                    return RedirectToAction("Index", "Home");
        //                }
        //            }
        //            else
        //            {
        //                message = "Usuario o ontrasena invalido";
        //            }
        //        }
        //        else
        //        {
        //            message = "Usuario o ontrasena invalido";
        //        }
        //    }
        //    ViewBag.Message = message;
        //    return View();
        //}

        //Logout
        [Authorize]
        [HttpPost]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "Usuario");
        }

    }
}