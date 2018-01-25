using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HelpDesk_Kvas.Models.Datos.Entity
{
    public class BackupDbEntity
    {
        public int IdBackup { get; set; }
        public string Nombre { get; set; }
        public DateTime Fecha { get; set; }
    }
}