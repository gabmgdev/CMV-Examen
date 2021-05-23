using API.Dtos;
using API.Interfaces;
using API.Modelos;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace API.Repositorios
{
    public class ClienteRepositorio : IClienteRepositorio
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;

        public ClienteRepositorio(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("DefaultConnection");
        }

        public List<Cliente> ObtenerClientes()
        {
            List<Cliente> clientes = new List<Cliente>();
            string sql = "LISTAR_CLIENTES";
            using (SqlConnection connection = new SqlConnection(_connectionString)) 
            {
                SqlCommand command = new SqlCommand(sql, connection);
                command.CommandType = CommandType.StoredProcedure;
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while(reader.Read())
                    {
                        var cliente = new Cliente();
                        cliente.IdCliente = reader.GetInt32(0);
                        cliente.Nombre = reader.GetString(1);
                        cliente.ApellidoPaterno = reader.GetString(2);
                        cliente.ApellidoMaterno = reader.GetString(3);
                        cliente.Rfc = reader.GetString(4);
                        cliente.Curp = reader.GetString(5);
                        cliente.FechaAlta = reader.GetDateTime(6);
                        
                        clientes.Add(cliente);
                    }
                }
                catch (Exception)
                {
                    throw;
                }
            }
            return clientes;
        }

        public ListadoPaginacionDto<Cliente> ObtenerClientesPaginados(PaginacionDto paginacionDto)
        {
            List<Cliente> clientes = new List<Cliente>();
            string sql = "LISTAR_CLIENTES_PAGINACION";
            SqlConnection connection = new SqlConnection(_connectionString);
            SqlCommand command = new SqlCommand(sql, connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@inicio", (paginacionDto.Pagina - 1) * paginacionDto.RecordsPorPagina);
            command.Parameters.AddWithValue("@recordsPorPagina", paginacionDto.RecordsPorPagina);
            command.Parameters.Add("@totalRecords", SqlDbType.Int);
            command.Parameters["@totalRecords"].Direction = ParameterDirection.Output;
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    var cliente = new Cliente();
                    cliente.IdCliente = reader.GetInt32(0);
                    cliente.Nombre = reader.GetString(1);
                    cliente.ApellidoPaterno = reader.GetString(2);
                    cliente.ApellidoMaterno = reader.GetString(3);
                    cliente.Rfc = reader.GetString(4);
                    cliente.Curp = reader.GetString(5);
                    cliente.FechaAlta = reader.GetDateTime(6);

                    clientes.Add(cliente);
                }
                reader.Close();
            }
            catch (Exception)
            {
                throw;
            }
            var listadoPaginacionClientes = new ListadoPaginacionDto<Cliente>();
            listadoPaginacionClientes.TotalRegistros = (int)command.Parameters["@totalRecords"].Value;
            listadoPaginacionClientes.Data = clientes;
            return listadoPaginacionClientes;
        }

        public void CrearCliente(ClienteCreacionDto clienteCreacionDto)
        {
            string sql = "CREAR_CLIENTE";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand(sql, connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@nombre", clienteCreacionDto.Nombre);
                command.Parameters.AddWithValue("@apellidoPaterno", clienteCreacionDto.ApellidoPaterno);
                command.Parameters.AddWithValue("@apellidoMaterno", clienteCreacionDto.ApellidoMaterno);
                command.Parameters.AddWithValue("@rfc", clienteCreacionDto.Rfc);
                command.Parameters.AddWithValue("@curp", clienteCreacionDto.Curp);
                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        public void EditarCliente(int idCliente, ClienteEditarDto clienteEditarDto)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string sql = "EDITAR_CLIENTE";
                SqlCommand command = new SqlCommand(sql, connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@idCliente", idCliente);
                if (clienteEditarDto.Nombre != null)
                    command.Parameters.AddWithValue("@nombre", clienteEditarDto.Nombre);
                if (clienteEditarDto.ApellidoPaterno != null)
                    command.Parameters.AddWithValue("@apellidoPaterno", clienteEditarDto.ApellidoPaterno);
                if (clienteEditarDto.ApellidoMaterno != null)
                    command.Parameters.AddWithValue("@apellidoMaterno", clienteEditarDto.ApellidoMaterno);
                if (clienteEditarDto.Rfc != null)
                    command.Parameters.AddWithValue("@rfc", clienteEditarDto.Rfc);
                if (clienteEditarDto.Curp != null)
                    command.Parameters.AddWithValue("@curp", clienteEditarDto.Curp);

                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        public void EliminarCliente(int idCliente)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string sql = "ELIMINAR_CLIENTE";
                SqlCommand command = new SqlCommand(sql, connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@idCliente", idCliente);
                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        public Cliente ObtenerClientePorId(int idCliente)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string sql = "LISTAR_CLIENTE";
                SqlCommand command = new SqlCommand(sql, connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@idCLiente", idCliente);
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    reader.Read();
                    var cliente = new Cliente();
                    cliente.IdCliente = reader.GetInt32(0);
                    cliente.Nombre = reader.GetString(1);
                    cliente.ApellidoPaterno = reader.GetString(2);
                    cliente.ApellidoMaterno = reader.GetString(3);
                    cliente.Rfc = reader.GetString(4);
                    cliente.Curp = reader.GetString(5);
                    cliente.FechaAlta = reader.GetDateTime(6);
                    return cliente;
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        public List<ClienteCuentaDto> ObtenerCuentasDeCliente(int idCliente)
        {
            List<ClienteCuentaDto> clienteCuentas = new List<ClienteCuentaDto>();
            string sql = "LISTAR_CLIENTE_CUENTAS";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand(sql, connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@idCliente", idCliente);
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        var clienteCuenta = new ClienteCuentaDto();
                        clienteCuenta.IdClienteCuenta = reader.GetInt32(0);
                        clienteCuenta.NombreCliente = reader.GetString(1);
                        clienteCuenta.NombreCuenta = reader.GetString(2);
                        clienteCuenta.SaldoActual = reader.GetDecimal(3);
                        clienteCuenta.FechaContratacion = reader.GetDateTime(4);
                        clienteCuenta.FechaUltimoMovimiento = reader.GetDateTime(5);

                        clienteCuentas.Add(clienteCuenta);
                    }
                }
                catch (Exception)
                {
                    throw;
                }
            }
            return clienteCuentas;
        }

        public bool ClienteExistente(int idCliente)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string sql = "LISTAR_CLIENTE";
                SqlCommand command = new SqlCommand(sql, connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@idCLiente", idCliente);
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        return true;
                    }
                    return false;
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }
    }
}
