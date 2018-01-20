using HelpDesk_Kvas.Models.Datos.Entity;
using HelpDesk_Kvas.Models.Datos.Logica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace HelpDesk_Kvas.Controllers
{
    //[Authorize]
    public class AccountController : Controller
    {
        UsuarioLogic objUsuarioLogic;
        GrupoDetalleLogic objGrupoDetalleLogic;
        public AccountController()
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
        public ActionResult RegistrarA()
        {
            var _ListaDetalle = objGrupoDetalleLogic.Listar();
            var _Roles = _ListaDetalle.Where(m => m.IdGrupo == 4).ToList();
            var _Preguntas = _ListaDetalle.Where(m => m.IdGrupo == 12).ToList();
            //Departamento Roles
            SelectList listaRoles = new SelectList(_Roles, "IdGrupoDetalle", "Titulo");
            //Departamento hijo
            SelectList listaPreguntas = new SelectList(_Preguntas, "IdGrupoDetalle", "Titulo");
            ViewBag.ListaRoles = listaRoles;
            ViewBag.ListaPreguntas = listaPreguntas;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult RegistrarA([Bind(Exclude = "FechaLogin,ContadorFallido,FechaModificacion")] RegisterUserEntity user)
        {
            string message = "";
            // Model Validation 
            if (ModelState.IsValid)
            {
                var isExistEmail = false;
                #region //Email is already Exist 
                var isExistUser = objUsuarioLogic.IsUserExist(user.UserName);
                if (isExistEmail)
                {
                    ModelState.AddModelError("EmailExist", "Correo electronico ya esta registrado");
                    var _ListaDetalle = objGrupoDetalleLogic.Listar();
                    var _Roles = _ListaDetalle.Where(m => m.IdGrupo == 4).ToList();
                    var _Preguntas = _ListaDetalle.Where(m => m.IdGrupo == 12).ToList();
                    //Departamento Roles
                    SelectList listaRoles = new SelectList(_Roles, "IdGrupoDetalle", "Titulo");
                    //Departamento hijo
                    SelectList listaPreguntas = new SelectList(_Preguntas, "IdGrupoDetalle", "Titulo");
                    ViewBag.ListaRoles = listaRoles;
                    ViewBag.ListaPreguntas = listaPreguntas;
                    return View(user);
                }
                if (isExistUser)
                {
                    ModelState.AddModelError("UserExist", "El nombre de usuario ya se encuantra registrado");
                    var _ListaDetalle = objGrupoDetalleLogic.Listar();
                    var _Roles = _ListaDetalle.Where(m => m.IdGrupo == 4).ToList();
                    var _Preguntas = _ListaDetalle.Where(m => m.IdGrupo == 12).ToList();
                    //Departamento Roles
                    SelectList listaRoles = new SelectList(_Roles, "IdGrupoDetalle", "Titulo");
                    //Departamento hijo
                    SelectList listaPreguntas = new SelectList(_Preguntas, "IdGrupoDetalle", "Titulo");
                    ViewBag.ListaRoles = listaRoles;
                    ViewBag.ListaPreguntas = listaPreguntas;
                    return View(user);
                }
                #endregion
                user.Avatar = "user7-128x128.jpg";

                #region  Password Hashing 
                user.Password = Crypto.Hash(user.Password);
                user.ConfirmPassword = Crypto.Hash(user.ConfirmPassword);
                #endregion

                user.Estatus = false;

                #region Save to Database
                objUsuarioLogic.Insertar(user);
                message = "Registro exitoso";
                #endregion
                //return RedirectToAction("Index", "Home");
                var text = "Agregado Exitosamente";
                return this.Json(new { EnableSuccess = true, SuccessTitle = "Success", SuccessMsg = text });
            }
            else
            {
                message = "Verifique los Datos e intente nuevamente";
            }
            ViewBag.Message = message;
            return View(user);
        }

        [HttpGet]
        public ActionResult RegistrarB()
        {
            var _ListaDetalle = objGrupoDetalleLogic.Listar();
            var _Roles = _ListaDetalle.Where(m => m.IdGrupo == 4 && m.Titulo == "Cliente").ToList();
            var _Preguntas = _ListaDetalle.Where(m => m.IdGrupo == 12).ToList();
            //Departamento Roles
            SelectList listaRoles = new SelectList(_Roles, "IdGrupoDetalle", "Titulo");
            //Departamento hijo
            SelectList listaPreguntas = new SelectList(_Preguntas, "IdGrupoDetalle", "Titulo");
            ViewBag.ListaRoles = listaRoles;
            ViewBag.ListaPreguntas = listaPreguntas;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult RegistrarB([Bind(Exclude = "Email,FechaLogin,ContadorFallido,FechaModificacion")] RegisterUserEntity user)
        {
            var _ListaDetalle = objGrupoDetalleLogic.Listar();
            var _Roles = _ListaDetalle.Where(m => m.IdGrupo == 4 && m.Titulo=="Cliente").ToList();
            var _Preguntas = _ListaDetalle.Where(m => m.IdGrupo == 12).ToList();
            // Model Validation 
            if (ModelState.IsValid)
            {
                var isExistEmail = false;
                #region //Email is already Exist 
                var isExistUser = objUsuarioLogic.IsUserExist(user.UserName);
                if (isExistEmail)
                {
                    ModelState.AddModelError("EmailExist", "Correo electronico ya esta registrado");
                    //Preguntas
                    SelectList listaPreguntas = new SelectList(_Preguntas, "IdGrupoDetalle", "Titulo");
                    ViewBag.ListaPreguntas = listaPreguntas;
                    return View(user);
                }
                if (isExistUser)
                {
                    ModelState.AddModelError("UserExist", "El nombre de usuario ya se encuantra registrado");
                    //Preguntas
                    SelectList listaPreguntas = new SelectList(_Preguntas, "IdGrupoDetalle", "Titulo");
                    ViewBag.ListaPreguntas = listaPreguntas;
                    return View(user);
                }
                #endregion
                #region  Password Hashing 
                user.Password = Crypto.Hash(user.Password);
                user.ConfirmPassword = Crypto.Hash(user.ConfirmPassword);
                #endregion
                user.Avatar = "user7-128x128.jpg";
                user.Estatus = true;
                user.IdRoles = _Roles.Select(m => m.IdGrupoDetalle).SingleOrDefault();
                #region Save to Database
                objUsuarioLogic.Insertar(user);
                #endregion
                return RedirectToAction("Login", "Account");
            }
            else
            {
                ModelState.AddModelError("UserExist", "Verifique los Datos e intente nuevamente");
            }
            return View(user);
        }
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginUserEntity login, string ReturnUrl = "")
        {
            if (ModelState.IsValid)
            {
                var log = objUsuarioLogic.ListarLogin();
                var user = log.Where(x => x.UserName.ToUpper().Contains(login.UserName.ToUpper())).FirstOrDefault();
                if (user != null)
                {
                    if (user.ContadorFallido > 5)
                    {
                        ModelState.AddModelError("Usuario Bloqueado", "Usuario bloqueado para desbloquear contacte al administrador");
                        return View();
                    }
                    if (!user.Estatus)
                    {
                        ModelState.AddModelError("Usuario Inactivo", "Usuario incativo para desbloquear contacte al administrador");
                        return View();
                    }
                    if (string.Compare(Crypto.Hash(login.Password), user.Password) == 0)
                    {
                        login.ContadorFallido = 0;
                        objUsuarioLogic.LoginControl(login);
                        int timeout = login.RememberMe ? 525600 : 20; // 525600 min = 1 year
                        var ticket = new FormsAuthenticationTicket(login.UserName, login.RememberMe, timeout);
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
                            return RedirectToAction("Index", "Requerimiento");
                        }
                    }
                    else
                    {
                        var con = user.ContadorFallido + 1;
                        login.ContadorFallido = con;
                        objUsuarioLogic.LoginControl(login);
                        ModelState.AddModelError("Datos invalidos", "Usuario o ontrasena invalido");
                    }
                }
                else
                {
                    ModelState.AddModelError("Datos invalidos", "Usuario o ontrasena invalido");
                }
            }
            return View();
        }
        
        [Authorize]
        [HttpPost]
        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "Account");
        }

    }
}