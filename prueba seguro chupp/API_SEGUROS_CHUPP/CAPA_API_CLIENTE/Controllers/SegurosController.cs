using CAPA_APLICACION.Bases;
using CAPA_APLICACION.Dtos.request;
using CAPA_APLICACION.Dtos.response;
using CAPA_APLICACION.Servicios.Cliente;
using CAPA_APLICACION.Servicios.Seguros;
using CAPA_DOMINIO.Entidades;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CAPA_API_CLIENTE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SegurosController : ControllerBase
    {
        private readonly ISegurosService _segurosService;

        public SegurosController(ISegurosService segurosService)
        {
            _segurosService = segurosService;
        }

        [HttpGet("ObtenerSeguros")]
        public GenericResponse<List<ClsSeguro>> ObtenerSeguros()
        {
            return _segurosService.getAllSeguro();
        }

        [HttpPost("CrearSeguro")]
        public GenericResponse<Dictionary<string, object>> crearSeguro([FromBody] SeguroRequest nuevoSeguro)
        {
            return _segurosService.crearSeguro(nuevoSeguro);
        }

        [HttpDelete("eliminarSeguro")]
        public GenericResponse<Dictionary<string, object>> eliminarSeguro([FromBody] int codigo)
        {
            return _segurosService.eliminarSeguro(codigo);
        }

        [HttpPut("editarSeguro")]
        public GenericResponse<Dictionary<string, object>> modificarSeguro([FromBody] SeguroRequest nuevoSeguro)
        {
            return _segurosService.modificarCliente(nuevoSeguro);
        }
    }
}
