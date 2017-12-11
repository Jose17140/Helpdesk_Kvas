using HelpDesk_Kvas.DataGrid;
using KvasEntity;
using KvasLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace HelpDesk_Kvas.Controllers
{
    public class ProductoController : Controller
    {
        GrupoDetalleLogic objGrupoDetalleLogic;
        GrupoLogic objGrupoLogic;
        ProductoLogic objProductoLogic;
        public ProductoController()
        {
            objGrupoDetalleLogic = new GrupoDetalleLogic();
            objGrupoLogic = new GrupoLogic();
            objProductoLogic = new ProductoLogic();
        }

        // GET: Persona
        public ActionResult Index(string filter = null, int page = 1, int pageSize = 15, string sort = "IdGrupoDetalle", string sortdir = "DESC")
        {
            //var id = 1;
            
            var records = new PagedList<ProductosEntityView>();
            ViewBag.filter = filter;
            var productosList = objProductoLogic.Listar();

            records.Content = productosList.Where(m => filter == null 
                                || (m.Titulo.ToUpper().Contains(filter.ToUpper()))
                                || (m.Descripcion.ToUpper().Contains(filter.ToUpper())) 
                                //|| (m.Fabricante.ToUpper().Contains(filter.ToUpper()))
                                //|| (m.Padre.ToUpper().Contains(filter.ToUpper()))
                                )
                                //.OrderBy(sort + " " + sortdir)
                                .Skip((page - 1) * pageSize)
                                .Take(pageSize).ToList();

            records.TotalRecords = productosList.Where(m => filter == null
                                || (m.Titulo.ToUpper().Contains(filter.ToUpper()))
                                || (m.Descripcion.ToUpper().Contains(filter.ToUpper()))
                                //|| (m.Fabricante.ToUpper().Contains(filter.ToUpper()))
                                //|| (m.Padre.ToUpper().Contains(filter.ToUpper()))
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
            var _producto = objProductoLogic.Buscar(id);
            if (_producto == null)
            {
                return HttpNotFound();
            }
            return PartialView("Details", _producto);
        }

        // GET: Persona/Create
        public ActionResult Create()
        {
            MensajeInicioRegistrar();
            ViewBag.Grupo = 9;
            ViewBag.Url = "*";
            ViewBag.Orden = 0;
            var _departamentoPadre = objGrupoDetalleLogic.Listar();
            var _departamentoHijo = _departamentoPadre.Where(m => m.IdGrupo == 5 && m.IdPadre == 38).ToList();
            var _fabricantes = _departamentoPadre.Where(m => m.IdGrupo == 12 && m.IdPadre == 0).ToList();
            var _unidades = _departamentoPadre.Where(m => m.IdGrupo == 19 && m.IdPadre == 0).ToList();
            //Departamento padre
            SelectList listaDepartamento = new SelectList(_departamentoHijo, "IdGrupoDetalle", "Titulo");
            //Departamento hijo
            SelectList listaFabricantes = new SelectList(_fabricantes, "IdGrupoDetalle", "Titulo");
            //Unidades 
            SelectList listaUnidades = new SelectList(_unidades, "IdGrupoDetalle", "Titulo");
            ViewBag.ListaDepartamento = listaDepartamento;
            ViewBag.ListaHijo = listaFabricantes;
            ViewBag.ListaUnidades = listaUnidades;
            return PartialView("Create");
        }

        //// POST: Persona/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProductosEntity producto)
        {
            if (ModelState.IsValid)
            {
                MensajeInicioRegistrar();
                objProductoLogic.Insertar(producto);
                MensajeErrorRegistrar(producto);
                return Json(new { success = true });
            }
            return Json(producto, JsonRequestBehavior.AllowGet);
        }

        //// GET: Persona/Edit/5
        public ActionResult Edit(int id)
        {
            if (id == Convert.ToInt32(null))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var _producto = objProductoLogic.Buscar(id);
            MensajeInicioRegistrar();
            ViewBag.Id = id;
            ViewBag.Grupo = 9;
            ViewBag.Url = "*";
            ViewBag.Orden = 0;
            var _departamentoPadre = objGrupoDetalleLogic.Listar();
            var _departamentoHijo = _departamentoPadre.Where(m => m.IdGrupo == 5 && m.IdPadre == 38).ToList();
            var _fabricantes = _departamentoPadre.Where(m => m.IdGrupo == 12 && m.IdPadre == 0).ToList();
            var _unidades = _departamentoPadre.Where(m => m.IdGrupo == 19 && m.IdPadre == 0).ToList();
            //Departamento padre
            SelectList listaDepartamento = new SelectList(_departamentoHijo, "IdGrupoDetalle", "Titulo");
            //Departamento hijo
            SelectList listaFabricantes = new SelectList(_fabricantes, "IdGrupoDetalle", "Titulo");
            //Unidades 
            SelectList listaUnidades = new SelectList(_unidades, "IdGrupoDetalle", "Titulo");
            ViewBag.ListaDepartamento = listaDepartamento;
            ViewBag.ListaHijo = listaFabricantes;
            ViewBag.ListaUnidades = listaUnidades;
            if (_producto == null)
            {
                return HttpNotFound();
            }
            return PartialView("Edit", _producto);
        }

        //// POST: Persona/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ProductosEntity producto)
        {
            if (ModelState.IsValid)
            {
                MensajeInicioActualizar();
                objProductoLogic.Actualizar(producto);
                MensajeErrorActualizar(producto);
                return Json(new { success = true });
            }
            return Json(producto, JsonRequestBehavior.AllowGet);
        }

        //// GET: Persona/Delete/5
        public ActionResult Delete(int id)
        {
            var _producto = objProductoLogic.Buscar(id);
            MensajeInicioRegistrar();
            ViewBag.Id = id;
            ViewBag.Grupo = 9;
            ViewBag.Url = "*";
            ViewBag.Orden = 0;
            var _departamentoPadre = objGrupoDetalleLogic.Listar();
            var _departamentoHijo = _departamentoPadre.Where(m => m.IdGrupo == 18 && m.IdPadre == 38).ToList();
            var _fabricantes = _departamentoPadre.Where(m => m.IdGrupo == 12 && m.IdPadre == 0).ToList();
            var _unidades = _departamentoPadre.Where(m => m.IdGrupo == 23 && m.IdPadre == 0).ToList();
            //Departamento padre
            SelectList listaDepartamento = new SelectList(_departamentoHijo, "IdGrupoDetalle", "Titulo");
            //Departamento hijo
            SelectList listaFabricantes = new SelectList(_fabricantes, "IdGrupoDetalle", "Titulo");
            //Unidades 
            SelectList listaUnidades = new SelectList(_unidades, "IdGrupoDetalle", "Titulo");
            ViewBag.ListaDepartamento = listaDepartamento;
            ViewBag.ListaHijo = listaFabricantes;
            ViewBag.ListaUnidades = listaUnidades;
            return PartialView("Delete", _producto);
        }

        // POST: Persona/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(ProductosEntity producto)
        {
            try
            {
                MensajeInicialEliminar();
                objProductoLogic.Eliminar(producto);
                MensajeErrorEliminar(producto);
                return Json(new { success = true });
            }
            catch
            {
                return Json(producto, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult MovimientoInventario()
        {
            return View();
        }

        public ActionResult SeleccionarProducto()
        {
            return View();
        }

        #region
        public void MensajeInicioRegistrar()
        {
            ViewBag.MensajeInicio = "Ingrese datos del Producto y Click en Guardar";
        }
        public void MensajeErrorRegistrar(ProductosEntity objProducto)
        {
            switch (objProducto.Mensaje)
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
                    ViewBag.MensajeError = "Ingrese Nombre del Producto";
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
                    ViewBag.MensajeError = "Categoria [" + objProducto.IdGrupoDetalle + "] ya esta Registrada en el Sistema";
                    break;
                case 99://carrera registrada con exito
                    ViewBag.MensajeExito = "Categoria [" + objProducto.IdGrupoDetalle + "] fue Registrado en el Sistema";
                    break;
                case 98://carrera registrada con exito
                    ViewBag.MensajeExito = "Categoria [" + objProducto.IdGrupoDetalle + "] Ya existe";
                    break;
            }
        }
        public void MensajeInicioActualizar()
        {
            ViewBag.MensajeInicio = "Ingrese Datos De la Categoria y Click en Guardar";
        }
        public void MensajeErrorActualizar(ProductosEntity objProducto)
        {
            switch (objProducto.Mensaje)
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
                    ViewBag.MensajeExito = "Datos de la Categoria [" + objProducto.IdGrupoDetalle + "] Fueron Actualizados";
                    break;
            }
        }
        public void MensajeInicialEliminar()
        {
            ViewBag.MensajeInicialEliminar = "Formulario de Eliminacion";
        }
        public void MensajeErrorEliminar(ProductosEntity objProducto)
        {

            switch (objProducto.Mensaje)
            {
                case 1000://campo codigo vacio
                    ViewBag.MensajeError = "Error!!! Revise la instruccion de Eliminar";
                    break;
                case 1: //ERROR DE EXISTENCIA
                    ViewBag.MensajeError = "Categoria [" + objProducto.IdGrupoDetalle + "] No Esta Registrado en el Sistema ";
                    break;

                case 33://CLIENTE NO EXISTE
                    ViewBag.MensajeError = "Categoria: [" + objProducto.Titulo + "]Ya Fue Eliminada";
                    break;
                case 34:
                    ViewBag.MensajeError = "No se Puede Eliminar la Categoria [" + objProducto.Titulo + "] Tiene  Productos asignadoss!!!";
                    break;
                case 99: //EXITO
                    ViewBag.MensajeExito = "Categoria [" + objProducto.Titulo + "] Fue Eliminado!!!";
                    break;

                default:
                    ViewBag.MensajeError = "===???===";
                    break;
            }
        }
        public void MensajeErrorServidor(ProductosEntity objProducto)
        {
            switch (objProducto.Mensaje)
            {
                case 1000:
                    ViewBag.MensajeError = "ERROR DE SERVIDOR DE SQL SERVER";
                    break;
            }
        }
        #endregion
    }
}
