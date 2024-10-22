using CAPA_DOMINIO.Entidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAPA_INFRASTRUCTURAS.Repositorio.Clientes
{
    public interface IClienteRepository
    {
        List<Dictionary<string, object>> ejecutarSp(string sqlQuery, SqlParameter[] parametros);

    }
}
