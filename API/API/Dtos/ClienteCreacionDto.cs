using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dtos
{
    public class ClienteCreacionDto
    {
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [StringLength(30, MinimumLength = 1, ErrorMessage = "El campo {0} debe contener entre 1 y 30 caracteres")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [StringLength(30, MinimumLength = 1, ErrorMessage = "El campo {0} debe contener entre 1 y 30 caracteres")]
        public string ApellidoPaterno { get; set; }
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [StringLength(30, MinimumLength = 1, ErrorMessage = "El campo {0} debe contener entre 1 y 30 caracteres")]
        public string ApellidoMaterno { get; set; }
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [StringLength(13, MinimumLength = 13, ErrorMessage = "El campo {0} debe contener 13 caracteres")]
        public string Rfc { get; set; }
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [StringLength(18, MinimumLength = 18, ErrorMessage = "El campo {0} debe contener 18 caracteres")]
        public string Curp { get; set; }
        public DateTime FechaAlta { get; set; } = DateTime.Now;
    }
}
