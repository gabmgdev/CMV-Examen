using API.Dtos;
using API.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CuentasController : ControllerBase
    {
        private readonly ICuentaRepositorio _cuentaRepositorio;
        private readonly IClienteRepositorio _clienteRepositorio;

        public CuentasController(ICuentaRepositorio cuentaRepositorio, IClienteRepositorio clienteRepositorio)
        {
            _cuentaRepositorio = cuentaRepositorio;
            _clienteRepositorio = clienteRepositorio;
        }

        [HttpPost]
        public ActionResult CrearCuenta([FromBody] ClienteCuentaCreacionDto clienteCuentaCreacionDto)
        {
            try
            {
                if (!_clienteRepositorio.ClienteExistente(clienteCuentaCreacionDto.IdCliente))
                    return NotFound("Cliente no encontrado");
                _cuentaRepositorio.CrearCuenta(clienteCuentaCreacionDto);
                return Ok("Cuenta creada correctamente");
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error al crear cuenta");
            }
        }
    }
}
