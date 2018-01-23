using HelpDesk_Kvas.Models.Datos.Entity;
using HelpDesk_Kvas.Models.Datos.Logica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HelpDesk_Kvas.Controllers
{
    public class PresupuestoController : Controller
    {
        GrupoDetalleLogic objGrupoDetalleLogic;
        GrupoLogic objGrupoLogic;
        RequerimientoLogic objRequerimientoLogic;
        PresupuestoLogic objPresupuestoLogic;
        ProductoLogic objProducto;
        UsuarioLogic objUsuario;
        PersonasLogic objPersonaLogic;
        BitacoraLogic objBitacora;

        public PresupuestoController()
        {
            objGrupoDetalleLogic = new GrupoDetalleLogic();
            objGrupoLogic = new GrupoLogic();
            objRequerimientoLogic = new RequerimientoLogic();
            objUsuario = new UsuarioLogic();
            objPersonaLogic = new PersonasLogic();
            objBitacora = new BitacoraLogic();
            objProducto = new ProductoLogic();
            objPresupuestoLogic = new PresupuestoLogic();
        }

        // GET: Presupuesto
        public ActionResult Index()
        {
            return View();
        }

        // GET: Presupuesto/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }
        
        public ActionResult PxR(int id)
        {
            var list = objPresupuestoLogic.Listar();
            var pxr = list.Where(m => m.IdRequerimiento.Equals(id)).ToList();
            var iva = pxr.Sum(m => m.Iva);
            var total = pxr.Sum(m => m.Subtotal);
            ViewBag.Iva = iva;
            ViewBag.Total = total;
            ViewBag.TotalPagar = iva + total;
            return View(pxr);
        }

        [HttpPost]
        public ActionResult PxR(PresupuestosEntity objPresupuesto)
        {
            return View();
        }

        public JsonResult BuscarProducto(string _nombre)
        {
            var list = objProducto.BuscarNombre(_nombre);
            return Json(list, JsonRequestBehavior.AllowGet);
        }

        // GET: Presupuesto/Create
        public ActionResult Create(int id)
        {
            ViewBag.IdRequerimiento = id;
            return View();
        }
        
        // POST: Presupuesto/Create
        [HttpPost]
        public ActionResult Create(string IdRequerimiento, List<PresupuestosEntity> ListadoDetalle)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    
                    var user = HttpContext.User.Identity.Name;
                    var u = objUsuario.Buscar_x_Nombre(user);
                    ViewBag.IdUsuario = u.IdUsuario;
                    foreach (var i in ListadoDetalle)
                    {
                        i.IdEstatus = 148;
                        i.IdEmpleado = u.IdUsuario;
                        i.IdRequerimiento = Convert.ToInt32(IdRequerimiento);
                        objPresupuestoLogic.Insertar(i);
                    }
                    return RedirectToAction("Index");
                }
                catch
                {
                    return View();
                }
            }
            return View();
        }

        // GET: Presupuesto/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Presupuesto/Edit/5
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

        // GET: Presupuesto/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Presupuesto/Delete/5
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
    }
}
