using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KvasEntity
{
    public class ProductosEntity
    {
        public int IdProducto { get; set; }
        public string Sku { get; set; }
        public int IdCategoria { get; set; }
        public int IdFabricante { get; set; }
        public int Stock { get; set; }
        public int Stock_Min { get; set; }
        public decimal Precio { get; set; }
        public int Garantia { get; set; }
        public bool Estatus { get; set; }
        public int Mensaje { get; set; }
    }

    public class ProductoDetalleEntity
    {
        public int IdProducto { get; set; }
        public int IdSerial { get; set; }
        public string Serial { get; set; }
        public bool Estatus { get; set; }
        public int Mensaje { get; set; }

        public virtual ICollection<ProductosEntity> Productos { get; set; }

    }
}
