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
            ViewBag.Cedula = (_persona, _grupoDetalle);
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
            return View();
        }

        // POST: Persona/Create
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

        // GET: Persona/Edit/5
        public ActionResult Edit(int id)
        {
            //if (id == Convert.ToInt32(null))
            //{
            //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            //}
            //if (_grupo == null)
            //{
            //    return HttpNotFound();
            //}
            return View();
        }

        // POST: Persona/Edit/5
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

        // GET: Persona/Delete/5
        public ActionResult Delete(int id)
        {
            //if (id == Convert.ToInt32(null))
            //{
            //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            //}
            //if (_grupo == null)
            //{
            //    return HttpNotFound();
            //}
            return View();
        }

        // POST: Persona/Delete/5
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
