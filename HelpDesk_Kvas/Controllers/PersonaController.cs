using HelpDesk_Kvas.DataGrid;
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
    public class PersonaController : Controller
    {
        GrupoDetalleLogic objGrupoDetalleLogic;
        GrupoLogic objGrupoLogic;
        PersonasLogic objPersonaLogic;
        public PersonaController()
        {
            objGrupoDetalleLogic = new GrupoDetalleLogic();
            objGrupoLogic = new GrupoLogic();
            objPersonaLogic = new PersonasLogic();
        }

        // GET: Persona
        public ActionResult Index(string filter = null, int page = 1, int pageSize = 15, string sort = "IdPersona")
        {
            //var id = 1;
            //, string sortdir = "DESC"
            var records = new PagedList<PersonasEntity>();
            ViewBag.filter = filter;
            var grupos = objGrupoDetalleLogic.ListarPorGrupo(2);
            var personasList = objPersonaLogic.Listar();

            records.Content = personasList.Where(m => filter == null || (m.Nombres.ToUpper().Contains(filter.ToUpper()))
                                || m.Identificacion.ToUpper().Contains(filter.ToUpper())
                                )
                                //.OrderBy(sort + " " + sortdir)
                                .Skip((page - 1) * pageSize)
                                .Take(pageSize).ToList();
            records.TotalRecords = personasList.Where(m => filter == null || (m.Nombres.ToUpper().Contains(filter.ToUpper()))
                                || m.Identificacion.ToUpper().Contains(filter.ToUpper())
                                ).Count();

            records.CurrentPage = page;
            records.PageSize = pageSize;

            return View(records);

        }

        // GET: Persona/Details/5
        public ActionResult Details(int id)
        {
            if (id == Convert.ToInt32(null))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var _persona = objPersonaLogic.Buscar(id);
            var m = _persona.IdTipoPersona;
            var _grupoDetalle = objGrupoDetalleLogic.Buscar(m);
            ViewBag.Cedula = (_grupoDetalle.Titulo);
            ViewBag.Identificacion = _grupoDetalle;
            if (_persona == null)
            {
                return HttpNotFound();
            }
            return PartialView("Details", _persona);
        }

        // GET: Persona/Create
        public ActionResult Create()
        {
            MensajeInicioRegistrar();
            var grupos = objGrupoDetalleLogic.ListarPorGrupo(3);
            SelectList listaGrupos = new SelectList(grupos, "IdGrupoDetalle", "Titulo");
            ViewBag.Lista = listaGrupos;
            return PartialView("Create");
        }

        // POST: Persona/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PersonasEntity persona)
        {
            if (ModelState.IsValid)
            {
                MensajeInicioRegistrar();
                objPersonaLogic.Insertar(persona);
                MensajeErrorRegistrar(persona);
                return Json(new { success = true });
            }
            return Json(persona, JsonRequestBehavior.AllowGet);
        }

        // GET: Persona/Edit/5
        public ActionResult Edit(int id)
        {
            if (id == Convert.ToInt32(null))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var _persona = objPersonaLogic.Buscar(id);
            var m = _persona.IdTipoPersona;
            var _grupoDetalle = objGrupoDetalleLogic.Buscar(m);
            ViewBag.Cedula = (_grupoDetalle.Titulo);
            ViewBag.Identificacion = _grupoDetalle;
            if (_persona == null)
            {
                return HttpNotFound();
            }
            return PartialView("Edit", _persona);
        }

        // POST: Persona/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(PersonasEntity persona)
        {
            if (ModelState.IsValid)
            {
                MensajeInicioActualizar();
                objPersonaLogic.Actualizar(persona);
                MensajeErrorActualizar(persona);
                return Json(new { success = true });
            }
            return Json(persona, JsonRequestBehavior.AllowGet);
        }

        // GET: Persona/Delete/5
        public ActionResult Delete(int id)
        {
            if (id == Convert.ToInt32(null))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var _persona = objPersonaLogic.Buscar(id);
            var m = _persona.IdTipoPersona;
            var _grupoDetalle = objGrupoDetalleLogic.Buscar(m);
            ViewBag.Cedula = (_grupoDetalle.Titulo);
            ViewBag.Identificacion = _grupoDetalle;
            ViewBag.Nombre = _persona.Nombres;
            if (_persona == null)
            {
                return HttpNotFound();
            }
            return PartialView("Delete", _persona);
        }

        // POST: Persona/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(PersonasEntity persona)
        {
            try
            {
                MensajeInicialEliminar();
                objPersonaLogic.Eliminar(persona);
                MensajeErrorEliminar(persona);
                return Json(new { success = true });
            }
            catch
            {
                return Json(persona, JsonRequestBehavior.AllowGet);
            }
        }

        #region
        public void MensajeInicioRegistrar()
        {
            ViewBag.MensajeInicio = "Ingrese datos del Cliente y Click en Guardar";
        }
        public void MensajeErrorRegistrar(PersonasEntity objPersona)
        {
            switch (objPersona.Mensaje)
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
                    ViewBag.MensajeError = "Categoria [" + objPersona.IdPersona + "] ya esta Registrada en el Sistema";
                    break;
                case 99://carrera registrada con exito
                    ViewBag.MensajeExito = "Categoria [" + objPersona.IdPersona + "] fue Registrado en el Sistema";
                    break;
                case 98://carrera registrada con exito
                    ViewBag.MensajeExito = "Categoria [" + objPersona.IdPersona + "] Ya existe";
                    break;
            }
        }
        public void MensajeInicioActualizar()
        {
            ViewBag.MensajeInicio = "Ingrese Datos De la Categoria y Click en Guardar";
        }
        public void MensajeErrorActualizar(PersonasEntity objPersona)
        {
            switch (objPersona.Mensaje)
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
                    ViewBag.MensajeExito = "Datos de la Categoria [" + objPersona.IdPersona + "] Fueron Actualizados";
                    break;
            }
        }
        public void MensajeInicialEliminar()
        {
            ViewBag.MensajeInicialEliminar = "Formulario de Eliminacion";
        }
        public void MensajeErrorEliminar(PersonasEntity objPersona)
        {

            switch (objPersona.Mensaje)
            {
                case 1000://campo codigo vacio
                    ViewBag.MensajeError = "Error!!! Revise la instruccion de Eliminar";
                    break;
                case 1: //ERROR DE EXISTENCIA
                    ViewBag.MensajeError = "Categoria [" + objPersona.IdPersona + "] No Esta Registrado en el Sistema ";
                    break;

                case 33://CLIENTE NO EXISTE
                    ViewBag.MensajeError = "Categoria: [" + objPersona.Nombres + "]Ya Fue Eliminada";
                    break;
                case 34:
                    ViewBag.MensajeError = "No se Puede Eliminar la Categoria [" + objPersona.Nombres + "] Tiene  Productos asignadoss!!!";
                    break;
                case 99: //EXITO
                    ViewBag.MensajeExito = "Categoria [" + objPersona.Nombres + "] Fue Eliminado!!!";
                    break;

                default:
                    ViewBag.MensajeError = "===???===";
                    break;
            }
        }
        public void MensajeErrorServidor(PersonasEntity objPersona)
        {
            switch (objPersona.Mensaje)
            {
                case 1000:
                    ViewBag.MensajeError = "ERROR DE SERVIDOR DE SQL SERVER";
                    break;
            }
        }
        #endregion
    }
}
