using GoTravnikApi.Models;
using System.ComponentModel.DataAnnotations;

namespace GoTravnikApi.Dto
{
    public class SubcategoryDto
    {
        [Required(ErrorMessage = "Name of subcategory must be provided")]
        public string Name { get; set; }

        public SubcategoryDto()
        {
            
        }
    }
}
