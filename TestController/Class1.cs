using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestModel;
using System.Data;
using System.Data.SqlClient;

namespace TestController
{
    class ProductManager
    {
        public List<Product> productList;
        private DbConnection dbConnection;      

        public ProductManager()
        {
            this.dbConnection = new DbConnection();
            this.productList = new List<Product> { };
        }      

        private Product ReaderInterpreter(IDataRecord dataRecord)
        {
            int id = (int)(dataRecord[0]);
            string code = (string)(dataRecord[1]);
            float weight = float.Parse(dataRecord[2].ToString());
            float price = float.Parse(dataRecord[3].ToString());        
            return new Product(id, code, weight, price);
        }

        public void ReadAllProductListDB()
        {
            this.productList.Clear();

            SqlDataReader reader = null;
            try
            {
                this.dbConnection.OpenConnection();
                reader = this.dbConnection.Query("select * from product").ExecuteReader();                            
                while (reader.Read())
                {                    
                    this.productList.Add(ReaderInterpreter((IDataRecord)reader));
                }               
            }
            catch (SqlException e)
            {
                System.Diagnostics.Debug.WriteLine(e);            
            }
            finally
            {
                if (reader != null) reader.Close();
                this.dbConnection.CloseConnection();
            }
        }
    }
}
