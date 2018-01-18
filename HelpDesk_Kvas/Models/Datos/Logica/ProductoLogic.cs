using HelpDesk_Kvas.Models.Datos.DAL;
using HelpDesk_Kvas.Models.Datos.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelpDesk_Kvas.Models.Datos.Logica
{
    public class ProductoLogic
    {
        private GrupoDetalleDAL objDetalleDAL;
        private GrupoDAL objGrupoDAL;
        private ProductoDAL objProductoDAL;
        dbDataContext db;
        public ProductoLogic()
        {
            objDetalleDAL = new GrupoDetalleDAL();
            objGrupoDAL = new GrupoDAL();
            objProductoDAL = new ProductoDAL();
            db = new dbDataContext();
        }

        public void Insertar(ProductosEntity objProducto)
        {
            try
            {
                objProductoDAL.Insertar(objProducto);
                objProducto.Mensaje = 99;
                return;
            }
            catch
            {
                objProducto.Mensaje = 1;
            }
        }

        public void Actualizar(ProductosEntity objProducto)
        {
            try
            {
                objProductoDAL.Actualizar(objProducto);
                objProducto.Mensaje = 98;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Eliminar(ProductosEntity objProducto)
        {
            try
            {
                objProductoDAL.Eliminar(objProducto);
                objProducto.Mensaje = 99;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public IEnumerable<ProductosEntityView> Listar()
        {
            return objProductoDAL.Listar();
        }

        public IEnumerable<ProductosEntityView> BuscarNombre(string _nombre)
        {
            return objProductoDAL.BuscarNombre(_nombre);
        }

        public ProductosEntity Buscar(int _idProducto)
        {
            return objProductoDAL.Buscar(_idProducto);

        }

        public bool IsSkuExist(string sku)
        {
            var v = db.ProductoServicios.Where(a => a.Sku == sku).FirstOrDefault();
            return v != null;
        }
    }
}
