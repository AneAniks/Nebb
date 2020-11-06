using System;
using System.ComponentModel.DataAnnotations;
using Nebb.Data.Validators;

namespace Nebb.Data.DTOs
{
    public class TicketDTO
    {
        [IdNotSend(ErrorMessage = "You cannot input an Id of a ticket!")]
        public int Id { get; set; }
        [Required(ErrorMessage = "You have to enter a if you have free carry")]
        public bool FreeCarry { get; set; }

        [Required(ErrorMessage = "You have to enter a if you chacked in")]
        public bool CheckedIn { get; set; }

        public bool? TrolleyBag { get; set; }

        [Required(ErrorMessage = "You have to add a Passenger ID")]
        [Range(1, int.MaxValue, ErrorMessage = "Passenger ID needs to be greater than 0")]
        public int PassengerId { get; set; }

        [Required(ErrorMessage = "You have to add a Flight ID")]
        [Range(1, int.MaxValue, ErrorMessage = "Flight ID needs to be greater than 0")]
        public int FlightId { get; set; }

        public virtual PassengerInfoDTO Passenger { get; set; }
        public virtual FlightInfoDTO Flight { get; set; }
    }
}
