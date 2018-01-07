using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelpDesk_Kvas.Models.Datos.Entity
{
    public class ProductosEntity
    {
        [Key]
        public int IdProducto { get; set; }

        [Required]
        [StringLength(24)]
        [Display(Name = "Codigo del Producto:")]
        public string Sku { get; set; }

        [Display(Name = "Categoria del Producto:")]
        public int IdCategoria { get; set; }

        [Display(Name = "Producto o Servicio:")]
        public int IdGrupo { get; set; }

        [Display(Name = "Nombre:")]
        public string Nombre { get; set; }

        [Display(Name = "Descripcion:")]
        public string Descripcion { get; set; }

        [Display(Name = "Fabricante:")]
        public int IdFabricante { get; set; }

        [Display(Name = "Unidad:")]
        public int IdUnidad { get; set; }

        [Display(Name = "Imagen:")]
        public string Imagen { get; set; }

        [Display(Name = "Inventario:")]
        public int Stock { get; set; }

        [Display(Name = "Inventario Minimo:")]
        public int StockMin { get; set; }
        
        [Display(Name = "Precio de Compra:")]
        public decimal PrecioCompra { get; set; }

        [Display(Name = "Precio de Venta:")]
        public decimal PrecioVenta { get; set; }

        [Display(Name = "Dias de Garantia:")]
        public int? Garantia { get; set; }

        [DataType(DataType.DateTime)]
        [Display(Name = "Fecha de Registro:")]
        public DateTime FechaRegistro { get; set; }

        [Display(Name = "Estatus:")]
        public bool Estatus { get; set; }

        public int Mensaje { get; set; }
    }

    public class ProductosEntityView : ProductosEntity
    {
        [Display(Name = "Categoria:")]
        public string Categoria { get; set; }

        [Display(Name = "Grupo:")]
        public string Grupo { get; set; }

        [Display(Name = "Fabricante:")]
        public string Fabricante { get; set; }

        [Display(Name = "Unidad:")]
        public string Unidad { get; set; }
    }
}

