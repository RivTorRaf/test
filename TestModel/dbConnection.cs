using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            this.sqlConnection.ConnectionString = "Data Source=LAPTOP-GTUUG201\\SQLEXPRESS;Initial Catalog=TestForms;Integrated Security=True";
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
