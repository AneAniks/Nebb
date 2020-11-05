using System;
using System.Collections.Generic;

namespace Nebb.Data.Models
{
    public partial class PassengerInfo
    {
        public PassengerInfo()
        {
            Ticket = new HashSet<Ticket>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Passport { get; set; }
        public string LoyalMemberId { get; set; }
        public bool? UseLoyalMember { get; set; }

        public virtual ICollection<Ticket> Ticket { get; set; }
    }
}
