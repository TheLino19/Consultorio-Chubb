using CAPA_APLICACION.Bases;
using CAPA_APLICACION.Dtos.request;
using CAPA_APLICACION.Dtos.response;
using CAPA_DOMINIO.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAPA_APLICACION.Servicios.Seguros
{
    public interface ISegurosService
    {
        GenericResponse<List<ClsSeguro>> getAllSeguro();
        GenericResponse<Dictionary<string, object>> crearSeguro(SeguroRequest seguroRequest);
        GenericResponse<Dictionary<string, object>> eliminarSeguro(int id_seguro);
        GenericResponse<Dictionary<string, object>> modificarCliente(SeguroRequest seguroRequest);
    }
}
