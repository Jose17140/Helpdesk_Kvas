using HelpDesk_Kvas.Models.Datos.Entity;
using HelpDesk_Kvas.Models.Datos.Logica;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;

namespace HelpDesk_Kvas.Controllers
{
    //[Authorize]
    public class AccountController : Controller
    {
        UsuarioLogic objUsuarioLogic;
        GrupoDetalleLogic objGrupoDetalleLogic;
        PersonasLogic objPersonaLogic;
        public AccountController()
        {
            objUsuarioLogic = new UsuarioLogic();
            objGrupoDetalleLogic = new GrupoDetalleLogic();
            objPersonaLogic = new PersonasLogic();
        }

        // GET: Usuario
        public ActionResult Index(string sortOrder, string currentFilter, string searchString, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.IdSortParm = String.IsNullOrEmpty(sortOrder) ? "id_grupo" : "";
            ViewBag.OrdenSortParm = sortOrder == "Date" ? "date_desc" : "Date";

            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;

            var usuarios = objUsuarioLogic.Listar();

            if (!String.IsNullOrEmpty(searchString))
            {
                usuarios = usuarios.Where(s => s.UserName.ToUpper().Contains(searchString.ToUpper())
                                            || s.Rol.ToUpper().Contains(searchString.ToUpper())
                );

            }

            switch (sortOrder)
            {
                case "id_grupo":
                    usuarios = usuarios.OrderByDescending(s => s.IdUsuario);
                    break;
                case "name_desc":
                    usuarios = usuarios.OrderByDescending(s => s.UserName);
                    break;
                default:  // Name ascending 
                    usuarios = usuarios.OrderBy(s => s.FechaRegistroUsuario);
                    break;
            }

            int pageSize = 10;
            int pageNumber = (page ?? 1);
            return View(usuarios.ToPagedList(pageNumber, pageSize));
        }

