using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Airline_Client.Models
{
    public class Flight
    {
        public int FlightId { get; set; }
        public string Company_Name { get; set; }

        public string Starting_Location { get; set; }

        public string Destination { get; set; }

        public int Available_Seats { get; set; }
    }
}
