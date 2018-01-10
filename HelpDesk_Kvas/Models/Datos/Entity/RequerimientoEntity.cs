using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HelpDesk_Kvas.Models.Datos.Entity
{
    public class RequerimientoEntity
    {
        public int IdRequerimiento { get; set; }

        public int IdCliente { get; set; }

        public int IdEquipo { get; set; }

        public int IdMarca { get; set; }

        public int MyProperty { get; set; }
    }
}