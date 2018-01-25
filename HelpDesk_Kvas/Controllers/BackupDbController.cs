using HelpDesk_Kvas.Models.Datos.DAL;
using HelpDesk_Kvas.Models.Datos.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HelpDesk_Kvas.Controllers
{
    public class BackupDbController : Controller
    {
        dbDataContext db = new dbDataContext();
        // GET: BackupDb
        public ActionResult Index()
        {
            return View();
        }

        // GET: BackupDb/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: BackupDb/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BackupDb/Create
        [HttpPost]
        public ActionResult Create(BackupDbEntity backup)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.sp_Backup(backup.Nombre);
                }
                return RedirectToAction("Create");
            }
            catch
            {
                return View();
            }
        }
    }
}
