using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PagedList;
using HelpDesk_Kvas.Models.Datos.Logica;
using HelpDesk_Kvas.Models.Datos.Entity;

namespace HelpDesk_Kvas.Controllers
{
    public class GrupoController : Controller
    {
        GrupoLogic objGrupoLogic;

        public GrupoController()
        {
            objGrupoLogic = new GrupoLogic();
        }

        // GET: Grupo
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

            var grupos = objGrupoLogic.Listar();

            if (!String.IsNullOrEmpty(searchString))
            {
                grupos = grupos.Where(s => s.Titulo.ToUpper().Contains(searchString.ToUpper())
                                       || s.Descripcion.ToUpper().Contains(searchString.ToUpper()));

            }

            switch (sortOrder)
            {
                case "id_grupo":
                    grupos = grupos.OrderByDescending(s => s.IdGrupo);
                    break;
                case "name_desc":
                    grupos = grupos.OrderByDescending(s => s.Titulo);
                    break;
                default:  // Name ascending 
                    grupos = grupos.OrderBy(s => s.Titulo);
                    break;
            }

            int pageSize = 23;
            int pageNumber = (page ?? 1);
            return View(grupos.ToPagedList(pageNumber, pageSize));
        }

        // GET: Grupo/Details/5
        public ActionResult Details(int id)
        {
            if (id == Convert.ToInt32(null))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GruposEntity _grupo = objGrupoLogic.Buscar(id);

            var lista = objGrupoLogic.Listar();
            var filtro = lista.Where(m => m.IdGrupo == _grupo.IdPadre).FirstOrDefault();
            //SelectList list = new SelectList(lista, "IdGrupo", "Titulo");
            ViewBag.ListaGrupo = filtro.Titulo;
            return View(_grupo);
        }
        
        [ChildActionOnly]
        public ActionResult Create()
        {
            var lista = objGrupoLogic.Listar();
            SelectList list = new SelectList(lista, "IdGrupo", "Titulo");
            ViewBag.ListaGrupo = list;
            MensajeInicioRegistrar();
            return PartialView();
        }

        // POST: Grupo/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(GruposEntity objGrupo)
        {
            var nivel = objGrupoLogic.ListarNivel(Convert.ToInt32(objGrupo.IdPadre)).SingleOrDefault();
            if (nivel==null)
            {
                nivel = objGrupo;
                nivel.Nivel = 0;
            }
            if (nivel.Nivel < 3)
            {
                if (ModelState.IsValid)
                {
                    // TODO: Add insert logic here
                    if (objGrupo.IdPadre == null)
                    {
                        objGrupo.IdPadre = 0;
                    }
                    MensajeInicioRegistrar();
                    objGrupoLogic.Insertar(objGrupo);
                    MensajeErrorRegistrar(objGrupo);
                    var text = "Agregado Exitosamente";
                    return this.Json(new { EnableSuccess = true, SuccessTitle = "Success", SuccessMsg = text });
                }
            }
            objGrupo.Mensaje = 30;
            MensajeErrorRegistrar(objGrupo);


            return this.Json(new { EnableError = true, ErrorTitle = "Error", ErrorMsg = "Verifique los datos he intente nuevamente" });
        }

        // GET: Grupo/Edit/5
        public ActionResult Edit(int id)
        {
            if (id == Convert.ToInt32(null))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GruposEntity _grupo = objGrupoLogic.Buscar(id);
            var lista = objGrupoLogic.Listar();
            var filtro = lista.Where(m => m.IdGrupo == _grupo.IdGrupo).ToList();
            SelectList list = new SelectList(lista, "IdGrupo", "Titulo");
            ViewBag.ListaGrupo = list;
            if (_grupo == null)
            {
                return HttpNotFound();
            }
            return View(_grupo);
        }

        // POST: Grupo/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(GruposEntity objGrupo)
        {
            try
            {
                var nivel = objGrupoLogic.ListarNivel(Convert.ToInt32(objGrupo.IdPadre)).SingleOrDefault();
                if (nivel == null)
                {
                    nivel = objGrupo;
                    nivel.Nivel = 0;
                }
                if (nivel.Nivel < 3) {
                    if (ModelState.IsValid)
                    {
                        MensajeInicioActualizar();
                        objGrupoLogic.Actualizar(objGrupo);
                        MensajeErrorActualizar(objGrupo);
                        //var text = "Agregado Exitosamente";
                        //return this.Json(new { EnableSuccess = true, SuccessTitle = "Success", SuccessMsg = text });
                        return RedirectToAction("Index");
                    }
                }
                    
            }
            catch
            {
                return View();
            }
            GruposEntity _grupo = objGrupoLogic.Buscar(objGrupo.IdGrupo);
            var lista = objGrupoLogic.Listar();
            var filtro = lista.Where(m => m.IdGrupo == _grupo.IdGrupo).ToList();
            SelectList list = new SelectList(lista, "IdGrupo", "Titulo");
            ViewBag.ListaGrupo = list;
            //return this.Json(new { EnableError = true, ErrorTitle = "Error", ErrorMsg = "Verifique los datos he intente nuevamente" });
            return View(objGrupo);
        }

        // GET: Grupo/Delete/5
        public ActionResult Delete(int id)
        {
            if (id == Convert.ToInt32(null))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GruposEntity _grupo = objGrupoLogic.Buscar(id);
            if (_grupo == null)
            {
                return HttpNotFound();
            }
            return View(_grupo);
        }

