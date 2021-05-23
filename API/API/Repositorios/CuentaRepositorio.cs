using API.Dtos;
using API.Interfaces;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace API.Repositorios
{
    public class CuentaRepositorio : ICuentaRepositorio
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;

        public CuentaRepositorio(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("DefaultConnection");
        }

        public void CrearCuenta(ClienteCuentaCreacionDto clienteCuentaCreacionDto)
        {
            string sql = "CREAR_CLIENTE_CUENTA";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand(sql, connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@idCliente", clienteCuentaCreacionDto.IdCliente);
                command.Parameters.AddWithValue("@idCuenta", clienteCuentaCreacionDto.IdTipoCuenta);
                if (clienteCuentaCreacionDto.SaldoActual >= 0) 
                    command.Parameters.AddWithValue("@saldoActual", clienteCuentaCreacionDto.SaldoActual);
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
    }
}
