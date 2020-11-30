using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Airline_Client.Models
{
    public class Ticket
    {
        public int TicketId { get; set; }

        public string PassengerName { get; set; }
        public int Age { get; set; }

        public DateTime DateOfJourney { get; set; }

        public string StartingLocation { get; set; }

        public string Destination { get; set; }

        public int FlightId { get; set; }
    }
}
