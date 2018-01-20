using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HelpDesk_Kvas.Models.Datos.Entity
{
    /// <summary>
    /// ENTIDAD DEL OBJETO PRESUPUESTO
    /// </summary>
    public class PresupuestosEntity : RequerimientosEntity
    {
        public int IdPresupuesto { get; set; }

        //public int IdRequerimiento { get; set; }

        //public DateTime FechaEmision { get; set; }

        //public DateTime FechaVencimiento { get; set; }

        public int IdPoS { get; set; }

        public int Cantidad { get; set; }

        public decimal PrecioUnitario { get; set; }

        //public decimal Subtotal { get; set; }

        public decimal Iva { get; set; }
    }

    #region
    public class PresupuestoViewModel : PresupuestosEntity
    {
        #region CABECERA DEL PRESUPUESTO
        //public int IdRequerimiento { get; set; }
        //public int IdPoS { get; set; }
        public string NombreProducto { get; set; }
        public string Descripcion { get; set; }
        public string Sku { get; set; }
        //public int Cantidad { get; set; }
        //public int PrecioUnitario { get; set; }

        #endregion
    }
    #endregion
}