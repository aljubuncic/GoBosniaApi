using System.ComponentModel.DataAnnotations.Schema;

namespace GoTravnikApi.Models
{
    public class Rating
    {
        public int Id { get; set; }
        public int Value { get; set; }
        public string TextComment { get; set; }
        [ForeignKey("TouristContent")]
        public int IdTouristContent { get; set;}
        public TouristContent TouristContent { get; set;}
    }
}
