using GoTravnikApi.Models;

namespace GoTravnikApi.Dto
{
    public abstract class TouristContentDtoRequest
    { 
        public string Name { get; set; }
        public string Description { get; set; }
        public LocationDtoRequest Location { get; set; }
        public string Image { get; set; }
        public List<SubcategoryDto> Subcategories { get; set; }
        public TouristContentDtoRequest()
        {
            
        }
    }
}
