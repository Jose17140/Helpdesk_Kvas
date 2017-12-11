using KvasEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KvasDAL
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
                var fecha = DateTime.Now;
                var insert = db.sp_AgregarProducto(producto.Titulo, producto.Descripcion, producto.Orden, producto.IdGrupo, producto.IdPadre,
                                                    producto.Icono,producto.UrlDetalle,producto.Estatus,fecha,producto.Sku, producto.IdFabricante, 
                                                    producto.Stock,producto.IdUnidad, producto.StockMin, producto.PrecioCompra, producto.PrecioVenta, 
                                                    producto.Garantia);
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
                var query = db.sp_EliminarProducto(producto.IdGrupoDetalle);
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
                
                var insert = db.sp_ActualizarProducto(producto.IdGrupoDetalle, producto.Titulo, producto.Descripcion, producto.Orden, 
                                                    producto.IdGrupo, producto.IdPadre, producto.Icono, producto.UrlDetalle, producto.Estatus, 
                                                    producto.Sku, producto.IdFabricante, producto.Stock, producto.IdUnidad, producto.StockMin, 
                                                    producto.PrecioCompra, producto.PrecioVenta, producto.Garantia);
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
                var query = db.sp_BuscarProducto(idProducto).FirstOrDefault();
                var model = new ProductosEntity()
                {
                    IdGrupoDetalle = idProducto,
                    Titulo = query.Titulo,
                    Descripcion = query.Descripcion,
                    Orden = Convert.ToInt32(query.Orden),
                    IdGrupo = query.IdGrupo,
                    IdPadre = query.IdPadre,
                    Icono = query.Icono,
                    Sku = query.Sku,
                    IdFabricante = Convert.ToInt32(query.IdFabricante),
                    Stock = Convert.ToInt32(query.Stock),
                    IdUnidad = Convert.ToInt32(query.IdUnidad),
                    StockMin = Convert.ToInt32(query.Stock_Min),
                    PrecioCompra = Convert.ToDecimal(query.PrecioCompra),
                    PrecioVenta = Convert.ToDecimal(query.PrecioVenta),
                    Garantia = Convert.ToInt32(query.Garantia),
                    FechaRegistro = Convert.ToDateTime(query.FechaRegistro)
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
                var query = db.sp_ListarProducto().ToList();
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
