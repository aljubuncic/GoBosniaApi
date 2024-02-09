using System.ComponentModel.DataAnnotations;

namespace GoTravnikApi.Validations
{
    public class StartDateBeforeEndDateAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext context)
        {
            var startDate = (DateTime)value;
            var endDate = (DateTime)context.ObjectInstance.GetType().GetProperty("EndDate").GetValue(context.ObjectInstance);

            if (startDate >= endDate)
            {
                return new ValidationResult("Start date must be before end date.");
            }

            return ValidationResult.Success;
        }
    }
}
