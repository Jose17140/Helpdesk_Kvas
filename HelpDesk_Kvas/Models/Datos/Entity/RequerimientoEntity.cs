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

        public int IdModelo { get; set; }

        public string Serial { get; set; }

        public string Falla { get; set; }

        public int IdDeposito { get; set; }

        public string Accesorio { get; set; }

        public int? IdTecnico { get; set; }

        public int Estatus { get; set; }
    }

    //public class 
}