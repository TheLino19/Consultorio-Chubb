using CAPA_APLICACION.Bases;
using CAPA_DOMINIO.Entidades;
using CAPA_INFRASTRUCTURAS.Repositorio.Validacion;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAPA_APLICACION.Servicios.Validacion
{
    public class ValidacionService : IValidacionService
    {
        public readonly IValidacionRepository _validacionRepository;

        public ValidacionService(IValidacionRepository validacionRepository)
        {
            _validacionRepository = validacionRepository;
        }

        public GenericResponse<Dictionary<string, object>> AsegurarCliente(string cedula, string codigoSeguro, string tipoCliente)
        {
            throw new NotImplementedException();
        }

        public GenericResponse<List<Dictionary<string,object>>> getTiposSeguro(int edad)
        {
            GenericResponse<List<Dictionary<string, object>>> response = new GenericResponse<List<Dictionary<string, object>>>();
            List<ClsCliente> lstCliente = new List<ClsCliente>();
            string query = "sp_SeguroPorEdad";

            SqlParameter[] parametros = new SqlParameter[]
            {
                new SqlParameter("@edad", edad),
                new SqlParameter("@id_estado", 1)
            };
            List<Dictionary<string, object>> result = _validacionRepository.ejecutarSp(query, parametros);
            try
            {
                if (result.Any())
                {
                    response.code = 200;
                    response.data = result;
                    response.mensage = "Se encontro seguros";

                }
                else
                {
                    response.code = -1;
                    response.mensage = "No existen seguros para esa edad";
                }


            }
            catch (Exception ex)
            {
                response.code = 500;
                response.mensage = "Error con la Base de Datos";
            }

            return response;
        }

        public GenericResponse<List<Dictionary<string, object>>> segurosAsociados(string cedula)
        {
            GenericResponse<List<Dictionary<string, object>>> response = new GenericResponse<List<Dictionary<string, object>>>();
            string query = "sp_ObtenerSegurosAsociados";

            SqlParameter[] parametros = new SqlParameter[]
            {
                new SqlParameter("@cedula", cedula),
                new SqlParameter("@id_estado", 1)
            };
            List<Dictionary<string, object>> result = _validacionRepository.ejecutarSp(query, parametros);
            try
            {
                if (result.Any())
                {
                    response.code = 200;
                    response.data = result;
                    response.mensage = "Se encontro seguros";

                }
                else
                {
                    response.code = 200;
                    response.mensage = "No existen seguros para este cliente";
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
