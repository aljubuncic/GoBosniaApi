using GoTravnikApi.Models;

namespace GoTravnikApi.Dto
{
    public class SubcategoryDto
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public SubcategoryDto()
        {
            
        }
        public SubcategoryDto(Subcategory subcategory)
        {
            Id = subcategory.Id;
            Name = subcategory.Name;
        }
    }
}
