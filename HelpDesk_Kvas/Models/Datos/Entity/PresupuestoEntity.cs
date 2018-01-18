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
        public int CantidadProducto { get; set; }
        public int PrecioProducto { get; set; }
        #endregion
        #region CONTENIDO PRESUPUESTO
        public List<PresupuestoDetalleViewModel> PresupuestoDetalle { get; set; }
        #endregion
        #region CALCULOS EN PRESUPUESTO
        public decimal SubTotalPresupuesto()
        {
            return PresupuestoDetalle.Sum(m => m.Subtotal());
        }
        public decimal CalculoIva()
        {
            var suma = PresupuestoDetalle.Sum(m => m.Subtotal());
            var iva = 12;
            return suma*(iva/100);
        }
        public decimal TotalPresupuesto()
        {
            var suma = PresupuestoDetalle.Sum(m => m.Subtotal());
            var iva = suma*(12 / 100);
            return suma + iva;
        }
        #endregion

        public PresupuestoViewModel()
        {
            PresupuestoDetalle = new List<PresupuestoDetalleViewModel>();
            Refrescar();
        }

        public void Refrescar()
        {
            IdProducto = 0;
            NombreProducto = null;
            CantidadProducto = 1;
            PrecioProducto = 0;
        }

        public bool SeAgregoUnProductoValido()
        {
            return !(IdProducto == 0 || string.IsNullOrEmpty(NombreProducto) || CantidadProducto == 0 || PrecioProducto == 0);
        }

        public bool ExisteEnDetalle(int IdProducto)
        {
            return PresupuestoDetalle.Any(m => m.IdPoS == IdProducto);
        }

        public void RetirarItemDeDetalle()
        {
            if (PresupuestoDetalle.Count > 0)
            {
                var detalleARetirar = PresupuestoDetalle.Where(x => x.Retirar)
                                                        .SingleOrDefault();

                PresupuestoDetalle.Remove(detalleARetirar);
            }
        }

        public void AgregarItemADetalle()
        {
            PresupuestoDetalle.Add(new PresupuestoDetalleViewModel
            {
                IdPoS = IdProducto,
                ProductoNombre = NombreProducto,
                PrecioUnitario = CantidadProducto,
                Cantidad = PrecioProducto,
            });

            Refrescar();
        }

        //public Comprobante ToModel()
        //{
        //    var comprobante = new Comprobante();
        //    comprobante.Cliente = this.Cliente;
        //    comprobante.Creado = DateTime.Now;
        //    comprobante.Total = this.Total();

        //    foreach (var d in ComprobanteDetalle)
        //    {
        //        comprobante.ComprobanteDetalle.Add(new ComprobanteDetalle
        //        {
        //            ProductoId = d.ProductoId,
        //            Monto = d.Monto(),
        //            PrecioUnitario = d.PrecioUnitario,
        //            Cantidad = d.Cantidad
        //        });
        //    }

        //    return comprobante;
        //}
    }
    #endregion
}