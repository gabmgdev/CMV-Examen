using API.Dtos;
using API.Interfaces;
using API.Modelos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private readonly IClienteRepositorio _clienteRepositorio;

        public ClientesController(IClienteRepositorio clienteRepositorio)
        {
            _clienteRepositorio = clienteRepositorio;
        }

        [HttpGet]
        public ActionResult<List<Cliente>> ObtenerClientes()
        {
            try
            {
                return _clienteRepositorio.ObtenerClientes();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error al obtener clientes");
            }
            
        }

        [HttpGet("paginacion")]
        public ActionResult<ListadoPaginacionDto<Cliente>> ObtenerClientesPaginacion([FromQuery] PaginacionDto paginacionDto)
        {
            try
            {
                return _clienteRepositorio.ObtenerClientesPaginados(paginacionDto);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error al obtener clientes");
            }

        }

        [HttpGet("{idCliente}")]
        public ActionResult<Cliente> ObtenerClientePorId(int idCliente)
        {
            try
            {
                if (!_clienteRepositorio.ClienteExistente(idCliente))
                    return NotFound("Cliente no encontrado");
                return _clienteRepositorio.ObtenerClientePorId(idCliente);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error al obtener cliente");
            }
        }

        [HttpGet("{idCliente}/cuentas")]
        public ActionResult<List<ClienteCuentaDto>> ObtenerCuentasDeCliente(int idCliente)
        {
            try
            {
                if (!_clienteRepositorio.ClienteExistente(idCliente))
                    return NotFound("Cliente no encontrado");
                return _clienteRepositorio.ObtenerCuentasDeCliente(idCliente);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error al obtener cuentas del cliente: {idCliente}");
            }
        }

        [HttpPost]
        public ActionResult CrearCliente([FromBody] ClienteCreacionDto clienteCreacionDto)
        {
            try
            {
                _clienteRepositorio.CrearCliente(clienteCreacionDto);
                return Ok("Cliente creado correctamente");
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error al crear cliente");
            }
        }

        [HttpPut("{idCliente}")]
        public ActionResult<string> EditarCliente(int idCliente, ClienteEditarDto clienteEditarDto)
        {
            try
            {
                if (!_clienteRepositorio.ClienteExistente(idCliente))
                    return NotFound("Cliente no encontrado");
                _clienteRepositorio.EditarCliente(idCliente, clienteEditarDto);
                    return Ok("Cliente editado correctamente");
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error al editar cliente");
            }
            
        }

        [HttpDelete("{idCliente}")]
        public ActionResult<string> EliminarCliente(int idCliente)
        {
            try
            {
                if (!_clienteRepositorio.ClienteExistente(idCliente))
                    return NotFound("Cliente no encontrado");
                _clienteRepositorio.EliminarCliente(idCliente);
                return Ok("Cliente eliminado correctamente");
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error al eliminar cliente");
            }
        }
    }
}
