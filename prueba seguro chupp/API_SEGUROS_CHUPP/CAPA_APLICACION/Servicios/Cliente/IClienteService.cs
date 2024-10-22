using CAPA_APLICACION.Bases;
using CAPA_APLICACION.Dtos.response;
using CAPA_DOMINIO.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace CAPA_APLICACION.Servicios.Cliente
{
    public interface IClienteService
    {
        GenericResponse<List<ClsCliente>> getAllClientes();
        GenericResponse<Dictionary<string, object>> crearCliente(ClienteRequest clienteRequest);
        GenericResponse<List<ClsCliente>> ObtenerClientesCedula(string cedula);
        GenericResponse<Dictionary<string, object>> eliminarCliente(String  cedula);
        GenericResponse<Dictionary<string, object>> modificarCliente(ClienteRequest clienteRequest);

    }
}
