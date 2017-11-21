using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KvasLogic
{
    /// <summary>
    /// GRID DEL SISTEMA
    /// </summary>
    public class DataGrid
    {
        /// <summary>
        /// Variables de la Tabla
        /// </summary>
        public string Columna { get; set; }
        public string Columna_orden { get; set; }
        public int Limite { get; set; }
        public int Pagina { get; set; }

        public List<GridFiltro> Filtros { get; set; }
        public List<GridParametro> Parametros { get; set; }

        private GridResponde gridResponde = new GridResponde();

        public void Inicializar()
        {
            /* Cantidad de registros por página */
            Pagina = Pagina - 1;

            /* Desde que número de fila va a paginar */
            if (Pagina > 0) Pagina = Pagina * Limite;

            /* Filtros */
            if (Filtros == null)
                Filtros = new List<GridFiltro>();

            /* Parametros adicionales */
            if (Parametros == null)
                Parametros = new List<GridParametro>();
        }

        public void SetData(dynamic _data, int _total)
        {
            gridResponde = new GridResponde
            {
                Data = _data,
                Total = _total
            };
        }

        public GridResponde responde()
        {
            return gridResponde;
        }
    }

    public class GridResponde
    {
        public int Total { get; set; }
        public dynamic Data { get; set; }
    }

    public class GridFiltro
    {
        public string Columna { get; set; }
        public string Valor { get; set; }
    }

    public class GridParametro
    {
        public string Clave { get; set; }
        public string Valor { get; set; }
    }
}
