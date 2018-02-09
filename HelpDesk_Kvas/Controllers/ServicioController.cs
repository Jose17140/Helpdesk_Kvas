﻿using HelpDesk_Kvas.DataGrid;
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
    [Authorize]
    public class ServicioController : Controller
    {
        GrupoDetalleLogic objGrupoDetalleLogic;
        GrupoLogic objGrupoLogic;
        ProductoLogic objProductoLogic;
        public ServicioController()
        {
            objGrupoDetalleLogic = new GrupoDetalleLogic();
            objGrupoLogic = new GrupoLogic();
            objProductoLogic = new ProductoLogic();
        }

        // GET: Persona
        public ActionResult Index(string filter = null, int page = 1, int pageSize = 15, string sort = "IdProducto", string sortdir = "DESC")
        {
            var records = new PagedList<ProductosEntityView>();
            ViewBag.filter = filter;
            var productos = objProductoLogic.Listar();
            var productosList = productos.Where(m => m.IdGrupo == 17).ToList();

            records.Content = productosList.Where(m => filter == null
                                || (m.Nombre.ToUpper().Contains(filter.ToUpper()))
                                || (m.Descripcion.ToUpper().Contains(filter.ToUpper()))
                                || (m.Fabricante.ToUpper().Contains(filter.ToUpper()))
                                || (m.Categoria.ToUpper().Contains(filter.ToUpper()))
                                || (m.Sku.ToUpper().Contains(filter.ToUpper()))
                                )
                                //.OrderBy(sort + " " + sortdir)
                                .Skip((page - 1) * pageSize)
                                .Take(pageSize).ToList();

            records.TotalRecords = productosList.Where(m => filter == null
                                || (m.Nombre.ToUpper().Contains(filter.ToUpper()))
                                || (m.Descripcion.ToUpper().Contains(filter.ToUpper()))
                                || (m.Fabricante.ToUpper().Contains(filter.ToUpper()))
                                || (m.Categoria.ToUpper().Contains(filter.ToUpper()))
                                || (m.Sku.ToUpper().Contains(filter.ToUpper()))
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
            ViewBag.Grupo = 17;
            var _lista = objGrupoDetalleLogic.Listar();
            var _departamentos = _lista.Where(m => m.IdPadre == 36).ToList();
            var _unidades = _lista.Where(m => m.IdGrupo == 22).ToList();
            //Departamento padre
            SelectList listaCategorias = new SelectList(_departamentos, "IdGrupoDetalle", "Titulo");
            //Unidades 
            SelectList listaUnidades = new SelectList(_unidades, "IdGrupoDetalle", "Titulo");
            ViewBag.ListaDepartamento = listaCategorias;
            ViewBag.ListaUnidades = listaUnidades;
            //return View();
            return PartialView("Create");
        }

        //// POST: Persona/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProductosEntity producto)
        {
            producto.IdGrupo = 17;
            producto.IdCondicion = 103;
            if (ModelState.IsValid)
            {
                var isExistSku = objProductoLogic.IsSkuExist(producto.Sku);
                if (isExistSku)
                {
                    ModelState.AddModelError("isExistSku", "Codigo SKU ya se encuentra registrado");
                    var _lista = objGrupoDetalleLogic.Listar();
                    var _Categorias = _lista.Where(m => m.IdGrupo == 24).ToList();
                    var _unidades = _lista.Where(m => m.IdGrupo == 22).ToList();
                    //Departamento padre
                    SelectList listaCategorias = new SelectList(_Categorias, "IdGrupoDetalle", "Titulo");
                    //Unidades 
                    SelectList listaUnidades = new SelectList(_unidades, "IdGrupoDetalle", "Titulo");
                    ViewBag.ListaDepartamento = listaCategorias;
                    ViewBag.ListaUnidades = listaUnidades;
                    return View(producto);
                }
                MensajeInicioRegistrar();
                objProductoLogic.Insertar(producto);
                MensajeErrorRegistrar(producto);
                return Json(new { success = true });
            }
            //return Json(producto, JsonRequestBehavior.AllowGet);
            return View(producto);
        }

        //// GET: Persona/Edit/5
        public ActionResult Edit(int id)
        {
            if (id == Convert.ToInt32(null))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var _producto = objProductoLogic.Buscar(id);
            MensajeInicioActualizar();
            ViewBag.Id = id;
            ViewBag.Grupo = 17;
            ViewBag.Url = "*";
            ViewBag.Orden = 0;
            var _departamentoPadre = objGrupoDetalleLogic.Listar();
            var _lista = objGrupoDetalleLogic.Listar();
            var _Categorias = _lista.Where(m => m.IdGrupo == 24).ToList();
            var _unidades = _lista.Where(m => m.IdGrupo == 22).ToList();
            //Departamento padre
            SelectList listaCategorias = new SelectList(_Categorias, "IdGrupoDetalle", "Titulo");
            //Unidades 
            SelectList listaUnidades = new SelectList(_unidades, "IdGrupoDetalle", "Titulo");
            ViewBag.ListaDepartamento = listaCategorias;
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
            producto.IdCondicion = 103;
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
            if (id == Convert.ToInt32(null))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var _producto = objProductoLogic.Buscar(id);
            MensajeInicialEliminar();
            ViewBag.Id = id;
            ViewBag.Grupo = 9;
            ViewBag.Url = "*";
            ViewBag.Orden = 0;
            var _departamentoPadre = objGrupoDetalleLogic.Listar();
            var _lista = objGrupoDetalleLogic.Listar();
            var _Categorias = _lista.Where(m => m.IdGrupo == 24).ToList();
            var _unidades = _lista.Where(m => m.IdGrupo == 22).ToList();
            //Departamento padre
            SelectList listaCategorias = new SelectList(_Categorias, "IdGrupoDetalle", "Titulo");
            //Unidades 
            SelectList listaUnidades = new SelectList(_unidades, "IdGrupoDetalle", "Titulo");
            ViewBag.ListaDepartamento = listaCategorias;
            ViewBag.ListaUnidades = listaUnidades;
            if (_producto == null)
            {
                return HttpNotFound();
            }
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
            ViewBag.MensajeInicio = "Ingrese datos del Servicio y Click en Guardar";
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
                    ViewBag.MensajeError = "Categoria [" + objProducto.IdProducto + "] ya esta Registrada en el Sistema";
                    break;
                case 99://carrera registrada con exito
                    ViewBag.MensajeExito = "Categoria [" + objProducto.IdProducto + "] fue Registrado en el Sistema";
                    break;
                case 98://carrera registrada con exito
                    ViewBag.MensajeExito = "Categoria [" + objProducto.IdProducto + "] Ya existe";
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
                    ViewBag.MensajeExito = "Datos de la Categoria [" + objProducto.IdProducto + "] Fueron Actualizados";
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
                    ViewBag.MensajeError = "Categoria [" + objProducto.IdProducto + "] No Esta Registrado en el Sistema ";
                    break;

                case 33://CLIENTE NO EXISTE
                    ViewBag.MensajeError = "Categoria: [" + objProducto.Nombre + "]Ya Fue Eliminada";
                    break;
                case 34:
                    ViewBag.MensajeError = "No se Puede Eliminar la Categoria [" + objProducto.Nombre + "] Tiene  Productos asignadoss!!!";
                    break;
                case 99: //EXITO
                    ViewBag.MensajeExito = "Categoria [" + objProducto.Nombre + "] Fue Eliminado!!!";
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