using KvasEntity;
using KvasLogic;
using PagedList;
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
        public GrupoDetalleController()
        {
            objGrupoDetalleLogic = new GrupoDetalleLogic();
            objGrupoLogic = new GrupoLogic();
        }

        // GET: Grupo
        public ActionResult Index(int _id, string sortOrder, string currentFilter, string searchString, int? page)
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

            var grupos = objGrupoDetalleLogic.ListarPorGrupo(_id);

            if (!String.IsNullOrEmpty(searchString))
            {
                grupos = grupos.Where(s => s.Titulo.ToUpper().Contains(searchString.ToUpper())
                                       || s.Descripcion.ToUpper().Contains(searchString.ToUpper()));
            }
            switch (sortOrder)
            {
                case "id_grupo":
                    grupos = grupos.OrderByDescending(s => s.IdGrupoDetalle);
                    break;
                case "name_desc":
                    grupos = grupos.OrderByDescending(s => s.Titulo);
                    break;
                case "Date":
                    grupos = grupos.OrderBy(s => s.Orden);
                    break;
                case "date_desc":
                    grupos = grupos.OrderByDescending(s => s.Orden);
                    break;
                default:  // Name ascending 
                    grupos = grupos.OrderBy(s => s.Titulo);
                    break;
            }

            int pageSize = 10;
            int pageNumber = (page ?? 1);
            return View(grupos.ToPagedList(pageNumber, pageSize));
        }

        public ActionResult IndexTest(int id)
        {
            var grupos = objGrupoDetalleLogic.ListarPorGrupo(id);
            return View(grupos);
        }

        // GET: Grupo/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Grupo/Create
        //[ChildActionOnly]
        public ActionResult Create()
        {
            //LISTA DE GRUPO
            var listaGrupos = objGrupoLogic.Listar();
            var listaDetalles = objGrupoDetalleLogic.Listar();

            SelectList grupos = new SelectList(listaGrupos, "IdGrupo", "Titulo");
            SelectList gruposDetalles = new SelectList(listaDetalles, "IdGrupoDetalle","Titulo");
            ViewBag.ListaGrupos = grupos;
            ViewBag.ListaGruposDetalles = gruposDetalles;
            //LISTA DE PADRES

            //ViewBag.ELEMENTO = new SelectList(CONSULTA, "ID","NOMBRE");
            MensajeInicioRegistrar();
            return View();
        }

        // POST: Grupo/Create
        [HttpPost]
        //[ValidateAntiForgeryToken]
        //[ChildActionOnly]
        public ActionResult Create(GruposDetallesEntity objGrupo)
        {
            try
            {
                // TODO: Add insert logic here
                MensajeInicioRegistrar();
                objGrupoDetalleLogic.Insertar(objGrupo);
                MensajeErrorRegistrar(objGrupo);
                return View("Create");
            }
            catch
            {
                return View();
            }
        }

        // GET: Grupo/Edit/5
        //[ChildActionOnly]
        public ActionResult Edit(int id)
        {
            if (id == Convert.ToInt32(null))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GruposDetallesEntity _grupo = objGrupoDetalleLogic.Buscar(id);
            return View(_grupo);
        }

        // POST: Grupo/Edit/5
        [HttpPost]
        //[ValidateAntiForgeryToken]
        //[ChildActionOnly]
        public ActionResult Edit(GruposDetallesEntity objGrupo)
        {
            try
            {
                MensajeInicioActualizar();
                objGrupoDetalleLogic.Actualizar(objGrupo);
                MensajeErrorActualizar(objGrupo);
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
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
            return View(_grupo);
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

                return RedirectToAction("Index");
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
