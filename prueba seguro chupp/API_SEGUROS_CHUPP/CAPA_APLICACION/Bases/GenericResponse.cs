using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAPA_APLICACION.Bases
{
    public class GenericResponse<T>
    {
        public int code { get; set; } = 0;
        public T data { get; set; }
        public string mensage { get; set; } = "empty";
    }
}
