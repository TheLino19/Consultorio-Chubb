using CAPA_APLICACION.Bases;
using CAPA_APLICACION.Dtos.request;
using CAPA_APLICACION.Dtos.response;
using CAPA_DOMINIO.Entidades;
using CAPA_INFRASTRUCTURAS.Repositorio.Clientes;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAPA_APLICACION.Servicios.Seguros
{
    public class SeguroService : ISegurosService
    {
        private readonly IClienteRepository _clienteRepositorio;

        public SeguroService(IClienteRepository clienteRepo)
        {
            _clienteRepositorio = clienteRepo;
        }

        public GenericResponse<Dictionary<string, object>> crearSeguro(SeguroRequest seguroRequest)
        {
            GenericResponse<Dictionary<string, object>> response = new GenericResponse<Dictionary<string, object>>();
            string query = "sp_InsertarSeguro";

            SqlParameter[] parametros = new SqlParameter[]
            {
                new SqlParameter("@codigoSeguro", seguroRequest.codigo_seguro),
                new SqlParameter("@sumaAsegurada", seguroRequest.suma_asegurada),
                new SqlParameter("@prima", seguroRequest.prima),
                new SqlParameter("@rangoEdadMin", seguroRequest.rango_edad_min),
                new SqlParameter("@rangoEdadMax", seguroRequest.rango_edad_max),
                new SqlParameter("@esFamiliar", seguroRequest.es_familiar),
                new SqlParameter("@limiteAsegurados", seguroRequest.limite_asegurados),
                new SqlParameter("@idTipoSeguro", seguroRequest.id_tipo_seguro),
                new SqlParameter("@idEstado", 1),

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
                        response.mensage = "Este seguro ya está registrado";
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

        public GenericResponse<Dictionary<string, object>> eliminarSeguro(int id_seguro)
        {
            GenericResponse<Dictionary<string, object>> response = new GenericResponse<Dictionary<string, object>>();
            string query = "sp_eliminarSeguro";

            SqlParameter[] parametros = new SqlParameter[]
            {
                new SqlParameter("@id_seguro", id_seguro),
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

        public GenericResponse<List<ClsSeguro>> getAllSeguro()
        {
            GenericResponse<List<ClsSeguro>> response = new GenericResponse<List<ClsSeguro>>();
            List<ClsSeguro> lstSeguro = new List<ClsSeguro>();
            string query = "sp_ObtenerSeguros";

            SqlParameter[] parametros = new SqlParameter[]
            {
                new SqlParameter("@id_estado", 1)
            };
            List<Dictionary<string, object>> result = _clienteRepositorio.ejecutarSp(query, parametros);
            try
            {
                if (result.Any())
                {

                    foreach (Dictionary<string, object> item in result)
                    {
                        lstSeguro.Add(new ClsSeguro(item));
                    }
                    response.code = 200;
                    response.data = lstSeguro;
                    response.mensage = "Resultado exitoso";

                }
                else
                {
                    response.code = 200;
                    response.data = null;
                    response.mensage = "No hay Seguros";

                }


            }
            catch (Exception ex)
            {
                response.code = ex.GetHashCode();
                response.mensage = "Error con la Base de Datos";
            }

            return response;
        }

        public GenericResponse<Dictionary<string, object>> modificarCliente(SeguroRequest seguroRequest)
        {
            GenericResponse<Dictionary<string, object>> response = new GenericResponse<Dictionary<string, object>>();
            string query = "sp_modificarSeguro";

            SqlParameter[] parametros = new SqlParameter[]
            {
                new SqlParameter("@codigo_seguro", seguroRequest.codigo_seguro),
                new SqlParameter("@sumaAsegurada", seguroRequest.suma_asegurada),
                new SqlParameter("@prima", seguroRequest.prima),
                new SqlParameter("@rangoEdadMin", seguroRequest.rango_edad_min),
                new SqlParameter("@rangoEdadMax", seguroRequest.rango_edad_max),
                new SqlParameter("@esFamiliar", seguroRequest.es_familiar),
                new SqlParameter("@limiteAsegurados", seguroRequest.limite_asegurados),
                new SqlParameter("@idTipoSeguro", seguroRequest.id_tipo_seguro),
                new SqlParameter("@idEstado", 1),
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
