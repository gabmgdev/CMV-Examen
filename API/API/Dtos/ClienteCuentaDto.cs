using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dtos
{
    public class ClienteCuentaDto
    {
        public int IdClienteCuenta { get; set; }
        public string NombreCliente { get; set; }
        public string NombreCuenta { get; set; }
        public decimal SaldoActual { get; set; }
        public DateTime FechaContratacion { get; set; }
        public DateTime FechaUltimoMovimiento { get; set; }
    }
}
