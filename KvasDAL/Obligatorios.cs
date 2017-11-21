using System.Collections.Generic;

namespace KvasDAL
{
    public interface Obligatorios<TodasClases>
    {
        void Insertar(TodasClases obj);
        void Eliminar(TodasClases obj);
        void Actualizar(TodasClases obj);
        TodasClases Buscar(int obj);
        IEnumerable<TodasClases> Listar();
    }
}
