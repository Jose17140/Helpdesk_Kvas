using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HelpDesk_Kvas.Models.Datos.Entity
{
    /// <summary>
    /// ENTIDAD DEL OBJETO
    /// </summary>
    public class PresupuestoEntity : RequerimientosEntity
    {
        public int IdPresupuesto { get; set; }

        //public int IdRequerimiento { get; set; }

        //public DateTime FechaEmision { get; set; }

        //public DateTime FechaVencimiento { get; set; }

        public int IdPoS { get; set; }

        public int Cantidad { get; set; }

        public decimal PrecioUnitario { get; set; }

        //public decimal Subtotal { get; set; }

        public int Iva { get; set; }
    }

    #region ViewModels
    public partial class PresupuestoDetalleViewModel : PresupuestoEntity
    {
        //public PresupuestoDetalleViewModel()
        //{
        //    Productos = new List<PresupuestoDetalleViewModel>();
        //}
        //public int IdPoS { get; set; }
        public string ProductoNombre { get; set; }

        //public int Cantidad { get; set; }

        //public decimal PrecioUnitario { get; set; }

        public bool Retirar { get; set; }

        public decimal Subtotal()
        {
            return Cantidad * PrecioUnitario;
        }

        //public List<ProductosEntity> Productos { get; set; }
    }
    #endregion

    #region
    public class PresupuestoViewModel
    {
        #region CABECERA DEL PRESUPUESTO
        public int IdRequerimiento { get; set; }
        public int IdProducto { get; set; }
        public string NombreProducto { get; set; }
        public string Descripcion { get; set; }
        public string Sku { get; set; }
        public int CantidadProducto { get; set; }
        public int PrecioProducto { get; set; }
        public int Iva { get; set; }
        #endregion
    }
    #endregion
}