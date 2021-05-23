using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dtos
{
    public class ListadoPaginacionDto<T>
    {
        public int TotalRegistros { get; set; }
        public List<T> Data { get; set; }
    }
}
