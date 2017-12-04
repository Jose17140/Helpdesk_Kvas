using KvasDAL;
using KvasEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KvasLogic
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

        public ProductosEntity Buscar(int _idProducto)
        {
            return objProductoDAL.Buscar(_idProducto);

        }

        //public IEnumerable<ProductosEntity> ListarPorGrupo(int _idProducto)
        //{
        //    return objDetalleDAL.ListaPorGrupoSP(_idProducto);
        //}

        //public IEnumerable<ProductosEntity> ListarPorGrupo(int _idProducto)
        //{
        //    return objDetalleDAL.ListaPorGrupoSP(_idProducto);
        //}
    }
}
