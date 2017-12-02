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
                var query = (from m in db.GruposDetalles
                             where m.IdGrupoDetalle == idProducto
                             join p in db.PSDetalles on
                             m.IdGrupoDetalle equals p.IdProducto
                             select m).FirstOrDefault();
                var model = new ProductosEntity()
                {
                    IdGrupoDetalle = idProducto,
                    Titulo = query.Nombre,
                    Descripcion = query.Descripcion,
                    Orden = query.Orden,
                    IdGrupo = query.IdGrupo,
                    IdPadre = query.IdPadre,
                    Icono = query.Icono,
                    UrlDetalle = query.UrlDetalle,
                    //Sku = query.PSDetalles1,
                    //IdDepartamento = query.PSDetalles,
                    //IdFabricante = query.PSDetalles1,
                    //Stock = query.,
                    //IdUnidad = query.PSDetalles3,
                    //StockMin = query.Email,
                    //PrecioCompra = query.Email,
                    //PrecioVenta = query.Email,
                    //Garantia = query.Email,
                    //PrecioVenta = query.Email,
                    FechaRegistro = query.FechaRegistro
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

        public IEnumerable<PersonasEntity> Listar()
        {
            try
            {
                IList<PersonasEntity> lista = new List<PersonasEntity>();
                var query = (from m in db.vw_Personas
                             select m).ToList();
                foreach (var personas in query)
                {
                    lista.Add(new PersonasEntity()
                    {
                        IdPersona = personas.IdPersona,
                        Nombres = personas.Nombres,
                        Identificacion = personas.Cedula,
                        Telefonos = personas.Telefonos,
                        Direccion = personas.Direccion,
                        Email = personas.Email,
                        FechaRegistro = personas.FechaRegistro
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

        public IEnumerable<PersonasEntity> ListarPorFabricante()
        {
            try
            {
                IList<PersonasEntity> lista = new List<PersonasEntity>();
                var query = (from m in db.vw_Personas
                             select m).ToList();
                foreach (var personas in query)
                {
                    lista.Add(new PersonasEntity()
                    {
                        IdPersona = personas.IdPersona,
                        Nombres = personas.Nombres,
                        Identificacion = personas.Cedula,
                        Telefonos = personas.Telefonos,
                        Direccion = personas.Direccion,
                        Email = personas.Email,
                        FechaRegistro = personas.FechaRegistro
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

        public IEnumerable<PersonasEntity> ListarPorDepartamento()
        {
            try
            {
                IList<PersonasEntity> lista = new List<PersonasEntity>();
                var query = (from m in db.vw_Personas
                             select m).ToList();
                foreach (var personas in query)
                {
                    lista.Add(new PersonasEntity()
                    {
                        IdPersona = personas.IdPersona,
                        Nombres = personas.Nombres,
                        Identificacion = personas.Cedula,
                        Telefonos = personas.Telefonos,
                        Direccion = personas.Direccion,
                        Email = personas.Email,
                        FechaRegistro = personas.FechaRegistro
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
