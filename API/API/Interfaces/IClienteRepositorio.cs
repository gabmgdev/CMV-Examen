using API.Dtos;
using API.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Interfaces
{
    public interface IClienteRepositorio
    {
        public List<Cliente> ObtenerClientes();
        public ListadoPaginacionDto<Cliente> ObtenerClientesPaginados(PaginacionDto paginacionDto);
        public void CrearCliente(ClienteCreacionDto clienteCreacionDto);
        public void EditarCliente(int idCliente, ClienteEditarDto clienteEditarDto);
        public void EliminarCliente(int idCliente);
        public Cliente ObtenerClientePorId(int idCliente);
        public List<ClienteCuentaDto> ObtenerCuentasDeCliente(int idCliente);
        public bool ClienteExistente(int idCliente);
    }
}
