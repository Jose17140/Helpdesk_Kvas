using HelpDesk_Kvas.DataGrid;
using HelpDesk_Kvas.Models;
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
        DAL_Main db;

        public RequerimientoController()
        {
            objGrupoDetalleLogic = new GrupoDetalleLogic();
            objGrupoLogic = new GrupoLogic();
            objRequerimientoLogic = new RequerimientoLogic();
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

        // GET: Requerimiento/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Requerimiento/Create
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
    }
}
