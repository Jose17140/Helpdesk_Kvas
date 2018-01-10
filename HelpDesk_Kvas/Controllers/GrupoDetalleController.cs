using HelpDesk_Kvas.DataGrid;
using HelpDesk_Kvas.Models;
using HelpDesk_Kvas.Models.Datos.Entity;
using HelpDesk_Kvas.Models.Datos.Logica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace HelpDesk_Kvas.Controllers
{
    public class GrupoDetalleController : Controller
    {
        GrupoDetalleLogic objGrupoDetalleLogic;
        GrupoLogic objGrupoLogic;
        DAL_Main db;
        public GrupoDetalleController()
        {
            objGrupoDetalleLogic = new GrupoDetalleLogic();
            objGrupoLogic = new GrupoLogic();
            db = new DAL_Main();
        }

        //public ActionResult Index(int id, int? Nv2, int? Nv3, string filter = null, int page = 1, int pageSize = 15, string sort = "IdGrupoDetalle")
        //{
        //    ViewBag.Id = id;
        //    var lista = new PagedList<GruposDetallesView>();
        //    var _grupo = objGrupoDetalleLogic.ListarView();
        //    lista.Content = _grupo.Where(m => m.IdGrupo == id).ToList();
        //    //PROGRAMAR FILTRO DE 3 NIVELES EN LA RECURSIVIDAD, ID PARA AGREGAR HIJOS Y VALIDAD
        //    if (Nv2 != null)
        //    {
        //        ViewBag.Nv2 = Nv2.Value;
        //        lista.Content2 = _grupo.Where(m => m.IdPadre == Nv2).ToList();
        //    }
        //    if (Nv3 != null)
        //    {
        //        ViewBag.Nv3 = Nv3.Value;
        //        lista.Content3 = _grupo.Where(m => m.IdPadre == Nv3).ToList();
        //    }
        //    //var grupos = objGrupoLogic.Listar();

        //    lista.CurrentPage = page;
        //    lista.PageSize = pageSize;
        //    return View(lista);

        //}

        public ActionResult Index(int id, string filter = null, int page = 1, int pageSize = 15, string sort = "IdGrupoDetalle")
        {
            var records = new PagedList<GruposDetallesView>();
            ViewBag.Id = id;
            ViewBag.filter = filter;
            var grupos = objGrupoDetalleLogic.ListarPorGrupo(id);
            var l = objGrupoLogic.Buscar(id);
            var n = l.Titulo;
            ViewBag.Nombre = n;

            var _grupos = objGrupoDetalleLogic.ListarView();
            records.Content = grupos.Where(m => filter == null || (m.Titulo.ToUpper().Contains(filter.ToUpper()))
                                || m.Descripcion.ToUpper().Contains(filter.ToUpper())
                                )
                                //.OrderBy(sort + " " + sortdir)
                                .Skip((page - 1) * pageSize)
                                .Take(pageSize).ToList();

            // Count
            records.TotalRecords = grupos.Where(m => filter == null || (m.Titulo.ToUpper().Contains(filter.ToUpper()))
                                || m.Descripcion.ToUpper().Contains(filter.ToUpper())
                                ).Count();

            records.CurrentPage = page;
            records.PageSize = pageSize;

            return View(records);
        }

        // GET: Grupo/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Grupo/Create
        //[ChildActionOnly]
        public ActionResult Create(int id)
        {
            MensajeInicioRegistrar();
            ViewBag.Id = id;
            var m = objGrupoLogic.Buscar(id);
            ViewBag.Nombre = m.Titulo;
            ViewBag.IdPadre = m.IdPadre;
            var listaPdres = objGrupoDetalleLogic.ListarPorGrupo(Convert.ToInt32(m.IdPadre));
            SelectList listaDetalles = new SelectList(listaPdres, "IdGrupoDetalle", "Titulo");
            ViewBag.ListaGruposDetalles = listaDetalles;
            return PartialView("Create");
        }

        // POST: Grupo/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        //[ChildActionOnly]
        public ActionResult Create(GruposDetallesEntity objGrupo)
        {
            if (ModelState.IsValid)
            {
                ViewBag.Id = objGrupo.IdGrupo;
                // TODO: Add insert logic here
                MensajeInicioRegistrar();
                objGrupoDetalleLogic.Insertar(objGrupo);
                MensajeErrorRegistrar(objGrupo);
                return Json(new { success = true });
            }
            ViewBag.Id = objGrupo.IdGrupo;
            var m = objGrupoLogic.Buscar(Convert.ToInt32(objGrupo.IdGrupo));
            ViewBag.Nombre = m.Titulo;
            ViewBag.IdPadre = m.IdPadre;
            var listaPdres = objGrupoDetalleLogic.ListarPorGrupo(Convert.ToInt32(m.IdPadre));
            SelectList listaDetalles = new SelectList(listaPdres, "IdGrupoDetalle", "Titulo");
            ViewBag.ListaGruposDetalles = listaDetalles;
            //return Json(objGrupo, JsonRequestBehavior.AllowGet);
            return View(objGrupo);
        }

        // GET: Grupo/Edit/5
        //[ChildActionOnly]
        public ActionResult Edit(int id)
        {
            if (id == Convert.ToInt32(null))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ViewBag.Id = id;
            MensajeInicioActualizar();

            GruposDetallesEntity _grupo = objGrupoDetalleLogic.Buscar(id);
            var i = _grupo.IdGrupo;
            var m = objGrupoLogic.Buscar(Convert.ToInt32(i));
            var n = m.Titulo;
            ViewBag.Nombre = n;
            var j = m.IdPadre;
            ViewBag.IdPadre = j;

            var listaPdres = objGrupoDetalleLogic.ListarPorGrupo(Convert.ToInt32(m.IdPadre)).ToList();
            SelectList listaDetalles = new SelectList(listaPdres, "IdGrupoDetalle", "Titulo");
            ViewBag.ListaGruposDetalles = listaDetalles;
            if (_grupo == null)
            {
                return HttpNotFound();
            }
            return PartialView("Edit", _grupo);
        }

        // POST: Grupo/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        //[ChildActionOnly]
        public ActionResult Edit(GruposDetallesEntity objGrupo)
        {
            if (objGrupo.IdPadre == null)
            {
                objGrupo.IdPadre = 0;
            }
            if (ModelState.IsValid)
            {
                ViewBag.Id = objGrupo.IdGrupo;
                MensajeInicioActualizar();
                objGrupoDetalleLogic.Actualizar(objGrupo);
                MensajeErrorActualizar(objGrupo);
                return Json(new { success = true });
            }
            return Json(objGrupo, JsonRequestBehavior.AllowGet);
        }

        // GET: Grupo/Delete/5
        //[ChildActionOnly]
        public ActionResult Delete(int id)
        {
            if (id == Convert.ToInt32(null))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GruposDetallesEntity _grupo = objGrupoDetalleLogic.Buscar(id);
            ViewBag.Nombre = _grupo.Titulo;
            if (_grupo == null)
            {
                return HttpNotFound();
            }
            return PartialView("Delete", _grupo);
        }

        // POST: Grupo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        //[ChildActionOnly]
        public ActionResult Delete(GruposDetallesEntity objGrupo)
        {
            try
            {
                MensajeInicialEliminar();
                objGrupoDetalleLogic.Eliminar(objGrupo);
                MensajeErrorActualizar(objGrupo);
                // TODO: Add delete logic here

                return Json(new { success = true });
            }
            catch
            {
                return View();
            }
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
        public void MensajeErrorRegistrar(GruposDetallesEntity objGrupo)
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
                    ViewBag.MensajeError = "Categoria [" + objGrupo.IdGrupoDetalle + "] ya esta Registrada en el Sistema";
                    break;
                case 99://carrera registrada con exito
                    ViewBag.MensajeExito = "Categoria [" + objGrupo.IdGrupoDetalle + "] fue Registrado en el Sistema";
                    break;
                case 98://carrera registrada con exito
                    ViewBag.MensajeExito = "Categoria [" + objGrupo.IdGrupoDetalle + "] Ya existe";
                    break;
            }
        }
        public void MensajeInicioActualizar()
        {
            ViewBag.MensajeInicio = "Ingrese Datos De la Categoria y Click en Guardar";
        }
        public void MensajeErrorActualizar(GruposDetallesEntity objGrupo)
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
                    ViewBag.MensajeExito = "Datos de la Categoria [" + objGrupo.IdGrupoDetalle + "] Fueron Actualizados";
                    break;
            }
        }
        public void MensajeInicialEliminar()
        {
            ViewBag.MensajeInicialEliminar = "Formulario de Eliminacion";
        }
        public void MostrarMensajeEliminar(GruposDetallesEntity objGrupo)
        {

            switch (objGrupo.Mensaje)
            {
                case 1000://campo codigo vacio
                    ViewBag.MensajeError = "Error!!! Revise la instruccion de Eliminar";
                    break;
                case 1: //ERROR DE EXISTENCIA
                    ViewBag.MensajeError = "Categoria [" + objGrupo.IdGrupoDetalle + "] No Esta Registrado en el Sistema ";
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
        public void MensajeErrorServidor(GruposDetallesEntity objGrupo)
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
