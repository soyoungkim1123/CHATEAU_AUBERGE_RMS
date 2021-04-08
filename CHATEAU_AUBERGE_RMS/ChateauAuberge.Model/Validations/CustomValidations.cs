using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ChateauAuberge.Model
{
    internal class DateOfBirthAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            int age = (DateTime.Now.Year - ((DateTime)value).Year);
            if(DateTime.Now.DayOfYear <= ((DateTime)value).DayOfYear)
            {
                age = age - 1;
            }

            if((DateTime)value >= DateTime.Now) {
                return new ValidationResult("Date of birth can not be in future.");
            }

            if(age < 19)
            {
                return new ValidationResult("Guest must be legal age.");
            }
            return ValidationResult.Success;
            
        }
    }
   
}
