﻿using HelpDesk_Kvas.Models.Datos.DAL;
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

        //Login 
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        ////Login POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginUserEntity login, string ReturnUrl = "")
        {
            string message = "";
            if (ModelState.IsValid)
            {

                //using (dbDataContext dc = new dbDataContext())
                //{
                //    var v = dc.Usuarios.Where(a => a.NombreUsuario == login.UserName).FirstOrDefault();
                //    if (v != null)
                //    {
                //        if (!v.Estatus)
                //        {
                //            ViewBag.Message = "Please verify your email first";
                //            return View();
                //        }

                //        if (string.Compare(Crypto.Hash(login.Password), v.Contrasena) == 0)
                //        {
                //            int timeout = login.RememberMe ? 525600 : 20; // 525600 min = 1 year
                //            var ticket = new FormsAuthenticationTicket(login.UserName, login.RememberMe, timeout);
                //            string encrypted = FormsAuthentication.Encrypt(ticket);
                //            var cookie = new HttpCookie(FormsAuthentication.FormsCookieName, encrypted);
                //            cookie.Expires = DateTime.Now.AddMinutes(timeout);
                //            cookie.HttpOnly = true;
                //            Response.Cookies.Add(cookie);


                //            if (Url.IsLocalUrl(ReturnUrl))
                //            {
                //                return Redirect(ReturnUrl);
                //            }
                //            else
                //            {
                //                return RedirectToAction("Index", "Home");
                //            }
                //        }
                //        else
                //        {
                //            message = "Invalid credential provided";
                //        }
                //    }
                //    else
                //    {
                //        message = "Invalid credential provided";
                //    }
                //}

                var log = objUsuarioLogic.ListarLogin();
                var user = log.Where(x => x.UserName == login.UserName).FirstOrDefault();
                if (user != null)
                {
                    if (login.ContadorFallido > 5)
                    {
                        ViewBag.Message = "Usuario Bloqueado por 5 minutos";
                        return View();
                    }
                    if (!user.Estatus)
                    {
                        ViewBag.Message = "Usuario Inactivo, comuniquese con el administrador";
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
                            return RedirectToAction("Index", "Home");
                        }
                    }
                    else
                    {
                        login.ContadorFallido = user.ContadorFallido + 1;
                        objUsuarioLogic.LoginControl(login);
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