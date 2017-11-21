using HelpDesk_Kvas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Helpdesk_Kvas.Controllers
{
    public class MenuController : Controller
    {
        //private GruposDetalleLogic objDetalleLogic;
        //private MenuLogic objMenuLogic;
        private DAL_Main db = new DAL_Main();

        public MenuController()
        {
            //objDetalleLogic = new GruposDetalleLogic();
            //objMenuLogic = new MenuLogic();
        }
        // GET: Menu
        public ActionResult Index()
        {
           //MenuEntity objDetalleEntity = new MenuEntity();
           //IEnumerable<GruposDetallesEntity> lista = objMenuLogic.Listar();
           

            return View();
        }

        [ChildActionOnly]
        public ActionResult _SideBart()
        {
            return View();
        }

        [ChildActionOnly]
        public ActionResult _SideBarb()
        {
            var lista = (from m in db.GruposDetalles
                         where m.Estatus == true && (m.IdGrupo == 1 && m.IdPadre == 0)
                         orderby m.Orden ascending
                         select m).ToList();
            return View(lista);
        }

        [ChildActionOnly]
        public ActionResult _TopBar()
        {
            return View();
        }

        [ChildActionOnly]
        public ActionResult _UserPanel()
        {
            return PartialView();
        }

        // GET: Menu/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Menu/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Menu/Create
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

        // GET: Menu/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Menu/Edit/5
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

        // GET: Menu/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Menu/Delete/5
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
