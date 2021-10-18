using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using TestModel;
using System.Data;
using System.Data.SqlClient;

namespace TestController
{
    public class StudentsController
    {
        public List<Student> studentList;        
        private DbConnection dbConnection;

        public StudentsController()
        {
            this.dbConnection = new DbConnection();
            this.studentList = new List<Student> { };
        }

        public void getFilteredStudents(string filter)
        {
            this.studentList.Clear();

            SqlDataReader reader = null;
            try
            {
                this.dbConnection.OpenConnection();
                string query_string = "select * from student st inner join school sc on sc.id = st.id_school ";
                if (!String.IsNullOrEmpty(filter))
                {
                    query_string += "where lower(st.names) like '%" + filter + "%' ";
                    query_string += "or lower(st.surnames) like '%" + filter + "%' ";
                    query_string += "or lower(sc.name) like '%" + filter + "%' ";
                    string date_query = ValidDateQuery(filter);
                    if (!String.IsNullOrEmpty(date_query))
                        query_string += "or st.date_of_birth "+date_query;                   
                }
                reader = this.dbConnection.Query(query_string).ExecuteReader();
                while (reader.Read())
                {
                    this.studentList.Add(ReaderInterpreter((IDataRecord)reader));
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e);                
            }
            finally
            {
                if (reader != null) reader.Close();                
                this.dbConnection.CloseConnection();
            }
        }


        private Student ReaderInterpreter(IDataRecord dataRecord)
        {
            int identity_card = (int)(dataRecord[0]);
            string names = (string)(dataRecord[1]);
            string surnames = (string)(dataRecord[2]);
            DateTime date_of_birth = (DateTime)(dataRecord[3]);
            int id_school = (int)(dataRecord[4]);
            string school_name = (string)(dataRecord[5]);
            return new Student(identity_card,names,surnames,date_of_birth,id_school,school_name);
        }
        private string ValidDateQuery(string filter)
        {
            List<string> comparators = new List<string> {"<",">","=","<=",">="};
            int length = filter.Length;
            if (length < 11) return null;
            string date_string = filter.Substring(length - 10);            
            string comparator = filter.Substring(0, length - date_string.Length);            
            if (comparators.IndexOf(comparator) == -1) return null;
            DateTime parsed_date;
            if(DateTime.TryParseExact(date_string,"yyyy-MM-dd",CultureInfo.InvariantCulture,DateTimeStyles.None,out parsed_date))
            {
                return comparator+"'"+date_string+"'";
            }
            else
            {
                return null;
            }
        }

    }
}
