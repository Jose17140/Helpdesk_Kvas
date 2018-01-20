using HelpDesk_Kvas.Models.Datos.Logica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HelpDesk_Kvas.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        PersonasLogic objPersona;
        RequerimientoLogic objRequerimiento;
        ProductoLogic objProducto;
        public HomeController()
        {
            objPersona = new PersonasLogic();
            objRequerimiento = new RequerimientoLogic();
            objProducto = new ProductoLogic();
        }
        [Authorize(Roles="Master")]
        public ActionResult Index()
        {
            if (User.IsInRole("Cliente"))
            {
                RedirectToAction("Index", "Requerimiento");
            }
            ViewBag.ContarPersonas = objPersona.Listar().Count();
            ViewBag.ContarRequerimientos = objRequerimiento.Listar().Count();
            ViewBag.ContarProductos = objProducto.Listar().Where(m => m.IdGrupo.Equals(16)).Count();
            ViewBag.ContarServicios = objProducto.Listar().Where(m => m.IdGrupo.Equals(17)).Count();
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}