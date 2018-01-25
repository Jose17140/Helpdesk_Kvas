using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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

    public class PresupuestoDetalleEntity
    {
        public int IdRequerimiento { get; set; }
        public int IdPresupuesto { get; set; }
        public DateTime FechaEmision { get; set; }
        public DateTime FechaVencimiento { get; set; }
        public int IdEmpleado { get; set; }
        public string NombreEmpleado { get; set; }
        public string NombreCliente { get; set; }
        public string Cedula { get; set; }
        public string Telefono { get; set; }
        public string Direccion { get; set; }
        public string Email { get; set; }
        public int IdPoS { get; set; }
        public string Sku { get; set; }
        public string NombreProducto { get; set; }
        public string Descripcion { get; set; }
        public int Cantidad { get; set; }
        public int IdEstatus { get; set; }
        public decimal PUnitario { get; set; }
        public decimal SubTotal { get; set; }
        public decimal Iva { get; set; }
        public decimal TotalPagar { get  { return SubTotal + Iva; } }
    }

    public class AsignadoEntity
    {
        public int IdRequerimiento { get; set; }

        [Required]
        [Display(Name = "Técnico:")]
        public int IdTecnico { get; set; }

        [Display(Name = "Atendido:")]
        public bool Atendido { get; set; }
    }
}