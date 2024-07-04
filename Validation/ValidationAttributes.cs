using System;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace RESTAPIProject.Validation.ValidationAttributes 
{
    public class NonNumericSymbolic : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value is string strValue)
            {
                var regex = new Regex(@"[\d`~!@#$%^&*-_=+{};:'?/.>,<()]");
                if (regex.IsMatch(strValue))
                {
                    return new ValidationResult("Names with special characters are invalid");
                }

                return ValidationResult.Success;
            }

            return new ValidationResult("The Name input was not a valid string.");
        }
    }
}