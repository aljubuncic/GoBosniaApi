using GoTravnikApi.Models;
using System.ComponentModel.DataAnnotations;

namespace GoTravnikApi.Dto.RequestDto
{
    public abstract class TouristContentDtoRequest
    {
        [Required(ErrorMessage = "Name must be provided")]
        public string Name { get; set; }
        public string Description { get; set; }
        [Required(ErrorMessage = "Location must be provided")]
        public LocationDtoRequest Location { get; set; }
        public string Image { get; set; }
        [MinLength(1, ErrorMessage = "There must be atleast one subcategory provided")]
        public List<SubcategoryDtoRequest> Subcategories { get; set; }
        public TouristContentDtoRequest()
        {
        }
    }
}
