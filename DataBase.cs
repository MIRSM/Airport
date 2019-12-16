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

            /* Рефакторинг: 1. Составление методов (вынесение метода)
             * 
             * string datasource = @"DESKTOP-N625QE2";

            string database = "AirportDB";

            string ConnString = @"Data Source=" + datasource + ";Initial Catalog=" + database + ";Integrated Security=True";

            _connection = new SqlConnection(ConnString);
            _connection.Open();
             */
        }

        //Рефакторинг: Составление методов (вынесение метода)
        private SqlConnection Connect()
        {
            string datasource = @"DESKTOP-N625QE2";
            string database = "AirportDB";
            string ConnString = @"Data Source=" + datasource + ";Initial Catalog=" + database + ";Integrated Security=True";

            SqlConnection conn = new SqlConnection(ConnString);
            return conn;
        }

        public List<string> GetAirports()
        {
            string Request = "SELECT name FROM airport GROUP BY name";
            var command = _connection.CreateCommand();
            command.CommandText = Request;
            List<string> str = new List<string>();
            var reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                    str.Add(reader.GetString(0));
            }
            reader.Close();
            return str;
        }

        public List<string[]> GetInfoFromTo(string AirportFrom, string AirportTo, 
            int Class, int Count, string date1, string date2 = null)
        {
            //добавить:
            //учитывать в запросе кол-во оставшихся мест
            //для разных классов пассажиров
            string Request = "SELECT time_from,time_to,a.name as nameFrom, b.name as nameTo, n.number,route_section.route_id,route_section.id from route_section inner join number_seats n on n.type_plane_id IN (select type_plane_id from plane where id in (select plane_id from flight where route_id = route_section.route_id)) AND n.type_seat_id=@Class AND n.number>=@Count inner join airport a on a.id = route_section.from_airport_id inner join airport b on b.id=route_section.to_airport_id WHERE from_airport_id IN (SELECT id from airport where name = @AirportFrom) AND to_airport_id IN(SELECT id from airport where name = @AirportTo) AND time_from>= @DateFrom AND route_id IN(select route_id from flight)";
            //string Request= "SELECT time_from,time_to,a.name as nameFrom, b.name as nameTo, route_id from route_section inner join airport a on a.id = route_section.from_airport_id inner join airport b on b.id=route_section.to_airport_id WHERE from_airport_id IN (SELECT id from airport where name = @AirportFrom) AND to_airport_id IN(SELECT id from airport where name = @AirportTo) AND time_from>= @DateFrom AND route_id IN(select route_id from flight)";
            var command = _connection.CreateCommand();
            command.CommandText = Request;
            command.Parameters.AddWithValue("@AirportFrom", AirportFrom);
            command.Parameters.AddWithValue("@AirportTo", AirportTo);
            command.Parameters.AddWithValue("@DateFrom", date1);
            command.Parameters.AddWithValue("@Class",Class);
            command.Parameters.AddWithValue("@Count",Count);
            var reader = command.ExecuteReader();
            List<string[]> result = new List<string[]>();
            if (reader.HasRows)
            {

                while (reader.Read())
                {
                    result.Add(new string[] { reader.GetDateTime(0).ToString(), reader.GetDateTime(1).ToString(), reader.GetString(2), reader.GetString(3),reader.GetInt32(4).ToString(),reader.GetInt32(5).ToString(),reader.GetInt32(6).ToString() });
                }
            }
            reader.Close();
            return result;
        }
        
        public string GetPrice(int route_section, int nclass)
        {
            string Request = "SELECT value, ts.cost_coeff from tariff inner join type_seat ts on ts.id=@Class where route_section_id=@Route_section_id";
            var command = _connection.CreateCommand();
            command.CommandText = Request;
            command.Parameters.AddWithValue("@Class", nclass);
            command.Parameters.AddWithValue("@Route_section_id", route_section);
            var reader = command.ExecuteReader();
            int price = -1;
            if (reader.HasRows)
            {
                reader.Read();
                int tarif = reader.GetInt32(0);
                double coef = reader.GetDouble(1);
                price =  (int)(tarif*coef);
            }
            reader.Close();
            return price.ToString();
        }

        //отправляет данные о покупке билета в бд
        public void SendData(Ticket ticket)
        {

        }
    }
}
