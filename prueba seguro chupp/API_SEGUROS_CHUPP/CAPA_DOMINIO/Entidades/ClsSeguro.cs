using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAPA_DOMINIO.Entidades
{
    public class ClsSeguro
    {
        public int IdSeguro { get; set; }
        public string CodigoSeguro { get; set; }
        public decimal SumaAsegurada { get; set; }
        public decimal Prima { get; set; }
        public int RangoEdadMin { get; set; }
        public int RangoEdadMax { get; set; }
        public string EsFamiliar { get; set; }
        public int LimiteAsegurados { get; set; }
        public string IdTipoSeguro { get; set; }
        public string IdEstado { get; set; }


        public ClsSeguro(Dictionary<string, object> request)
        {
            IdSeguro = Convert.ToInt32(request["id_seguro"]);
            CodigoSeguro = request["codigo_seguro"].ToString();
            SumaAsegurada = Convert.ToDecimal(request["suma_asegurada"]);
            Prima = Convert.ToDecimal(request["prima"]);
            RangoEdadMin = Convert.ToInt32(request["rango_edad_min"]);
            RangoEdadMax = Convert.ToInt32(request["rango_edad_max"]);
            EsFamiliar = request["es_familiar"].ToString();
            LimiteAsegurados = Convert.ToInt32(request["limite_asegurados"]);
            IdTipoSeguro = request["id_tipo_seguro"].ToString();
            IdEstado = request["id_estado"].ToString();
        }
    }
}
