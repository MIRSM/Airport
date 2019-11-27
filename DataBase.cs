using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Airport
{
    public class DataBase 
    {
        private SqlConnection _connection;

        public DataBase()
        {
            _connection = Connect();
            _connection.Open();

            /* Рефакторинг: Составление методов (вынесение метода)
             * string datasource = @"";

            string database = "database_name";
            string username = "username";
            string password = "pass";

            string ConnString = @"Data Source=" + datasource + ";Initial Catalog="+ database+ ";Persist Security Info=True;User ID=" + username + ";Password=" + password;

            _connection = new SqlConnection(ConnString);
            _connection.Open();
             */
        }

        //Рефакторинг: Составление методов (вынесение метода)
        private SqlConnection Connect()
        {
            string datasource = @"";

            string database = "database_name";
            string username = "username";
            string password = "pass";

            string ConnString = @"Data Source=" + datasource + ";Initial Catalog="+ database+ ";Persist Security Info=True;User ID=" + username + ";Password=" + password;

            SqlConnection conn = new SqlConnection(ConnString);
            return conn;
        }

        public List<string[]> GetData(int number, string date1, string date2 = null)
        {
            return new List<string[]>();
        }
        
        //отправляет данные о покупке билета в бд
        public void SendData(Ticket ticket)
        {

        }
    }
}
