using HelpDesk_Kvas.Models;
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
        DAL_Main db = new DAL_Main();
        // GET: Usuario
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Registration()
        {
            return View();
        }
        //Registration POST action 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Registrar([Bind(Exclude = "FechaLogin,ContadorFallido,FechaModificacion")] RegisterViewModel user)
        {
            string message = "";
            // Model Validation 
            if (ModelState.IsValid)
            {

                #region //Email is already Exist 
                var isExistEmail = IsEmailExist(user.IdEmail);
                var isExistUser = IsUserExist(user.NombreUsuario);
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
                user.Contrasena = Crypto.Hash(user.Contrasena);
                user.ConfirmPassword = Crypto.Hash(user.ConfirmPassword);
                #endregion
                user.Estatus = false;

                #region Save to Database
                using (DAL_Main dc = new DAL_Main())
                {
                    dc.Usuarios.Add(user);
                    dc.SaveChanges();
                    message = "Registro exitoso";
                }
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

        [NonAction]
        public bool IsEmailExist(string emailID)
        {
            using (DAL_Main dc = new DAL_Main())
            {
                var v = dc.Usuarios.Where(a => a.IdEmail == emailID).FirstOrDefault();
                return v != null;
            }
        }

        [NonAction]
        public bool IsUserExist(string UserName)
        {
            using (DAL_Main dc = new DAL_Main())
            {
                var v = dc.Usuarios.Where(a => a.NombreUsuario == UserName).FirstOrDefault();
                return v != null;
            }
        }
        //Verify Account  
        
        //Login 
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        //Login POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginViewModel login, string ReturnUrl = "")
        {
            string message = "";
            using (DAL_Main dc = new DAL_Main())
            {
                var v = dc.Usuarios.Where(a => a.NombreUsuario == login.NombreUsuario).FirstOrDefault();
                if (v != null)
                {
                    if (!v.Estatus)
                    {
                        ViewBag.Message = "Usuario Inactivo, comuniquese con el administrador";
                        return View();
                    }

                    if (string.Compare(Crypto.Hash(login.Password), v.Contrasena) == 0)
                    {
                        int timeout = login.RememberMe ? 525600 : 20; // 525600 min = 1 year
                        var ticket = new FormsAuthenticationTicket(login.NombreUsuario, login.RememberMe, timeout);
                        string encrypted = FormsAuthentication.Encrypt(ticket);
                        var cookie = new HttpCookie(FormsAuthentication.FormsCookieName, encrypted);
                        cookie.Expires = DateTime.Now.AddMinutes(timeout);
                        cookie.HttpOnly = true;
                        Response.Cookies.Add(cookie);


                        if (Url.IsLocalUrl(ReturnUrl))
                        {
                            return Redirect(ReturnUrl);
                        }
                        else
                        {
                            return RedirectToAction("Index", "Home");
                        }
                    }
                    else
                    {
                        message = "Usuario o ontrasena invalido";
                    }
                }
                else
                {
                    message = "Usuario o ontrasena invalido";
                }
            }
            ViewBag.Message = message;
            return View();
        }

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