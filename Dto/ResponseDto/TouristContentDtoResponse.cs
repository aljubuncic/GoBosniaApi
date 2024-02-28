using GoTravnikApi.Models;

namespace GoTravnikApi.Dto.ResponseDto
{
    public abstract class TouristContentDtoResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public LocationDtoResponse Location { get; set; }
        public List<SubcategoryDtoResponse> Subcategories { get; set; }
        public List<ImageDtoResponse> Images { get; set; }
        public TouristContentDtoResponse()
        {
        }
    }
}
