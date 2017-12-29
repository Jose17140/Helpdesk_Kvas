using HelpDesk_Kvas.Models.Datos.DAL;
using HelpDesk_Kvas.Models.Datos.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelpDesk_Kvas.Models.Datos.Logica
{
    public class PersonasLogic
    {
        private PersonaDAL objPersonaDAL;
        private GrupoDetalleDAL objGrupoDetalle;
        public PersonasLogic()
        {
            objPersonaDAL = new PersonaDAL();
            objGrupoDetalle = new GrupoDetalleDAL();
        }

        public IEnumerable<GruposDetallesEntity> listaIdentificacion(int id)
        {
            var lista = objGrupoDetalle.ListaPorGrupo(id);
            return lista;
        }

        public void Insertar(PersonasEntity objPersona)
        {
            try
            {
                objPersonaDAL.Insertar(objPersona);
                objPersona.Mensaje = 99;
                return;
            }
            catch
            {
                objPersona.Mensaje = 1;
            }
        }

        public void Actualizar(PersonasEntity objPersona)
        {
            try
            {
                objPersonaDAL.Actualizar(objPersona);
                objPersona.Mensaje = 98;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Eliminar(PersonasEntity objPersona)
        {
            try
            {
                objPersonaDAL.Eliminar(objPersona);
                objPersona.Mensaje = 99;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public IEnumerable<PersonasEntity> Listar()
        {
            return objPersonaDAL.Listar();
        }

        public PersonasEntity Buscar(int _idPersona)
        {
            return objPersonaDAL.Buscar(_idPersona);

        }
    }
}
