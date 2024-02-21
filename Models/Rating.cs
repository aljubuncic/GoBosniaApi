using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GoTravnikApi.Models
{
    public class Rating
    {
        [Key]
        public int Id { get; set; }
        public int Value { get; set; }
        public string? TextComment { get; set; }
        public DateTime PostDate { get; set; } = DateTime.Now;
        public bool Approved { get; set; } = false;
        [ForeignKey(nameof(RatedTouristContent))]
        public int RatedTouristContentId { get; set; }  
        public RatedTouristContent RatedTouristContent { get; set; }

        public Rating() { }

        public Rating(int id, int value, string textComment, RatedTouristContent ratedTouristContent)
        {
            Id = id;
            Value = value;
            TextComment = textComment;
            RatedTouristContentId = ratedTouristContent.Id;
            RatedTouristContent = ratedTouristContent;
        }
    }
}
