using GoTravnikApi.Models;

namespace GoTravnikApi.Dto
{
    public abstract class TouristContentDtoResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public LocationDtoResponse Location { get; set; }
        public string Image { get; set; }
        public List<SubcategoryDto> Subcategories { get; set; }
        public List<Rating> Ratings { get; set; }
        public TouristContentDtoResponse()
        {
            
        }
    }
}
