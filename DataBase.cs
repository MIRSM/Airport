using System.Collections.Generic;
using System.Data.SqlClient;

namespace Airport
{
    public class DataBase 
    {
        private static SqlConnection _connection;

        public DataBase()
        {

            // Рефакторинг: 1. Составление методов (вынесение метода)
             
             /*string datasource = @"DESKTOP-N625QE2";

            string database = "AirportDB";

            string ConnString = @"Data Source=" + datasource + ";Initial Catalog=" + database + ";Integrated Security=True";

            _connection = new SqlConnection(ConnString);
            _connection.Open();
             
            InitConnection();*/
        }

        public static void InitConnection()
        {
            if (_connection != null)
                return;
            _connection = Connect();
            _connection.Open();
        }

        public static void CloseConnection()
        {
            _connection.Close();
        }

        //Рефакторинг: Составление методов (вынесение метода)
        private static SqlConnection Connect()
        {
            string datasource = @"DESKTOP-N625QE2";
            string database = "AirportDB";
            string ConnString = @"Data Source=" + datasource + ";Initial Catalog=" + database + ";Integrated Security=True";

            SqlConnection conn = new SqlConnection(ConnString);
            return conn;
        }

        public static List<string> GetAirports()
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

        public static List<string[]> GetInfoFromTo(string AirportFrom, string AirportTo, 
            int Class, int Count, string date)
        {
            string Request = "SELECT time_from,time_to,a.name as nameFrom, b.name as nameTo, n.number,route_section.route_id,route_section.id from route_section inner join number_seats n on n.type_plane_id IN (select type_plane_id from plane where id in (select plane_id from flight where route_id = route_section.route_id)) AND n.type_seat_id=@Class AND n.number>=@Count inner join airport a on a.id = route_section.from_airport_id inner join airport b on b.id=route_section.to_airport_id WHERE from_airport_id IN (SELECT id from airport where name = @AirportFrom) AND to_airport_id IN(SELECT id from airport where name = @AirportTo) AND time_from>= @DateFrom AND route_id IN(select route_id from flight)";
            var command = _connection.CreateCommand();
            command.CommandText = Request;
            command.Parameters.AddWithValue("@AirportFrom", AirportFrom);
            command.Parameters.AddWithValue("@AirportTo", AirportTo);
            command.Parameters.AddWithValue("@DateFrom", date);
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

        public static string GetPrice(int route_section, int nclass)
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
                price = (int)(tarif*coef);
            }
            reader.Close();
            return price.ToString();
        }

        public static bool AddUserWithTicket(string Fio, int SeatNumber, int TypeSeatId, int RouteSectionId, int TypeStatusId)
        {
            var command = _connection.CreateCommand();
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.CommandText = "AddUserWithTicket";

            command.Parameters.AddWithValue("@FIO",Fio);
            command.Parameters.AddWithValue("@SeatNumber", SeatNumber);
            command.Parameters.AddWithValue("@TypeSeatId", TypeSeatId);
            command.Parameters.AddWithValue("@RouteSectionId", RouteSectionId);
            command.Parameters.AddWithValue("@TypeStatusId", TypeStatusId);
            command.ExecuteNonQuery();
            return true;
        }

        public static MaxStatistic GetMostPopularRoute()
        {
            string Request = "select * from MostPopularRoute";
            var command = _connection.CreateCommand();
            command.CommandText = Request;
            var reader = command.ExecuteReader();
            MaxStatistic maxStatistic = new MaxStatistic();
            if (reader.HasRows)
            {
                reader.Read();
                maxStatistic.MaxCount= reader.GetInt32(0);
                maxStatistic.From= reader.GetString(1);
                maxStatistic.To = reader.GetString(2);
            }
            reader.Close();
            return maxStatistic;
        }

        public static int ReturnTicket(string Fio, int RouteSectionId)
        {
            var command = _connection.CreateCommand();
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.CommandText = "ReturnTicket";

            command.Parameters.AddWithValue("@FIO", Fio);
            command.Parameters.AddWithValue("@RouteSectionId", RouteSectionId);

            return (int)command.ExecuteScalar();
        }

        public static List<int> GetNotAvailablePlaces(int RouteSectionId, int TypeSeatId)
        {
            string Request = "select Номер_места from ticket where flight_id in (select id from flight where route_id = (select route_id from route_section where id=@RouteSectionId)) and type_seat_id = @TypeSeatId and  id not in (select ticket_id from status_ticket where status_id=3);";
            var command = _connection.CreateCommand();
            command.CommandText = Request;
            command.Parameters.AddWithValue("@RouteSectionId", RouteSectionId);
            command.Parameters.AddWithValue("@TypeSeatId", TypeSeatId);
            var reader = command.ExecuteReader();
            List<int> NotAvailablePlaces = new List<int>();
            if (reader.HasRows)
            {
                while(reader.Read())
                {
                    NotAvailablePlaces.Add(reader.GetInt32(0));
                }
            }
            reader.Close();
            return NotAvailablePlaces;
        }

        public static int GetFirstSeatIndex(int RouteSectionId, int TypeSeatId)
        {
            string Request = "select number from number_seats where type_seat_id <> @TypeSeatId and type_plane_id in (select type_plane_id from plane where id in (select plane_id from flight where route_id in (select route_id from route_section where id=@RouteSectionId)))";
            var command = _connection.CreateCommand();
            command.CommandText = Request;
            command.Parameters.AddWithValue("@RouteSectionId", RouteSectionId);
            command.Parameters.AddWithValue("@TypeSeatId", TypeSeatId);
            return (int)command.ExecuteScalar();
        }

        public static int GetNumberOfSeats(int RouteSectionId, int TypeSeatId)
        {
            string Request = "select number from number_seats where type_seat_id=@TypeSeatId and type_plane_id in (select type_plane_id from plane where id in (select plane_id from flight where route_id in (select route_id from route_section where id = @RouteSectionId)))";
            var command = _connection.CreateCommand();
            command.CommandText = Request;
            command.Parameters.AddWithValue("@RouteSectionId", RouteSectionId);
            command.Parameters.AddWithValue("@TypeSeatId", TypeSeatId);
            return (int)command.ExecuteScalar();
        }

        public static int CheckClientForTicket(string Fio, int RouteSectionId)
        {
            var command = _connection.CreateCommand();
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.CommandText = "CheckClientForTicket";

            command.Parameters.AddWithValue("@FIO", Fio);
            command.Parameters.AddWithValue("@RouteSectionId", RouteSectionId);
            return (int)command.ExecuteScalar();
        }

        public static int GetPlace(string Fio, int RouteSectionId)
        {
            string Request = "select Номер_места from ticket where client_id = (select id from client where client.full_name = @Fio) and flight_id = (select id from flight where route_id = (select route_id from route_section where id=@RouteSectionId))";
            var command = _connection.CreateCommand();
            command.CommandText = Request;
            command.Parameters.AddWithValue("@RouteSectionId", RouteSectionId);
            command.Parameters.AddWithValue("@Fio", Fio);
            return (int)command.ExecuteScalar();
        }

    }
}
