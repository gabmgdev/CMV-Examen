using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dtos
{
    public class ClienteCuentaCreacionDto
    {
        [Required(ErrorMessage = "El campo {0} es requerido")]
        public int IdCliente { get; set; }
        [Required(ErrorMessage = "El campo {0} es requerido")]
        public int IdTipoCuenta { get; set; }
        [Range(0, Double.MaxValue, ErrorMessage = "El campo {0} debe ser una cantidad positiva")]
        public decimal SaldoActual { get; set; }
    }
}
