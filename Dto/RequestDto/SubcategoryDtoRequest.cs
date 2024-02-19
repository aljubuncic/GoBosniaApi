using GoTravnikApi.Models;
using System.ComponentModel.DataAnnotations;

namespace GoTravnikApi.Dto.RequestDto
{
    public class SubcategoryDtoRequest
    {
        [Required(ErrorMessage = "Name of subcategory must be provided")]
        public string Name { get; set; }

        public SubcategoryDtoRequest()
        {

        }
    }
}
