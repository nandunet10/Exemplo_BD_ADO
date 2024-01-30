using System.Data.SqlClient;

namespace APIBancoDeDados.DataBase
{
    public class ConexaoSqlServer
    {
        public static SqlConnection Conectar()
        {
            //string connectionString = "Data Source=localhost,1433;User ID=sa;Password=senha@1234;Initial Catalog=DevPraticaPDVAtualizado;";
            string connectionString = "Data Source=bd.thor.hostazul.com.br,3533; User ID=139_fernando; Password=szxuj1tipnvhykqfwbcm;Initial Catalog=139_fernando;";
            SqlConnection connection = new(connectionString);
            return connection;

        }
    }
}