        [HttpGet]
        public ActionResult RegistrarA()
        {
            Listas();
            return View();
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult RegistrarA([Bind(Exclude = "FechaLogin,ContadorFallido,FechaModificacion")] UsuarioRegisterA user)
        {
            string message = "";
            // Model Validation 
            if (ModelState.IsValid)
            {
                var isExistEmail = false;
                #region //Email is already Exist 
                var isExistUser = objUsuarioLogic.IsUserExist(user.UserName);
                var isExistCi = objUsuarioLogic.IsCiExist(user.CiRif);
                if (isExistEmail)
                {
                    ModelState.AddModelError("EmailExist", "Correo electronico ya esta registrado");
                    Listas();
                    return View(user);
                }
                if (isExistUser)
                {
                    ModelState.AddModelError("UserExist", "El nombre de usuario ya se encuantra registrado");
                    Listas();
                    return View(user);
                }
                if (isExistCi)
                {
                    ModelState.AddModelError("UserExist", "El nombre de usuario ya se encuantra registrado");
                    Listas();
                    return View(user);
                }
                #endregion
                user.Avatar = "user.png";

                #region  Password Hashing 
                user.Password = Crypto.Hash(user.Password);
                user.ConfirmPassword = Crypto.Hash(user.ConfirmPassword);
                #endregion

                user.Estatus = true;

                #region Save to Database
                objUsuarioLogic.InsertarCompletoA(user);
                message = "Registro exitoso";
                #endregion
                //return RedirectToAction("Index", "Home");
                var text = "Agregado Exitosamente";
                //return this.Json(new { EnableSuccess = true, SuccessTitle = "Success", SuccessMsg = text });
                return View(user);
            }
            else
            {
                ModelState.AddModelError("EmailExist", "Por favor llenar ambas pestanas");
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
        [AllowAnonymous]
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
                user.Avatar = "user.png";
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

        [NonAction]
        private void Listas()
        {
            var _ListaDetalle = objGrupoDetalleLogic.Listar();
            var _Roles = _ListaDetalle.Where(m => m.IdGrupo == 4).ToList();
            _Roles = _ListaDetalle.Where(m => m.IdGrupo == 4).Where(m => m.IdGrupoDetalle >= 50).ToList();
            #region
            if (User.Identity.IsAuthenticated)
            {
                if (User.IsInRole("Master") == true)
                {
                    _Roles = _ListaDetalle.Where(m => m.IdGrupo == 4).Where(m => m.IdGrupoDetalle >= 46).ToList();
                }
                #region
                if (User.IsInRole("Supervidor") == true)
                {
                    _Roles = _ListaDetalle.Where(m => m.IdGrupo == 4).Where(m => m.IdGrupoDetalle >= 47).ToList();
                }
            }
            #endregion
            var grupos = objGrupoDetalleLogic.ListarPorGrupo(3);
            var _TiposP = _ListaDetalle.Where(m => m.IdGrupo == 3).ToList();
            SelectList listaGrupos = new SelectList(_TiposP, "IdGrupoDetalle", "Titulo");
            ViewBag.Lista = listaGrupos;

            SelectList listaRoles = new SelectList(_Roles, "IdGrupoDetalle", "Titulo");
            ViewBag.ListaRoles = listaRoles;

            //Lista Preguntas
            var _Preguntas = _ListaDetalle.Where(m => m.IdGrupo == 12).ToList();
            SelectList listaPreguntas = new SelectList(_Preguntas, "IdGrupoDetalle", "Titulo");
            ViewBag.ListaPreguntas = listaPreguntas;
            #endregion

        }
        [AllowAnonymous]
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
                            if (User.IsInRole("Cliente")==false)
                            {
                                return RedirectToAction("Index", "Home");
                            }
                            else
                            {
                                return RedirectToAction("Index", "Requerimiento");
                            }
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
        
        [Authorize]
        public ActionResult Detalles(int id)
        {
            var objUser = objUsuarioLogic.Listar().Where(m => m.IdUsuario.Equals(id)).SingleOrDefault();
            return View(objUser);
        }

        [Authorize]
        public ActionResult Editar(int id)
        {
            Listas();
            var objUser = objUsuarioLogic.Listar().Where(m => m.IdUsuario.Equals(id)).SingleOrDefault();
            return View(objUser); ;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar(EditarUsuario objUser)
        {
            Listas();
            try
            {
                if (ModelState.IsValid)
                {
                    objUsuarioLogic.Actualizar(objUser);
                }
            }
            catch (Exception)
            {
                throw;
            }
            return View(objUser);
        }

        public ActionResult Delete(int id)
        {
            Listas();
            var objUser = objUsuarioLogic.Listar().Where(m => m.IdUsuario.Equals(id)).SingleOrDefault();
            return View(objUser); ;
        }

        [HttpPost]
        public ActionResult Delete(EditarUsuario objUser)
        {
            Listas();
            try
            {
                var isExistUser = objUsuarioLogic.IsUserExist(objUser.UserName);
                if (isExistUser)
                {
                    ModelState.AddModelError("UserExist", "El nombre de usuario ya se fue Eliminado");
                    Listas();
                    return View(objUser);
                }
                if (ModelState.IsValid)
                {
                    objUsuarioLogic.EliminarUsuario(objUser);
                }
            }
            catch (Exception)
            {
                throw;
            }
            ModelState.AddModelError("UserExist", "Registro eliminado exitosamente");
            return View(objUser);
        }

        public ActionResult CambiarPass(int id)
        {
            Listas();
            var objUser = objUsuarioLogic.Listar().Where(m => m.IdUsuario.Equals(id)).SingleOrDefault();
            ViewBag.IdUsuario = objUser.IdUsuario;
            return View(); ;
        }

        //[Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CambiarPass(RecuperarContrasenaIdEntity objUser)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    #region  Password Hashing 
                    objUser.Password = Crypto.Hash(objUser.Password);
                    objUser.ConfirmPassword = Crypto.Hash(objUser.ConfirmPassword);
                    #endregion
                    objUsuarioLogic.ActualizarPassId(objUser);
                }
            }
            catch (Exception)
            {
                throw;
            }
            return View(objUser);
        }

        public ActionResult Perfil()
        {
            Listas();
            if (User.Identity.IsAuthenticated)
            {
                var name = User.Identity.Name;
                var objUser = objUsuarioLogic.Listar().Where(m => m.UserName.ToUpper().Equals(name.ToUpper())).SingleOrDefault();
                ViewBag.IdUsuario = objUser.IdUsuario;
                return View(objUser);
            }
            return View();
        }

        [HttpPost]
        public ActionResult Perfil(EditarUsuario objUser)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    objUsuarioLogic.ActualizarPerfil(objUser);
                    return RedirectToAction("Perfil", "Account");
                }
            }
            catch (Exception)
            {
                throw;
            }
            Listas();
            return View(objUser);
        }

        #region CAMBIO DE CONTRASENA

        public ActionResult ForgotPassword()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ForgotPassword(ForgotPasswordUserEntity user)
        {
            var isExistUser = objUsuarioLogic.IsUserExist(user.UserName);
            if (isExistUser == false)
            {
                ModelState.AddModelError("UserExist", "El nombre de usuario no se encuantra registrado");
                Listas();
                return View(user);
            }
            if (ModelState.IsValid)
            {
                var lista = objUsuarioLogic.Listar();
                var filtrar = lista.Where(m => m.UserName.ToUpper().Equals(user.UserName.ToUpper()));
                var selectuser = objUsuarioLogic.Listar().Where(m => m.UserName.ToUpper().Equals(user.UserName.ToUpper())).SingleOrDefault();
                var _user = selectuser.UserName;
                _user = Crypto.CodeHash(_user);
                RouteValueDictionary routeValueDictionary = new System.Web.Routing.RouteValueDictionary();
                routeValueDictionary.Add("_user", _user);
                return RedirectToAction("Confirmar", "Account", routeValueDictionary);
            }
            return View(user);
        }
        
        public ActionResult Confirmar(string _user)
        {
            Listas();
            _user = Crypto.DecodeHash(_user);
            var isExistUser = objUsuarioLogic.IsUserExist(_user);
            var lista = objUsuarioLogic.ListarPregunta();
            var user = lista.Where(m => m.UserName.ToUpper().Equals(_user.ToUpper())).SingleOrDefault();
            return View(user);
        }

        [HttpPost]
        public ActionResult Confirmar(ForgotQuestionUserEntity user)
        {
            var ConfirQuest = objUsuarioLogic.ConfirQuestion(user.RespuestaPregunta);
            if (ConfirQuest == false)
            {
                ModelState.AddModelError("UserExist", "Respuesta incorrecta");
                Listas();
                return View(user);
            }
            if (ModelState.IsValid)
            {
                var selectuser = objUsuarioLogic.Listar().Where(m => m.UserName.ToUpper().Equals(user.UserName.ToUpper())).SingleOrDefault();
                var _user = selectuser.UserName;
                _user = Crypto.CodeHash(_user);
                RouteValueDictionary routeValueDictionary = new System.Web.Routing.RouteValueDictionary();
                routeValueDictionary.Add("_user", _user);
                //return RedirectToAction("Confirmar", "Account", new { dato = _user });
                return RedirectToAction("RecuperarPass", "Account", routeValueDictionary);
            }
            return View(user);
        }

        public ActionResult RecuperarPass(string _user)
        {
            Listas();
            _user = Crypto.DecodeHash(_user);
            ViewBag.UserName = _user;
            return View();
        }

        [HttpPost]
        public ActionResult RecuperarPass(ChanagePasswordEntity user)
        {
            if (ModelState.IsValid)
            {
                #region  Password Hashing 
                user.Password = Crypto.Hash(user.Password);
                user.ConfirmPassword = Crypto.Hash(user.ConfirmPassword);
                #endregion
                objUsuarioLogic.CambiarPass(user);
                return RedirectToAction("Login", "Account");
            }
            return View(user);
        }
        #endregion
    }
}