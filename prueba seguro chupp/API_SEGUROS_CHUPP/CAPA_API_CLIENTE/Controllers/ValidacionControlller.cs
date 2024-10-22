using CAPA_APLICACION.Bases;
using CAPA_APLICACION.Servicios.Validacion;
using CAPA_DOMINIO.Entidades;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CAPA_API_CLIENTE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValidacionControlller : ControllerBase
    {
        public readonly IValidacionService _validacionService;

        public ValidacionControlller(IValidacionService validacionService)
        {
            _validacionService = validacionService;
        }

        [HttpPost("SeguroPorEdad")]
        public GenericResponse<List<Dictionary<string, object>>> obtenerSegurosPorEdad([FromBody] int edad )
        {
            return _validacionService.getTiposSeguro(edad);
        }


        [HttpPost("SegurosAsociados")]
        public GenericResponse<List<Dictionary<string, object>>> segurosAsociados([FromBody] string cedula)
        {
            return _validacionService.segurosAsociados(cedula);
        }

        
    }
}
