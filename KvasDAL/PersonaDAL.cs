using KvasEntity;
using System;
using System.Collections.Generic;
using System.Linq;

namespace KvasDAL
{
    public class PersonaDAL : Obligatorios<PersonasEntity>
    {
        dbDataContext db;

        public PersonaDAL()
        {
            db = new dbDataContext();
        }

        public void Insertar(PersonasEntity persona)
        {
            try
            {
                var fecha = DateTime.Now;
                var insert = db.sp_AgregarPersonas(persona.Nombres, persona.IdTipoPersona, persona.CiRif,persona.Direccion,persona.Telefonos,persona.Email, fecha);
                db.SubmitChanges();
            }
            catch (Exception)
            {
                persona.Mensaje = 1000;
            }
            finally
            {

            }
        }

        public void Eliminar(PersonasEntity persona)
        {
            try
            {
                var query = db.sp_EliminarPersonas(persona.IdPersona);
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

        public void Actualizar(PersonasEntity persona)
        {
            try
            {
                var query = db.sp_ActualizarPersonas(persona.IdPersona,persona.Nombres,persona.IdTipoPersona,persona.CiRif,persona.Direccion,persona.Telefonos,persona.Email);
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

        public PersonasEntity Buscar(int idPersona)
        {
            try
            {
                var query = (from m in db.Personas
                             where m.IdPersona == idPersona
                             select m).FirstOrDefault();
                var model = new PersonasEntity()
                {
                    IdPersona = idPersona,
                    Nombres = query.Nombres,
                    IdTipoPersona = query.IdTipoPersona,
                    CiRif = query.CiRif,
                    Direccion = query.Direccion,
                    Telefonos = query.Telefonos,
                    Email = query.Email,
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
    }
}
