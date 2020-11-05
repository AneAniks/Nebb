using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Nebb.Data.Validators
{
    public class IdNotSendAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            return (value == null || Convert.ToInt32(value) == 0)
                ? ValidationResult.Success
                : new ValidationResult("Id should not be set.");
        }
    }
}
