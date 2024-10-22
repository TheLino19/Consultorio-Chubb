using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAPA_APLICACION.Dtos.response
{
    public class ClienteRequest
    {
            public string Cedula { get; set; }
            public string Nombres { get; set; }
            public string Telefono { get; set; }
            public int Edad { get; set; }

        public ClienteRequest(Dictionary<string, object> request)
        {
            Cedula = request["cedula"].ToString();
            Nombres = request["nombres"].ToString();
            Telefono = request["telefono"].ToString();
            Edad = Convert.ToInt32(request["edad"]);

        }

        public ClienteRequest(string cedula, string nombres, string telefono, int edad)
        {
            Cedula = cedula;
            Nombres = nombres;
            Telefono = telefono;
            Edad = edad;
        }
        public ClienteRequest() { }

    }
}
