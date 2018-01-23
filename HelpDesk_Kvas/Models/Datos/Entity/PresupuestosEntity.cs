using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HelpDesk_Kvas.Models.Datos.Entity
{
    /// <summary>
    /// ENTIDAD DEL OBJETO PRESUPUESTO
    /// </summary>
    public class PresupuestosEntity
    {
        public int IdPresupuesto { get; set; }

        public int IdRequerimiento { get; set; }

        public int IdEmpleado { get; set; }

        public DateTime FechaEmision { get; set; }

        public DateTime FechaVencimiento { get; set; }

        public int IdPoS { get; set; }

        public int Cantidad { get; set; }

        public decimal PrecioUnitario { get; set; }

        public int IdEstatus { get; set; }

        public decimal Subtotal { get; set; }

        public decimal Iva { get; set; }

        public int Mensaje { get; set; }
    }

    #region
    public class PresupuestoViewModel : RequerimientosEntity
    {
        public int IdPresupuesto { get; set; }

        public int IdPoS { get; set; }

        public int Cantidad { get; set; }

        public decimal PrecioUnitario { get; set; }

        public decimal Iva { get; set; }

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

    public class PresupuestoViewEntity :PresupuestosEntity
    {
        public string NombreProducto { get; set; }
        public string Descripcion { get; set; }
        public string Sku { get; set; }
    }
}