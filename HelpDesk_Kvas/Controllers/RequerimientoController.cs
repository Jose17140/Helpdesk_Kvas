//using HelpDesk_Kvas.DataGrid;
using HelpDesk_Kvas.Models;
using HelpDesk_Kvas.Models.Datos.DAL;
using HelpDesk_Kvas.Models.Datos.Entity;
using HelpDesk_Kvas.Models.Datos.Logica;
using PagedList;
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
        BitacoraLogic objBitacora;
        DAL_Main db;

        public RequerimientoController()
        {
            objGrupoDetalleLogic = new GrupoDetalleLogic();
            objGrupoLogic = new GrupoLogic();
            objRequerimientoLogic = new RequerimientoLogic();
            objUsuario = new UsuarioLogic();
            objPersonaLogic = new PersonasLogic();
            objBitacora = new BitacoraLogic();
            db = new DAL_Main();
        }
        #region INDEX HECHO PARA CARGAR CON JSON 
        // GET: Requerimiento
        //public ActionResult Index(int idEstatus = 58, string filter = null, int page = 1, int pageSize = 15, string sort = "IdRequerimiento")
        //{
        //    var records = new PagedList<RequerimientoViewEntity>();
        //    ViewBag.Id = idEstatus;
        //    ViewBag.filter = filter;
        //    var grupos = objRequerimientoLogic.Listar();


        //    records.Content = grupos.Where(m => filter == null || (m.Cliente.ToUpper().Contains(filter.ToUpper()))
        //                        || m.Cedula.ToUpper().Contains(filter.ToUpper())
        //                        //|| m.FechaEntrada == filter.ToU) filtro por fecha
        //                        )
        //                        //.OrderBy(sort + " " + sortdir)
        //                        .Skip((page - 1) * pageSize)
        //                        .Take(pageSize).ToList();

        //    // Count
        //    records.TotalRecords = grupos.Where(m => filter == null || (m.Cliente.ToUpper().Contains(filter.ToUpper()))
        //                        || m.Cedula.ToUpper().Contains(filter.ToUpper())
        //                        ).Count();

        //    records.CurrentPage = page;
        //    records.PageSize = pageSize;

        //    return View(records);
        //}
        #endregion

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

            var requerimientos = objRequerimientoLogic.Listar();

            if (!String.IsNullOrEmpty(searchString))
            {
                requerimientos = requerimientos.Where(s => s.Nombres.ToUpper().Contains(searchString.ToUpper())
                                       || s.CiRif.ToUpper().Contains(searchString.ToUpper())
                                       || s.CiRif.ToUpper().Contains(searchString.ToUpper()));

            }
            //if (!String.IsNullOrEmpty(searchString))
            //{
            //    requerimientos = requerimientos.Where(s => s.Cliente.ToUpper().Contains(searchString.ToUpper())
            //                           || s.Cedula.ToUpper().Contains(searchString.ToUpper())
            //                           || s.Cedula.ToUpper().Contains(searchString.ToUpper()));

            //}

            switch (sortOrder)
            {
                case "id_grupo":
                    requerimientos = requerimientos.OrderByDescending(s => s.IdRequerimiento);
                    break;
                case "name_desc":
                    requerimientos = requerimientos.OrderByDescending(s => s.FechaEntrada);
                    break;
                default:  // Name ascending 
                    requerimientos = requerimientos.OrderBy(s => s.IdPrioridad);
                    break;
            }

            int pageSize = 23;
            int pageNumber = (page ?? 1);
            return View(requerimientos.ToPagedList(pageNumber, pageSize));
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
            Listas();
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
        [ValidateAntiForgeryToken]
        public ActionResult Create(RequerimientosEntity objRequerimiento)
        {
            var listPersonas = objPersonaLogic.Listar();
            objRequerimiento.IdPersona = listPersonas.Where(m => m.CiRif.Equals(objRequerimiento.Nombres)).Select(m=>m.IdPersona).SingleOrDefault();
            objRequerimiento.IdEstatus = 61;
            if (!User.IsInRole("Cliente"))
            {
                objRequerimiento.IdEstatus = 62;
            }
            try
            {
                if (ModelState.IsValid)
                {
                    objRequerimientoLogic.Insertar(objRequerimiento);
                    MensajeErrorRegistrar(objRequerimiento);
                }

                return RedirectToAction("Index");
            }
            catch
            {
                Listas();
                return View(objRequerimiento);
            }
        }

        [HttpGet]
        public ActionResult Asignar(int id)
        {
            var list = objGrupoDetalleLogic.Listar();
            var requerimiento = objRequerimientoLogic.Listar().Where(m=>m.IdRequerimiento.Equals(id)).SingleOrDefault();
            Listas();
            //Lista Tecnico
            var _departamentos = list.Where(m => m.IdPadre.Equals(36)).ToList();
            SelectList listDepartamentos = new SelectList(_departamentos, "IdGrupoDetalle", "Titulo");
            ViewBag.Departamentos = listDepartamentos;
            return View(requerimiento);
        }

        [HttpPost]
        public ActionResult Asignar(RequerimientoViewEntity objRequerimiento)
        {
            return View();
        }

        public ActionResult Bitacora()
        {
            var bitacora = objBitacora.Listar();
            ViewBag.Mensajes = bitacora.Where(m => m.IdRequerimiento.Equals(1)).Count();
            return View(bitacora);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Bitacora(BitacorasEntity ObjBitacora)
        {
            return View();
        }


        private void Listas()
        {
            var list = objGrupoDetalleLogic.Listar();
            //var lis = objUsuario
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
            ViewBag.Estatus = listEstatus;
            //Lista Tecnicos
            #endregion

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
        public void MensajeErrorRegistrar(RequerimientosEntity objRequerimiento)
        {
            switch (objRequerimiento.Mensaje)
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
                    ViewBag.MensajeError = "Categoria [" + objRequerimiento.IdRequerimiento + "] ya esta Registrada en el Sistema";
                    break;
                case 99://carrera registrada con exito
                    ViewBag.MensajeExito = "Categoria [" + objRequerimiento.IdRequerimiento + "] fue Registrado en el Sistema";
                    break;
                case 98://carrera registrada con exito
                    ViewBag.MensajeExito = "Categoria [" + objRequerimiento.IdRequerimiento + "] Ya existe";
                    break;
            }
        }
        public void MensajeInicioActualizar()
        {
            ViewBag.MensajeInicio = "Ingrese Datos De la Categoria y Click en Guardar";
        }
        public void MensajeErrorActualizar(RequerimientosEntity objRequerimiento)
        {
            switch (objRequerimiento.Mensaje)
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
                    ViewBag.MensajeExito = "Datos de la Categoria [" + objRequerimiento.IdRequerimiento + "] Fueron Actualizados";
                    break;
            }
        }
        public void MensajeInicialEliminar()
        {
            ViewBag.MensajeInicialEliminar = "Formulario de Eliminacion";
        }
        public void MostrarMensajeEliminar(RequerimientosEntity objRequerimiento)
        {

            switch (objRequerimiento.Mensaje)
            {
                case 1000://campo codigo vacio
                    ViewBag.MensajeError = "Error!!! Revise la instruccion de Eliminar";
                    break;
                case 1: //ERROR DE EXISTENCIA
                    ViewBag.MensajeError = "Categoria [" + objRequerimiento.IdRequerimiento + "] No Esta Registrado en el Sistema ";
                    break;

                case 33://CLIENTE NO EXISTE
                    ViewBag.MensajeError = "Categoria: [" + objRequerimiento.IdRequerimiento + "]Ya Fue Eliminada";
                    break;
                case 34:
                    ViewBag.MensajeError = "No se Puede Eliminar la Categoria [" + objRequerimiento.IdRequerimiento + "] Tiene  Productos asignadoss!!!";
                    break;
                case 99: //EXITO
                    ViewBag.MensajeExito = "Categoria [" + objRequerimiento.IdRequerimiento + "] Fue Eliminado!!!";
                    break;

                default:
                    ViewBag.MensajeError = "===???===";
                    break;
            }
        }
        public void MensajeErrorServidor(RequerimientosEntity objRequerimiento)
        {
            switch (objRequerimiento.Mensaje)
            {
                case 1000:
                    ViewBag.MensajeError = "ERROR DE SERVIDOR DE SQL SERVER";
                    break;
            }
        }
        #endregion
    }
}
