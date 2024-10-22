using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAPA_DOMINIO.Entidades
{
    public class ClsCliente
    {
        public int IdCliente { get; set; }
        public string Cedula { get; set; }
        public string Nombres { get; set; }
        public string Telefono { get; set; }
        public int Edad { get; set; }
        public string IdEstado { get; set; }

        public ClsCliente(Dictionary<string, object> request) {
            IdCliente = Convert.ToInt32(request["id_cliente"]);
            Cedula  = request["cedula"].ToString();
            Nombres = request["nombres"].ToString();
            Telefono = request["telefono"].ToString();
            Edad = Convert.ToInt32(request["edad"]);
            IdEstado = request["id_estado"].ToString();

        }
    }
}
