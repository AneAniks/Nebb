using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Nebb.Data.Validators;

namespace Nebb.Data.DTOs
{
    public class PassengerInfoDTO
    {
        [IdNotSend(ErrorMessage = "You cannot input an Id of a passenger!")]
        public int Id { get; set; }

        [Required(ErrorMessage = "You have to enter a First Name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "You have to enter a Last Name")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "You have to enter date of birth")]
        public DateTime DateOfBirth { get; set; }

        [Required(ErrorMessage = "You have to enter your passport number")]
        public string Passport { get; set; }

        public string LoyalMemberId { get; set; }

        public bool? UseLoyalMember { get; set; }
    }
}
