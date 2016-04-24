using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace DAO.Utilities
{
    public static class Conexoes
    {
        public static SqlConnection ConexaoSQL()
        {
            //"Server=tcp:tcctarifacao.database.windows.net,1433;Database=TEE;User ID=geovanni.barreto@tcctarifacao;Password={5300Dompedro};Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"
            SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["TCCMVC"].ConnectionString);
            return cnn;
        }

    }
}
