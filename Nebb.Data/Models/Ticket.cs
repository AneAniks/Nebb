using System;
using System.Collections.Generic;

namespace Nebb.Data.Models
{
    public partial class Ticket
    {
        public int Id { get; set; }
        public bool FreeCarry { get; set; }
        public bool CheckedIn { get; set; }
        public bool? TrolleyBag { get; set; }
        public int PassengerId { get; set; }
        public int FlightId { get; set; }

        public virtual FlightInfo Flight { get; set; }
        public virtual PassengerInfo Passenger { get; set; }
    }
}
