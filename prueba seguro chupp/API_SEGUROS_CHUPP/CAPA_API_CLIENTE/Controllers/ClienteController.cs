using CAPA_APLICACION.Bases;
using CAPA_APLICACION.Dtos.request;
using CAPA_APLICACION.Dtos.response;
using CAPA_APLICACION.Servicios.Cliente;
using CAPA_APLICACION.Servicios.Excel;
using CAPA_DOMINIO.Entidades;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;

namespace CAPA_API_CLIENTE.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class ClienteController : Controller
    {
        private readonly IClienteService _clienteService;
        private readonly  IExcelService _excelService;  

        public ClienteController(IClienteService clienteService, IExcelService excelService)
        {
            _clienteService = clienteService;
            _excelService = excelService;
        }

        [HttpGet("ObtenerClientes")]
        public GenericResponse<List<ClsCliente>> ObtenerClientes()
        {
            return _clienteService.getAllClientes();
        }

        [HttpPost("CrearCliente")]
        public GenericResponse<Dictionary<string,object>> crearCliente([FromBody] ClienteRequest nuevoCliente)
        {
            return _clienteService.crearCliente(nuevoCliente);
        }
            
        [HttpPost("ObtenerClientesCedula")]
        public GenericResponse<List<ClsCliente>> ObtenerClientesCedula(string cedula)
        {
            return _clienteService.ObtenerClientesCedula(cedula);
        }

        [HttpPost("obtenerExcel")]
        public GenericResponse<List<ClienteRequest>> obtenerExcel([FromBody] ExcelRequest data)
        {
            string ruta = data.Ruta;
            return _excelService.EscribirArchivoExcel(ruta);
        }

        [HttpDelete("eliminarCliente")]
        public GenericResponse<Dictionary<string, object>> modificarCliente([FromBody] string cedula)
        {
            return _clienteService.eliminarCliente(cedula);
        }

        [HttpPut("editarCliente")]
        public GenericResponse<Dictionary<string, object>> modificarCliente([FromBody] ClienteRequest modificadoCliente)
        {
            return _clienteService.modificarCliente(modificadoCliente);
        }

    }
}
