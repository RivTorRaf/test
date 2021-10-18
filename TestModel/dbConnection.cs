using System.Data.SqlClient;

namespace TestModel
{
    public class DbConnection
    {       
        private SqlConnection sqlConnection;

        public DbConnection(){
            this.sqlConnection = new SqlConnection();
        }

        public void OpenConnection()
        {
            //this.sqlConnection.ConnectionString = "Data Source=<YOUR PC>\\SQLEXPRESS;Initial Catalog=test;Integrated Security=True";
            this.sqlConnection.ConnectionString = "Server=tcp:sql-server-test-2021.database.windows.net,1433;Initial Catalog=test;Persist Security Info=False;User ID=admin-test;Password=Password12345!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
            this.sqlConnection.Open();
        }

        public void CloseConnection()
        {
            this.sqlConnection.Close();
        }

        public SqlCommand Query(string queryString)
        {
            SqlCommand query = new SqlCommand
            {
                Connection = this.sqlConnection,
                CommandText = queryString
            };
            return query;
        }

    }
}
