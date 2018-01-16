using HelpDesk_Kvas.DataGrid;
using HelpDesk_Kvas.Models;
using HelpDesk_Kvas.Models.Datos.DAL;
using HelpDesk_Kvas.Models.Datos.Entity;
using HelpDesk_Kvas.Models.Datos.Logica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HelpDesk_Kvas.Controllers
{
    public class RequerimientoController : Controller
    {
        GrupoDetalleLogic objGrupoDetalleLogic;
        GrupoLogic objGrupoLogic;
        RequerimientoLogic objRequerimientoLogic;
        UsuarioLogic objUsuario;
        PersonasLogic objPersonaLogic;
        DAL_Main db;

        public RequerimientoController()
        {
            objGrupoDetalleLogic = new GrupoDetalleLogic();
            objGrupoLogic = new GrupoLogic();
            objRequerimientoLogic = new RequerimientoLogic();
            objUsuario = new UsuarioLogic();
            objPersonaLogic = new PersonasLogic();
            db = new DAL_Main();
        }

        // GET: Requerimiento
        public ActionResult Index(int idEstatus = 58, string filter = null, int page = 1, int pageSize = 15, string sort = "IdRequerimiento")
        {
            var records = new PagedList<RequerimientoViewEntity>();
            ViewBag.Id = idEstatus;
            ViewBag.filter = filter;
            var grupos = objRequerimientoLogic.Listar();


            records.Content = grupos.Where(m => filter == null || (m.Cliente.ToUpper().Contains(filter.ToUpper()))
                                || m.Cedula.ToUpper().Contains(filter.ToUpper())
                                //|| m.FechaEntrada == filter.ToU) filtro por fecha
                                )
                                //.OrderBy(sort + " " + sortdir)
                                .Skip((page - 1) * pageSize)
                                .Take(pageSize).ToList();

            // Count
            records.TotalRecords = grupos.Where(m => filter == null || (m.Cliente.ToUpper().Contains(filter.ToUpper()))
                                || m.Cedula.ToUpper().Contains(filter.ToUpper())
                                ).Count();

            records.CurrentPage = page;
            records.PageSize = pageSize;

            return View(records);
        }

        // GET: Requerimiento/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        #region DROPDOWN 
        public JsonResult ObtenerEquipo(string _departamento)
        {
            var list = objGrupoDetalleLogic.Listar();
            var _equipos = list.Where(m => m.IdGrupo.Equals(14)).Where(m=>m.IdPadre.Equals(Convert.ToInt32(_departamento))).ToList();
            return Json(new SelectList(_equipos, "IdGrupoDetalle", "Titulo"));
        }

        public JsonResult ObtenerModelo(string _equipo)
        {
            var list = objGrupoDetalleLogic.Listar();
            var _modelos = list.Where(m => m.IdGrupo.Equals(27)).Where(m=>m.IdPadre.Equals(Convert.ToInt32(_equipo))).ToList();
            return Json(new SelectList(_modelos, "IdGrupoDetalle", "Titulo"));
        }

        public JsonResult ObtenerMarca(string _marca)
        {
            var list = objGrupoDetalleLogic.Listar();
            var _modelos = list.Where(m => m.IdGrupo.Equals(10)).Where(m => m.IdPadre.Equals(Convert.ToInt32(_marca))).ToList();
            return Json(new SelectList(_modelos, "IdGrupoDetalle", "Titulo"));
        }

        [HttpPost]
        public JsonResult BuscarPersona(string _ci)
        {
            var personas = objPersonaLogic.Listar();
            var p = (from m in personas
                     where m.CiRif.ToUpper().StartsWith(_ci)
                     select new { BuscarCliente = m.CiRif, Nombres=m.Nombres, Telefonos=m.Telefonos, Direccion=m.Direccion, Correo=m.Email }).ToList();
            return Json(p, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region PASOS PARA QUE UN CLIENTE GENERE UN REQUERIMEINTO
        // GET: Requerimiento/Create
        public ActionResult ElegirDepartamento()
        {
            MensajeInicioRegistrar();
            var lista = objGrupoDetalleLogic.Listar();
            var _lista = lista.Where(m => m.IdPadre == 36).ToList();
            return View(_lista);
        }
        #endregion


        // GET: Requerimiento/Create
        [HttpGet]
        public ActionResult Create()
        {
            MensajeInicioRegistrar();
            var list = objGrupoDetalleLogic.Listar();
            #region LISTADO DE SELECT QUE SE DESPLEGARAN EN LA VISTA
            //Lista Departamento
            var _departamentos = list.Where(m => m.IdPadre.Equals(36)).ToList();
            SelectList listDepartamentos = new SelectList(_departamentos, "IdGrupoDetalle", "Titulo");
            ViewBag.Departamentos = listDepartamentos;
            //Lista Prioridades
            var _prioridades = list.Where(m => m.IdGrupo.Equals(19)).ToList();
            SelectList listPrioridadess = new SelectList(_prioridades, "IdGrupoDetalle", "Titulo");
            ViewBag.Prioridades = listPrioridadess;
            //Lista Marca
            var _marcas = list.Where(m => m.IdGrupo.Equals(10)).ToList();
            SelectList listMarcas = new SelectList(_marcas, "IdGrupoDetalle", "Titulo");
            ViewBag.Marcas = listMarcas;
            //Lista Marca
            var _estatus = list.Where(m => m.IdGrupo.Equals(29)).ToList();
            SelectList listEstatus = new SelectList(_estatus, "IdGrupoDetalle", "Titulo");
            ViewBag.Marcas = listEstatus;
            #endregion
            #region LISTA DE ACCESORIOS
            var _accesorios = list.Where(m => m.IdGrupo.Equals(11)).ToList();
            var viewModel = new List<AxR>();
            foreach (var accsesorios in _accesorios)
            {
                viewModel.Add(new AxR
                {
                    IdAccesorio = accsesorios.IdGrupoDetalle,
                    Nombre = accsesorios.Titulo,
                    //Asigando = instructorCourses.Contains(course.CourseID)
                });
            }
            ViewBag.Accesorios = viewModel;
            #endregion
            if (User.Identity.IsAuthenticated)
            {
                var user = HttpContext.User.Identity.Name;
                var u = objUsuario.Buscar_x_Nombre(user);
                ViewBag.IdUsuario = u.IdUsuario;
            }
            return View();
        }

        // POST: Requerimiento/Create
        [HttpPost]
        public ActionResult Create(RequerimientosEntity objRequerimiento)
        {
            var listPersonas = objPersonaLogic.Listar();
            var idCliente = listPersonas.Where(m => m.CiRif.Equals(objRequerimiento.BuscarCliente)).Select(m=>m.IdPersona).SingleOrDefault();
            if (ModelState.IsValid)
            {

            }
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        private void AsignarAccesoriosPorRequermiento(RequerimientosEntity requerimeitno)
        {
            var lista = objGrupoDetalleLogic.Listar();
            
        }

        // GET: Requerimiento/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Requerimiento/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Requerimiento/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Requerimiento/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
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
