using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Modelos
{
    public class Cliente
    {
        public int IdCliente { get; set; }
        public string Nombre { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public string Rfc { get; set; }
        public string Curp { get; set; }
        public DateTime FechaAlta { get; set; }
    }
}
