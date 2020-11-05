using System;
using System.Collections.Generic;
using System.Text;
using Nebb.Data.Models;

namespace Nebb.Data.ViewModels
{
    public class TicketAViewModel
    {
        public int Id { get; set; }
        //Passenger
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Passport { get; set; }

        //Flight
        public string Origin { get; set; }
        public string Destination { get; set; }
        public DateTime Departure { get; set; }
        public DateTime? ReturnDay { get; set; }

        //Ticket
        public bool FreeCarry { get; set; }
        public bool CheckedIn { get; set; }
        public bool? TrolleyBag { get; set; }

        public virtual PassengerInfo PassengerInfo { get; set; }
        public virtual FlightInfo FlightInfo { get; set; }
        public virtual Ticket Ticket { get; set; }
    }
}
