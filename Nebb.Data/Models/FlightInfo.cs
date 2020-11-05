using System;
using System.Collections.Generic;

namespace Nebb.Data.Models
{
    public partial class FlightInfo
    {
        public FlightInfo()
        {
            Ticket = new HashSet<Ticket>();
        }

        public int Id { get; set; }
        public string Origin { get; set; }
        public string Destination { get; set; }
        public DateTime Departure { get; set; }
        public DateTime? ReturnDay { get; set; }

        public virtual ICollection<Ticket> Ticket { get; set; }
    }
}
