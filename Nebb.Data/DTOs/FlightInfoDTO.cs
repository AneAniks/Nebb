using System;
using System.ComponentModel.DataAnnotations;
using Nebb.Data.Validators;

namespace Nebb.Data.DTOs
{
    public class FlightInfoDTO
    {
        [IdNotSend(ErrorMessage = "You cannot input an Id of a flight!")]
        public int Id { get; set; }

        [Required(ErrorMessage = "You have to enter an origin")]
        public string Origin { get; set; }

        [Required(ErrorMessage = "You have to enter a destination")]
        public string Destination { get; set; }

        [Required(ErrorMessage = "You have to enter a departure")]
        public DateTime Departure { get; set; }

        [Required(ErrorMessage = "You have to enter a return day")]
        public DateTime? ReturnDay { get; set; }
    }
}
