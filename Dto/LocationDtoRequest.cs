using System.ComponentModel.DataAnnotations;

namespace GoTravnikApi.Dto
{
    public class LocationDtoRequest
    {
        [Required(ErrorMessage = "X coordinate must be provided")]
        public double XCoordinate { get; set; }
        [Required(ErrorMessage = "Y coordinate must be provided")]
        public double YCoordinate { get; set; }
        [Required(ErrorMessage = "Address must be provided")]
        public string Address { get; set; }

        public LocationDtoRequest()
        {
            
        }
    }
}
