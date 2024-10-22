using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAPA_DOMINIO.Entidades
{
    public class ClsAsegurado
    {
        public int IdAsegurado { get; set; }
        public int IdCliente { get; set; }
        public int IdSeguro { get; set; }
        public int IdTipoCliente { get; set; }
        public DateTime FechaAsignacion { get; set; }
        public DateTime? FechaEliminacion { get; set; }
        public DateTime? FechaModificacion { get; set; }
        public int IdEstado { get; set; }
    }
}
