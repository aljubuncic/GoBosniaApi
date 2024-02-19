using GoTravnikApi.Validations;
using System.ComponentModel.DataAnnotations;

namespace GoTravnikApi.Dto.RequestDto
{
    public class EventDtoRequest : TouristContentDtoRequest
    {
        [Required(ErrorMessage = "Start date must be provided")]
        [DataType(DataType.DateTime, ErrorMessage = "Start date is in invalid format")]
        [StartDateBeforeEndDate]
        public DateTime StartDate { get; set; }
        [Required(ErrorMessage = "End date must be provided")]
        [DataType(DataType.DateTime, ErrorMessage = "End date is in invalid format")]
        public DateTime EndDate { get; set; }

        public EventDtoRequest()
        {
        }
    }
}
