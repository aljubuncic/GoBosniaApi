using System.ComponentModel.DataAnnotations;

namespace GoTravnikApi.Dto.ResponseDto
{
    public abstract class ContactInformationRatedTouristContentDtoResponse : RatedTouristContentDtoResponse
    {
        public string? Website { get; set; }
        public string TelephoneNumber { get; set; }
        public ContactInformationRatedTouristContentDtoResponse()
        {
        }
    }
}
