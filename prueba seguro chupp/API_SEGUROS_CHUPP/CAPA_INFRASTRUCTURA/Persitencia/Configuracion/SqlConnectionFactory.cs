using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAPA_INFRASTRUCTURAS.Persitencia.Configuracion
{
    public class SqlConnectionFactory : ISqlConnectionFactory
    {
        private readonly string _connectionString;


            public SqlConnectionFactory(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }


        public SqlConnection CrearConexion()
        {
            SqlConnection sqlConnection = null;
            try
            {
                sqlConnection = new SqlConnection( _connectionString );
            }
            catch (Exception ex){ 
               Console.WriteLine( ex.Message ); 
            }
            return sqlConnection;
        }
    }
}
