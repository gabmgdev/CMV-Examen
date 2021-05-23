using API.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Interfaces
{
    public interface ICuentaRepositorio
    {
        public void CrearCuenta(ClienteCuentaCreacionDto clienteCuentaCreacionDto);
    }
}
