using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAPA_APLICACION.Dtos.request
{
    public class SeguroRequest
    {
        public string codigo_seguro { get; set; }
        public decimal suma_asegurada { get; set; }
        public decimal prima { get; set; }
        public int rango_edad_min { get; set; }
        public int rango_edad_max { get; set; }
        public string es_familiar { get; set; }
        public int limite_asegurados { get; set; }
        public string id_tipo_seguro { get; set; }




    }
}
