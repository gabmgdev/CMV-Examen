using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dtos
{
    public class PaginacionDto
    {
        public int Pagina { get; set; } = 1;
        private int _recordsPorPagina = 10;
        private readonly int _cantidadMaximaRecordsPorPagina = 50;
        public int RecordsPorPagina
        {
            get
            {
                return _recordsPorPagina;
            }
            set
            {
                _recordsPorPagina = (value > _cantidadMaximaRecordsPorPagina) ? _cantidadMaximaRecordsPorPagina : value;
            }
        }
    }
}
