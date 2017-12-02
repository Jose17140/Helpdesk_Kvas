using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KvasEntity
{
    public class ProductosEntity : GruposDetallesEntity
    {
        //[Key]
        //public int IdGrupoDetalle { get; set; }

        //[Required]
        //[StringLength(50)]
        //[Display(Name = "Nombre:")]
        //public string Titulo { get; set; }

        //[Required]
        //[StringLength(100)]
        //[Display(Name = "Descripcion Completa:")]
        //public string Descripcion { get; set; }

        //[Display(Name = "Orden:")]
        //public int Orden { get; set; }

        //[Display(Name = "Entidad:")]
        //public int? IdGrupo { get; set; }

        //[Display(Name = "Categoria Padre:")]
        //public int? IdPadre { get; set; }

        //[StringLength(30)]
        //[Display(Name = "Icono:")]
        //public string Icono { get; set; }

        //[Required]
        //[StringLength(30)]
        //[Display(Name = "Url de la Entidad:")]
        //public string UrlDetalle { get; set; }

        //[Display(Name = "Estatus:")]
        //public bool Estatus { get; set; }

        //[DataType(DataType.DateTime)]
        //[Display(Name = "Fecha de Registro:")]
        //public DateTime FechaRegistro { get; set; }

        //public int Mensaje { get; set; }

        [Required]
        [StringLength(24)]
        [Display(Name = "Codigo del Producto:")]
        public string Sku { get; set; }

        [Display(Name = "Departamento:")]
        public int IdDepartamento { get; set; }

        [Display(Name = "Fabricante:")]
        public int IdFabricante { get; set; }

        [Display(Name = "Inventario:")]
        public int Stock { get; set; }

        [Display(Name = "Unidad:")]
        public int IdUnidad { get; set; }

        [Display(Name = "Inventario Minimo:")]
        public int StockMin { get; set; }

        [Display(Name = "Precio de Compra:")]
        public decimal PrecioCompra { get; set; }

        [Display(Name = "Precio de Venta:")]
        public decimal PrecioVenta { get; set; }

        [Display(Name = "Dias de Garantia:")]
        public int Garantia { get; set; }
    }

    //public class ProductosEntity
    //{
    //    public int IdProducto { get; set; }
    //    public string Sku { get; set; }
    //    public int IdCategoria { get; set; }
    //    public int IdFabricante { get; set; }
    //    public int Stock { get; set; }
    //    public int Stock_Min { get; set; }
    //    public decimal Precio { get; set; }
    //    public int Garantia { get; set; }
    //    public bool Estatus { get; set; }
    //    public int Mensaje { get; set; }
    //}

    //public class ProductoDetalleEntity
    //{
    //    public int IdProducto { get; set; }
    //    public int IdSerial { get; set; }
    //    public string Serial { get; set; }
    //    public bool Estatus { get; set; }
    //    public int Mensaje { get; set; }

    //    public virtual ICollection<ProductosEntity> Productos { get; set; }

    //}

    public class ProdcutosEntity : GruposDetallesEntity
    {
        public int IdProducto { get; set; }
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public int Orden { get; set; }
        public int IdGrupo { get; set; }
        public int IdPadre { get; set; }
        public int Icono { get; set; }
        public string UrlDetalle { get; set; }
        public bool Estatus { get; set; }
        public DateTime FechaRegistro { get; set; }

        public string Sku { get; set; }
        public int IdDepartamento { get; set; }
        public int IdFabricante { get; set; }
        public int Stock { get; set; }
        public int StockMin { get; set; }
        public decimal PrecioCompra { get; set; }
        public decimal PrecioVenta { get; set; }
    }
}

