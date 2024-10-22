using CAPA_APLICACION.Bases;
using CAPA_APLICACION.Dtos.response;
using CAPA_DOMINIO.Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAPA_APLICACION.Servicios.Excel
{
    public interface IExcelService
    {
        DataTable LeerArchivoExcel(string ruta, int hoja);
        GenericResponse<List<ClienteRequest>> EscribirArchivoExcel(String ruta);
        
    }
}
