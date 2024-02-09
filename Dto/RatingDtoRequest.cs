using System.ComponentModel.DataAnnotations;

namespace GoTravnikApi.Dto
{
    public class RatingDtoRequest
    {
        [Required]
        [Range(0,5)]
        public int Value { get; set; }
        public string TextComment { get; set; }

        public RatingDtoRequest()
        {
            
        }
    }
}
