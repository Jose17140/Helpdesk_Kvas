using HelpDesk_Kvas.Models.Datos.DAL;
using HelpDesk_Kvas.Models.Datos.Entity;
using HelpDesk_Kvas.Models.Datos.Logica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;

namespace HelpDesk_Kvas.Controllers
{
    [Authorize]
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
        dbDataContext db;
        PresupuestoDAL objPresupuestoDAL;

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
            objPresupuestoDAL = new PresupuestoDAL();
            db = new dbDataContext(); 
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
        
        /// <summary>
        /// PRESUPUESTO GENERADO EN LA VISTA DETALLE, NO EDITABLE
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult PxR(int id)
        {
            var list = objPresupuestoLogic.Listar();
            var pxr = list.Where(m => m.IdRequerimiento.Equals(id)).ToList();
            var iva = pxr.Sum(m => m.Iva);
            var total = pxr.Sum(m => m.Subtotal);
            ViewBag.Iva = iva;
            ViewBag.Total = total;
            ViewBag.TotalPagar = iva + total;
            var datos = pxr.Where(m => m.IdRequerimiento.Equals(id)).FirstOrDefault();
            ViewBag.Emision = datos.FechaEmision;
            ViewBag.Vencimiento = datos.FechaVencimiento;
            ViewBag.IdPre = datos.IdRequerimiento;
            var ven = datos.IdEmpleado;
            var empl = objUsuario.Listar().Where(m => m.IdUsuario.Equals(ven)).SingleOrDefault();
            ViewBag.Emppleado = empl.Nombres;
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
            var mensaje = "Registro Exitoso";
            if (ListadoDetalle.Select(m => m.Cantidad == 0).FirstOrDefault())
            {
                mensaje = "Error";
                return Json(mensaje);
            }
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
                    //return RedirectToAction("Index");
                    var Id = Convert.ToInt32(IdRequerimiento);
                    var q = db.Requerimientos.Where(m => m.IdRequerimiento.Equals(Id)).SingleOrDefault();
                    q.Presupuestado = Convert.ToBoolean(1);
                    db.SubmitChanges();
                    var Idquere = Convert.ToInt32(IdRequerimiento);
                    RouteValueDictionary ruta = new RouteValueDictionary();
                    ruta.Add("Id", Idquere);

                    //return RedirectToAction("Confirmar", "Account", new { dato = _user });
                    return RedirectToAction("Details", "Requerimiento", ruta);
                    //mensaje = "Registro Exitoso";
                    //return Json(mensaje);
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
            var lista = objPresupuestoDAL.ListarDetalle();
            var detalle = lista.Where(m => m.IdRequerimiento.Equals(id)).ToList();
            var d = detalle.ToList().FirstOrDefault();
            ViewBag.IdOrden = d.IdRequerimiento;
            ViewBag.IdPresupuesto = d.IdPresupuesto;
            ViewBag.FechaEmision = d.FechaEmision.Date;
            ViewBag.FechaVencimiento = d.FechaVencimiento.Date;
            ViewBag.Cliente = d.NombreCliente;
            ViewBag.Ci = d.Cedula;
            ViewBag.Telefono = d.Telefono;
            ViewBag.Direccion = d.Direccion;
            ViewBag.Correo = d.Email;
            ViewBag.Empleado = d.NombreEmpleado;
            var iva = detalle.Sum(m => m.Iva);
            ViewBag.Iva = iva;
            var subtotal = detalle.Sum(m => m.SubTotal);
            ViewBag.Subtotal = subtotal;
            ViewBag.TotalPagar = iva + subtotal;
            return View(detalle);
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


        public ActionResult Imprimir(int id)
        {
            var lista = objPresupuestoDAL.ListarDetalle();
            var detalle = lista.Where(m => m.IdRequerimiento.Equals(id)).ToList();
            var d = detalle.ToList().FirstOrDefault();
            ViewBag.IdOrden = d.IdPresupuesto;
            ViewBag.IdPresupuesto = d.IdPresupuesto;
            ViewBag.FechaEmision = d.FechaEmision.Date;
            ViewBag.FechaVencimiento = d.FechaVencimiento.Date;
            ViewBag.Cliente = d.NombreCliente;
            ViewBag.Ci = d.Cedula;
            ViewBag.Telefono = d.Telefono;
            ViewBag.Direccion = d.Direccion;
            ViewBag.Correo = d.Email;
            ViewBag.Empleado = d.NombreEmpleado;
            var iva = detalle.Sum(m => m.Iva);
            ViewBag.Iva = iva;
            var subtotal = detalle.Sum(m => m.SubTotal);
            ViewBag.Subtotal = subtotal;
            ViewBag.TotalPagar = iva + subtotal;
            return View(detalle);
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
