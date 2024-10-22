using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAPA_INFRASTRUCTURAS.Persitencia.Configuracion
{
    public interface ISqlConnectionFactory
    {
        SqlConnection CrearConexion();
    }
}
