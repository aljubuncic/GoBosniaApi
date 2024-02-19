using System.ComponentModel.DataAnnotations;

namespace GoTravnikApi.Dto.RequestDto
{
    public class LocationDtoRequest
    {
        [Required(ErrorMessage = "Address must be provided")]
        public string Address { get; set; }
        [Required(ErrorMessage = "City must be provided")]
        public string City { get; set; }
        [Required(ErrorMessage = "X coordinate must be provided")]
        public double XCoordinate { get; set; }
        [Required(ErrorMessage = "Y coordinate must be provided")]
        public double YCoordinate { get; set; }

        public LocationDtoRequest()
        {

        }
    }
}
