using System.ComponentModel.DataAnnotations;

namespace GoTravnikApi.Dto.RequestDto
{
    public abstract class ContactInformationRatedTouristContentDtoRequest : RatedTouristContentDtoRequest
    {
        public string? Website { get; set; }
        [Required(ErrorMessage = "Telephone number must be provided")]
        public string TelephoneNumber { get; set; }
        public ContactInformationRatedTouristContentDtoRequest()
        {
        }
    }
}
