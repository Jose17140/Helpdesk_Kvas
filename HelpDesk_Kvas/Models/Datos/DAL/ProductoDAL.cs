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

                //var insert = db.sp_ActualizarProducto(producto.IdGrupoDetalle, producto.Titulo, producto.Descripcion, producto.Orden, 
                //                                    producto.IdGrupo, producto.IdPadre, producto.Icono, producto.UrlDetalle, producto.Estatus, 
                //                                    producto.Sku, producto.IdFabricante, producto.Stock, producto.IdUnidad, producto.StockMin, 
                //                                    producto.PrecioCompra, producto.PrecioVenta, producto.Garantia);
                //db.SubmitChanges();
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
                        IdGrupoDetalle = Convert.ToInt32(producto.IdProducto),
                        Sku = producto.Sku,
                        Titulo = producto.Nombre,
                        Descripcion = producto.Descripcion,
                        Orden = Convert.ToInt32(producto.Orden),
                        IdGrupo = Convert.ToInt32(producto.IdGrupo),
                        Grupo = producto.Grupo,
                        IdPadre = Convert.ToInt32(producto.IdPadre),
                        Padre = producto.Padre,
                        Icono = producto.Icono,
                        IdFabricante = Convert.ToInt32(producto.IdFabricante),
                        Fabricante = producto.Fabricante,
                        Stock = Convert.ToInt32(producto.Stock),
                        StockMin = Convert.ToInt32(producto.Stock_Min),
                        IdUnidad = Convert.ToInt32(producto.IdUnidad),
                        Unidad = producto.Unidad,
                        Garantia = Convert.ToInt32(producto.Garantia),
                        PrecioCompra = Convert.ToDecimal(producto.PrecioCompra),
                        PrecioVenta = Convert.ToDecimal(producto.PrecioVenta),
                        Estatus = Convert.ToBoolean(producto.Estatus),
                        FechaRegistro = Convert.ToDateTime(producto.FechaRegistro)
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
