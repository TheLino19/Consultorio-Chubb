using CAPA_DOMINIO.Entidades;
using CAPA_INFRASTRUCTURAS.Persitencia.Configuracion;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAPA_INFRASTRUCTURAS.Repositorio.Clientes
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly ISqlConnectionFactory _connectionFactory;

        public ClienteRepository(ISqlConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public List<Dictionary<string, object>> ejecutarSp(string sqlQuery, SqlParameter[] parametros)
        {
            using(var connection = _connectionFactory.CrearConexion())
            {
                connection.Open();
                using(SqlCommand command = new SqlCommand(sqlQuery,connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    if (parametros != null)
                    {
                    
                        command.Parameters.AddRange(parametros);
                    }
                    using(SqlDataReader reader = command.ExecuteReader())
                    {
                        var result = new List<Dictionary<string, object>>();
                        while (reader.Read())
                        {
                            var row = new Dictionary<string, object>();

                            for (int i = 0; i < reader.FieldCount; i++)
                            {
                                row[reader.GetName(i)] = reader.GetValue(i);
                            }

                            result.Add(row);
                        }
                       
                        return result;
                    }
                }
            }
        }

        
    }
}
