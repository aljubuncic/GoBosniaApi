using GoTravnikApi.Models;

namespace GoTravnikApi.Dto
{
    public abstract class TouristContentDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Location Location { get; set; }
        public string Image { get; set; }
        public List<SubcategoryDto> Subcategories { get; set; }
        public List<Rating> Ratings { get; set; }
    }
}
