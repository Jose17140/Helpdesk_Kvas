using HelpDesk_Kvas.Models.Datos.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelpDesk_Kvas.Models.Datos.DAL
{
    public class ProductoDAL
    {
        dbDataContext db;

        public ProductoDAL()
        {
            db = new dbDataContext();
        }

        public void Insertar(ProductosEntity producto)
        {
            try
            {
                ProductoServicios ps = new ProductoServicios()
                {
                    Sku = producto.Sku,
                    IdCategoria = producto.IdCategoria,
                    IdGrupo = producto.IdGrupo,
                    Nombre = producto.Nombre,
                    Descripcion = producto.Descripcion,
                    IdFabricante = producto.IdFabricante,
                    IdUnidad = producto.IdUnidad,
                    Imagen = producto.Imagen,
                    IdCondicion = Convert.ToInt32(producto.IdCondicion),
                    Stock = producto.Stock,
                    StockMin = producto.StockMin,
                    PrecioCompra = producto.PrecioCompra,
                    PrecioVenta = producto.PrecioVenta,
                    Garantia = Convert.ToInt32(producto.Garantia),
                    Estatus = producto.Estatus,
                    FechaRegistro = DateTime.Now
                };
                db.ProductoServicios.InsertOnSubmit(ps);
                db.SubmitChanges();
            }
            catch (Exception)
            {
                producto.Mensaje = 1000;
            }
            finally
            {

            }
        }

        public void Eliminar(ProductosEntity producto)
        {
            try
            {
                ProductoServicios ps = db.ProductoServicios.Where(m => m.IdProducto == producto.IdProducto).SingleOrDefault();
                db.ProductoServicios.DeleteOnSubmit(ps);
                db.SubmitChanges();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {

            }
        }

        public void Actualizar(ProductosEntity producto)
        {
            try
            {

                var query = db.ProductoServicios.Where(m => m.IdProducto == producto.IdProducto).SingleOrDefault();
                query.Sku = producto.Sku;
                query.IdCategoria = producto.IdCategoria;
                query.IdGrupo = producto.IdGrupo;
                query.Nombre = producto.Nombre;
                query.Descripcion = producto.Descripcion;
                query.IdFabricante = producto.IdFabricante;
                query.IdUnidad = producto.IdUnidad;
                query.Imagen = producto.Imagen;
                query.IdCondicion = Convert.ToInt32(producto.IdCondicion);
                query.Stock = producto.Stock;
                query.StockMin = Convert.ToInt32(producto.StockMin);
                query.PrecioCompra = Convert.ToDecimal(producto.PrecioCompra);
                query.PrecioVenta = producto.PrecioVenta;
                query.Garantia = Convert.ToInt32(producto.Garantia);
                query.Estatus = producto.Estatus;
                db.SubmitChanges();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {

            }
        }

        public ProductosEntity Buscar(int idProducto)
        {
            try
            {
                var producto = (from m in db.ProductoServicios
                                where m.IdProducto == idProducto
                             select m).SingleOrDefault();
                var model = new ProductosEntity()
                {
                    IdProducto = idProducto,
                    Sku = producto.Sku,
                    IdCategoria = producto.IdCategoria,
                    IdGrupo = producto.IdGrupo,
                    Nombre = producto.Nombre,
                    Descripcion = producto.Descripcion,
                    IdFabricante = producto.IdFabricante,
                    IdUnidad = producto.IdUnidad,
                    Imagen = producto.Imagen,
                    IdCondicion = Convert.ToInt32(producto.IdCondicion),
                    Stock = producto.Stock,
                    StockMin = Convert.ToInt32(producto.StockMin),
                    PrecioCompra = Convert.ToDecimal(producto.PrecioCompra),
                    PrecioVenta = producto.PrecioVenta,
                    Garantia = Convert.ToInt32(producto.Garantia),
                    Estatus = producto.Estatus,
                    FechaRegistro = DateTime.Now
                };
                return model;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {

            }
        }

        public IEnumerable<ProductosEntityView> Listar()
        {
            try
            {
                IList<ProductosEntityView> lista = new List<ProductosEntityView>();
                var query = db.vw_ListarProductos;
                foreach (var producto in query)
                {
                    lista.Add(new ProductosEntityView()
                    {
                        IdProducto = Convert.ToInt32(producto.IdProducto),
                        Sku = producto.Sku,
                        IdCategoria = producto.IdCategoria,
                        Categoria = producto.Categoria,
                        IdGrupo = producto.IdGrupo,
                        Grupo = producto.Grupo,
                        Nombre = producto.Nombre,
                        Descripcion = producto.Descripcion,
                        IdFabricante = producto.IdFabricante,
                        Fabricante = producto.Fabricante,
                        IdUnidad = producto.IdUnidad,
                        Unidad = producto.Unidad,
                        Imagen = producto.Imagen,
                        Stock = producto.Stock,
                        StockMin = Convert.ToInt32(producto.StockMin),
                        PrecioCompra = Convert.ToDecimal(producto.PrecioCompra),
                        PrecioVenta = producto.PrecioVenta,
                        Garantia = Convert.ToInt32(producto.Garantia),
                        Estatus = producto.Estatus,
                        FechaRegistro = DateTime.Now
                    });
                }
                return lista;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {

            }
        }
    }
}
