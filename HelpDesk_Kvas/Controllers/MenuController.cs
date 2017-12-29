using HelpDesk_Kvas.DataGrid;
using HelpDesk_Kvas.Models;
using HelpDesk_Kvas.Models.Datos.Logica;
using HelpDesk_Kvas.Models.Datos.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HelpDesk_Kvas.Controllers
{
    public class MenuController : Controller
    {
        private DAL_Main db = new DAL_Main();
        GrupoDetalleLogic objGrupoDetalleLogic;
        GrupoLogic objGrupoLogic;
        MenuLogic objMenu;
        public MenuController()
        {
            objGrupoDetalleLogic = new GrupoDetalleLogic();
            objGrupoLogic = new GrupoLogic();
            objMenu = new MenuLogic();
        }

        public ActionResult Index(int? Nv2, int? Nv3, string filter = null, int page = 1, int pageSize = 15, string sort = "IdGrupoDetalle")
        {
            int id = 1;
            ViewBag.Id = id;
            var lista = new PagedList<GruposDetallesView>();
            var grupos = objGrupoLogic.Buscar(id);
            var _grupo = objMenu.Listar();
            var l = _grupo.Select(m => m.IdGrupo);
            ViewBag.Nombre = grupos.Titulo;
            lista.Content = _grupo.Where(m => m.IdGrupo == id).ToList();
            //PROGRAMAR FILTRO DE 3 NIVELES EN LA RECURSIVIDAD, ID PARA AGREGAR HIJOS Y VALIDAD
            if (Nv2 != null)
            {
                var s = objGrupoDetalleLogic.Buscar(Nv2.Value);
                var k = s.Titulo;
                ViewBag.SelectPadre = k;
                ViewBag.Nv2 = Nv2.Value;
                lista.Content2 = _grupo.Where(m => m.IdPadre == Nv2).ToList();
                //var e = _grupo.Where(m => m.IdPadre == Nv2).SingleOrDefault();
                //ViewBag.Padre = e.Padre;
            }
            if (Nv3 != null)
            {
                ViewBag.Nv3 = Nv3.Value;
                lista.Content3 = _grupo.Where(m => m.IdPadre == Nv3).ToList();
            }
            //var grupos = objGrupoLogic.Listar();

            lista.CurrentPage = page;
            lista.PageSize = pageSize;
            return View(lista);

        }

        public ActionResult Create()
        {
            return View();
        }

        public ActionResult Edit()
        {
            return View();
        }

        public ActionResult Delete()
        {
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
    }
}
