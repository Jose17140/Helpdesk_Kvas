﻿using System;
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

        public int IdCategoria { get; set; }

        public int IdGrupo { get; set; }

        public string Nombre { get; set; }

        [Display(Name = "Fabricante:")]
        public int IdFabricante { get; set; }

        [Display(Name = "Unidad:")]
        public int IdUnidad { get; set; }

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
    }

    public class ProductosEntityView : ProductosEntity
    {
        public string Equipo { get; set; }
        public string Grupo { get; set; }
        public string Padre { get; set; }
        public string Fabricante { get; set; }
        public string Unidad { get; set; }
    }
}
