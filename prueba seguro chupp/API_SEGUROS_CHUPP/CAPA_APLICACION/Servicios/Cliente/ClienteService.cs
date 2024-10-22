using CAPA_APLICACION.Bases;
using CAPA_APLICACION.Dtos.response;
using CAPA_APLICACION.Servicios.Excel;
using CAPA_DOMINIO.Entidades;
using CAPA_INFRASTRUCTURAS.Repositorio.Clientes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAPA_APLICACION.Servicios.Cliente
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository _clienteRepositorio;

        public ClienteService(IClienteRepository clienteRepo)
        {
            _clienteRepositorio = clienteRepo;
        }

        public GenericResponse<List<ClsCliente>> getAllClientes()
        {
            GenericResponse<List<ClsCliente>> response = new GenericResponse<List<ClsCliente>>();
            List<ClsCliente> lstCliente = new List<ClsCliente>();
            string query = "sp_ObtenerClientes";

            SqlParameter[] parametros = new SqlParameter[]
            {
                new SqlParameter("@id_estado", 1)
            };
            List<Dictionary<string, object>> result = _clienteRepositorio.ejecutarSp(query, parametros);
            try
            {
                if (result.Any())
                {
                    
                    foreach(Dictionary<string, object> item in result)
                    {
                        lstCliente.Add(new ClsCliente(item));
                    }
                    response.code = 200;
                    response.data = lstCliente;
                    response.mensage = "Resultado exitoso";

                }
                

            }
            catch (Exception ex)
            {
                response.code = ex.GetHashCode();
                response.mensage = "Error con la Base de Datos";
            }

            return response;
        }

     
        public GenericResponse<Dictionary<string, object>> crearCliente(ClienteRequest clienteRequest)
        {
            GenericResponse <Dictionary<string, object>> response = new GenericResponse<Dictionary<string, object>>();
            string query = "sp_InsertarCliente";

            SqlParameter[] parametros = new SqlParameter[]
            {
                new SqlParameter("@cedula", clienteRequest.Cedula),
                new SqlParameter("@nombres", clienteRequest.Nombres),
                new SqlParameter("@telefono", clienteRequest.Telefono),
                new SqlParameter("@edad", clienteRequest.Edad)
            };
            List<Dictionary<string, object>> result = _clienteRepositorio.ejecutarSp(query, parametros);
            try
            {
                if (result.Any())
                {
                    if (Convert.ToBoolean(result[0]["InsercionExitosa"]) == true)
                    {
                        response.code = 200;
                        response.data = result[0];
                        response.mensage = "Se ha guardado correctamente";
                    }
                    else
                    {
                        response.code = 200;
                        response.data = result[0];
                        response.mensage = "Este cliente ya está registrado";
                    }
                }
            }
            catch (Exception ex)
            {
                response.code = 500;
                response.mensage = "Error con la Base de Datos";
            }

            return response;
        }

        public GenericResponse<List<ClsCliente>> ObtenerClientesCedula(string cedula)
        {
            GenericResponse<List<ClsCliente>> response = new GenericResponse<List<ClsCliente>>();
            List<ClsCliente> lstCliente = new List<ClsCliente>();
            string query = "sp_buscarClienteCedula";

            SqlParameter[] parametros = new SqlParameter[]
            {
                new SqlParameter("@cedula", cedula),
                new SqlParameter("@id_estado", 1)
           
            };
            List<Dictionary<string, object>> result = _clienteRepositorio.ejecutarSp(query, parametros);
            try
            {
                if (result.Any())
                {
                    foreach (Dictionary<string, object> item in result)
                    {
                        lstCliente.Add(new ClsCliente(item));
                    }
                    response.code = 200;
                    response.data = lstCliente;
                    response.mensage = "Resultado exitoso";
                }
                else
                {
                    response.code = -1;
                    response.data = null;
                    response.mensage = "Cliente no registrado";
                }
            }
            catch (Exception ex)
            {
                response.code = 500;
                response.mensage = "Error con la Base de Datos";
            }

            return response;
        }

        public GenericResponse<Dictionary<string, object>> eliminarCliente(string cedula)
        {
            GenericResponse<Dictionary<string, object>> response = new GenericResponse<Dictionary<string, object>>();
            string query = "sp_eliminarCliente";

            SqlParameter[] parametros = new SqlParameter[]
            {
                new SqlParameter("@cedula", cedula),
                new SqlParameter("@id_estado", 1)
            };
            List<Dictionary<string, object>> result = _clienteRepositorio.ejecutarSp(query, parametros);
            try
            {
                if (result.Any())
                {
                    if (Convert.ToBoolean(result[0]["EliminacionExitosa"]) == true)
                    {
                        response.code = 200;
                        response.data = result[0];
                        response.mensage = "Se ha eliminado correctamente";
                    }
                    else
                    {
                        response.code = 200;
                        response.data = result[0];
                        response.mensage = "No existe informacion";
                    }
                }
            }
            catch (Exception ex)
            {
                response.code = 500;
                response.mensage = "Error con la Base de Datos";
            }

            return response;
        }

        public GenericResponse<Dictionary<string, object>> modificarCliente(ClienteRequest clienteRequest)
        {
            GenericResponse<Dictionary<string, object>> response = new GenericResponse<Dictionary<string, object>>();
            string query = "sp_modificarCliente";

            SqlParameter[] parametros = new SqlParameter[]
            {
                new SqlParameter("@cedula", clienteRequest.Cedula),
                new SqlParameter("@nombres", clienteRequest.Nombres),
                new SqlParameter("@telefono", clienteRequest.Telefono),
                new SqlParameter("@edad",clienteRequest.Edad),
                new SqlParameter("@id_estado",1)
            };
            List<Dictionary<string, object>> result = _clienteRepositorio.ejecutarSp(query, parametros);
            try
            {
                if (result.Any())
                {
                    if (Convert.ToBoolean(result[0]["ActualizacionExitosa"]) == true)
                    {
                        response.code = 200;
                        response.data = result[0];
                        response.mensage = "Se ha modificado correctamente";
                    }
                    else
                    {
                        response.code = 200;
                        response.data = result[0];
                        response.mensage = "No existe informacion";
                    }
                }
            }
            catch (Exception ex)
            {
                response.code = 500;
                response.mensage = "Error con la Base de Datos";
            }

            return response;
        }
    }
}
