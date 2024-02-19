using System.ComponentModel.DataAnnotations;

namespace GoTravnikApi.Dto.RequestDto
{
    public class ImageDtoRequest
    {
        [Required(ErrorMessage = "Url of the image must be provided")]
        public string Url { get; set; } 
        public ImageDtoRequest() { }
    }
}
