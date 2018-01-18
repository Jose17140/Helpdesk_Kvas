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

        // GET: Presupuesto/Create
        public ActionResult Create()
        {
            return View();
        }

        public JsonResult BuscarProducto(string _nombre)
        {
            var list = objProducto.BuscarNombre(_nombre);
            return Json(list, JsonRequestBehavior.AllowGet);
        }

        // POST: Presupuesto/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
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