        // POST: Grupo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(GruposEntity objGrupo)
        {
            try
            {
                MensajeInicialEliminar();
                objGrupoLogic.Eliminar(objGrupo);
                MensajeErrorActualizar(objGrupo);
                // TODO: Add delete logic here
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        [Authorize]
        public JsonResult Deletes(int id)
        {
            GruposEntity _grupo = objGrupoLogic.Buscar(id);
            objGrupoLogic.Eliminar(_grupo);
            return Json("Registro Eliminado", JsonRequestBehavior.AllowGet);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                
            }
            base.Dispose(disposing);
        }

        /// <summary>
        /// Mensajes de Error
        /// </summary>
        #region
        public void MensajeInicioRegistrar()
        {
            ViewBag.MensajeInicio = "Ingrese Datos De la Categoria y Click en Guardar";
        }
        public void MensajeErrorRegistrar(GruposEntity objGrupo)
        {
            switch (objGrupo.Mensaje)
            {
                case 1000://campo codigo vacio
                    ViewBag.MensajeError = "Error!!! Revise la instruccion Insertar";
                    break;
                case 10://campo codigo vacio
                    ViewBag.MensajeError = "Ingrese Código de la Categoria";
                    break;
                case 1://error campo cadigo
                    ViewBag.MensajeError = "No se permiten mas de 5 caracteres en al campo Codigo";
                    break;
                case 20://campo nombre vacio
                    ViewBag.MensajeError = "Ingrese Nombre del Cliente";
                    break;

                case 2://error de nombre
                    ViewBag.MensajeError = "No se permiten mas de 30 caracteres en el campo Nombre";
                    break;

                case 30://campo descripcion vacio
                    ViewBag.MensajeError = "Ingrese Descripcion Paterno de la Categoria";
                    break;

                case 3://error de Apellido Paterno
                    ViewBag.MensajeError = "No se permiten mas de 30 caracteres en el campo Categoria";
                    break;

                case 8://error de duplicidad
                    ViewBag.MensajeError = "Categoria [" + objGrupo.IdGrupo + "] ya esta Registrada en el Sistema";
                    break;
                case 99://carrera registrada con exito
                    ViewBag.MensajeExito = "Categoria [" + objGrupo.IdGrupo + "] fue Registrado en el Sistema";
                    break;
                case 98://carrera registrada con exito
                    ViewBag.MensajeExito = "Categoria [" + objGrupo.IdGrupo + "] Ya existe";
                    break;
            }
        }
        public void MensajeInicioActualizar()
        {
            ViewBag.MensajeInicio = "Ingrese Datos De la Categoria y Click en Guardar";
        }
        public void MensajeErrorActualizar(GruposEntity objGrupo)
        {
            switch (objGrupo.Mensaje)
            {
                case 1000://campo codigo vacio
                    ViewBag.MensajeError = "Error!!! Revise la instruccion de actualizar";
                    break;
                case 10://campo codigo vacio
                    ViewBag.MensajeError = "Ingrese Código del Producto";
                    break;
                case 1://error campo cadigo
                    ViewBag.MensajeError = "No se permiten mas de 5 caracteres en al campo Codigo";
                    break;
                case 20://campo nombre vacio
                    ViewBag.MensajeError = "Ingrese Nombre de la Categoria";
                    break;

                case 2://error de nombre
                    ViewBag.MensajeError = "No se permiten mas de 30 caracteres en el campo Nombre";
                    break;

                case 30://campo descripcion vacio
                    ViewBag.MensajeError = "Ingrese Descripcion de la Producto";
                    break;

                case 3://error de precio Unitario
                    ViewBag.MensajeError = "No se permiten mas de 50 caracteres en el campo Categoria";
                    break;

                case 99://carrera registrada con exito
                    ViewBag.MensajeExito = "Datos de la Categoria [" + objGrupo.IdGrupo + "] Fueron Actualizados";
                    break;
            }
        }
        public void MensajeInicialEliminar()
        {
            ViewBag.MensajeInicialEliminar = "Formulario de Eliminacion";
        }
        public void MostrarMensajeEliminar(GruposEntity objGrupo)
        {

            switch (objGrupo.Mensaje)
            {
                case 1000://campo codigo vacio
                    ViewBag.MensajeError = "Error!!! Revise la instruccion de Eliminar";
                    break;
                case 1: //ERROR DE EXISTENCIA
                    ViewBag.MensajeError = "Categoria [" + objGrupo.IdGrupo + "] No Esta Registrado en el Sistema ";
                    break;

                case 33://CLIENTE NO EXISTE
                    ViewBag.MensajeError = "Categoria: [" + objGrupo.Titulo + "]Ya Fue Eliminada";
                    break;
                case 34:
                    ViewBag.MensajeError = "No se Puede Eliminar la Categoria [" + objGrupo.Titulo + "] Tiene  Productos asignadoss!!!";
                    break;
                case 99: //EXITO
                    ViewBag.MensajeExito = "Categoria [" + objGrupo.Titulo + "] Fue Eliminado!!!";
                    break;

                default:
                    ViewBag.MensajeError = "===???===";
                    break;
            }
        } 
        public void MensajeErrorServidor(GruposEntity objGrupo)
        {
            switch (objGrupo.Mensaje)
            {
                case 1000:
                    ViewBag.MensajeError = "ERROR DE SERVIDOR DE SQL SERVER";
                    break;
            }
        }
        #endregion
    }
}
