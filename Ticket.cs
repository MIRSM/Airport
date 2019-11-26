using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airport
{
    public class Ticket
    {
        public Place Place { get; set; }

        public string Date { get; set; }

        public string Departure { get; set; }

        public string Arrival { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Surname { get; set; }

        public uint   Price { get; set; }

        public string Plane { get; set; }

        public bool bBought { get; }

        public Ticket(string date, string departure, string arrival,
            string firstName, string lastName, string surName, 
            Place place, uint price, string plane, bool bought = true)
        {
            Plane = plane;
            Place = place;
            Date = date;
            Departure = departure;
            Arrival = arrival;
            FirstName = firstName;
            LastName = lastName;
            Surname = surName;
            Price = price;
            bBought = bought;
        }
    }
}
