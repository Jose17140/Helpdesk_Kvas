using HelpDesk_Kvas.Models.Datos.Entity;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HelpDesk_Kvas.Models.Datos.DAL
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
                Personas _persona = new Personas()
                {
                    Nombres = persona.Nombres,
                    IdTipoPersona = persona.IdTipoPersona,
                    CiRif = persona.CiRif,
                    Direccion = persona.Direccion,
                    Telefonos = persona.Telefonos,
                    Email = persona.Email,
                    FechaRegistro = DateTime.Now
                };
                db.Personas.InsertOnSubmit(_persona);
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
                Personas _persona = db.Personas.Where(x => x.IdPersona == persona.IdPersona).SingleOrDefault();
                db.Personas.DeleteOnSubmit(_persona);
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
                Personas query = db.Personas.Where(x => x.IdPersona == persona.IdPersona).SingleOrDefault();
                query.Nombres = persona.Nombres;
                query.IdTipoPersona = persona.IdTipoPersona;
                query.CiRif = persona.CiRif;
                query.Direccion = persona.Direccion;
                query.Telefonos = persona.Telefonos;
                query.Email = persona.Email;
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
                //var query = (from m in db.vw_Personas
                //             select m).ToList();
                //foreach (var personas in query)
                //{
                //    lista.Add(new PersonasEntity()
                //    {
                //        IdPersona = personas.IdPersona,
                //        Nombres = personas.Nombres,
                //        TipoPersona = personas.TipoPersona,
                //        CiRif = personas.CiRif,
                //        Telefonos = personas.Telefonos,
                //        Direccion = personas.Direccion,
                //        Email = personas.Email,
                //        FechaRegistro = personas.FechaRegistro
                //    });
                //}
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
