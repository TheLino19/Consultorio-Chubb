using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CAPA_APLICACION.Bases;
using CAPA_APLICACION.Dtos.response;
using CAPA_DOMINIO.Entidades;
using ClosedXML.Excel;


namespace CAPA_APLICACION.Servicios.Excel
{
    public class ExcelService : IExcelService
    {


        public DataTable LeerArchivoExcel(string rutaArchivo, int hojaNumero = 1)
        {
            var dataTable = new DataTable();

            using (var workbook = new XLWorkbook(rutaArchivo))
            {
                var worksheet = workbook.Worksheet(hojaNumero);
                var firstRow = true;
                var firstRowUsed = worksheet.FirstRowUsed();
                var lastRowUsed = worksheet.LastRowUsed();
                var firstColumnUsed = worksheet.FirstColumnUsed();
                var lastColumnUsed = worksheet.LastColumnUsed();

                // Agregar columnas
                foreach (var cell in firstRowUsed.Cells())
                {
                    dataTable.Columns.Add(cell.Value.ToString());
                }

                // Agregar filas
                var rows = worksheet.Rows(firstRowUsed.RowNumber() + 1, lastRowUsed.RowNumber());
                foreach (var row in rows)
                {
                    var dataRow = dataTable.NewRow();
                    int columnIndex = 0;
                    foreach (var cell in row.Cells(firstColumnUsed.ColumnNumber(), lastColumnUsed.ColumnNumber()))
                    {
                        dataRow[columnIndex] = cell.Value;
                        columnIndex++;
                    }
                    dataTable.Rows.Add(dataRow);
                }
            }

            return dataTable;
        }

        //"C:/Users/VivoBook/Documents/practicas Viamatica/NET/prueba seguro chupp/API_SEGUROS_CHUPP/template.xlsx"
        public GenericResponse<List<ClienteRequest>> EscribirArchivoExcel(String ruta)
        {
            GenericResponse<List<ClienteRequest>> response = new GenericResponse<List<ClienteRequest>>();
            List<Dictionary<String, Object>> resul = new List<Dictionary<string, object>>();

            try
            {
                var datosExcel = LeerArchivoExcel(ruta);

                foreach (DataRow fila in datosExcel.Rows)
                {
                    Dictionary<String, Object> cliente = new Dictionary<string, object>();
                    foreach (DataColumn columna in datosExcel.Columns)
                    {
                        cliente.Add(columna.ColumnName, fila[columna]);
                        //Console.WriteLine($"{columna.ColumnName}: {fila[columna]}");
                    }
                    resul.Add(cliente);
                }

                if (resul.Count > 0)
                {
                    response.code = 200;
                    response.data = ObtenerListaCliente(resul);
                    response.mensage = "Datos correctamente cargado";
                }
                else
                {
                    response.code = 200;
                    response.mensage = "No hay datos en el archivo";
                }

            }
            catch (Exception ex)
            {
                response.code = 500;
                response.mensage = "Ocurrio un error al procesar los datos";

            }

            return response;
        }

        public List<ClienteRequest> ObtenerListaCliente(List<Dictionary<String, Object>> lst)
        {
            List<ClienteRequest> resultado = new List<ClienteRequest>();
            foreach (Dictionary<String, Object> item in lst)
            {
                resultado.Add(new ClienteRequest(item));
            }
            return resultado;
        }



    }
}
