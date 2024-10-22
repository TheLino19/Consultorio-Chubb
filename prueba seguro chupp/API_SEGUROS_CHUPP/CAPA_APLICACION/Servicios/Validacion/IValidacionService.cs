using CAPA_APLICACION.Bases;
using CAPA_DOMINIO.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAPA_APLICACION.Servicios.Validacion
{
    public interface IValidacionService
    {
        GenericResponse<List<Dictionary<string, object>>> getTiposSeguro(int edad);
        GenericResponse<List<Dictionary<string, object>>> segurosAsociados(string cedula);
        GenericResponse<Dictionary<string, object>> AsegurarCliente(string cedula , string codigoSeguro,string tipoCliente);
    }
}
