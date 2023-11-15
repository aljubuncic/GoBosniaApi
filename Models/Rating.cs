using System.ComponentModel.DataAnnotations.Schema;

namespace GoTravnikApi.Models
{
    public class Rating
    {
        public int Id { get; set; }
        public int Value { get; set; }
        public string TextComment { get; set; }
        public DateTime PostDate { get; set; } = DateTime.Now;
        public bool Approved { get; set; }  

        public Rating() { }

        public Rating(int id, int value, string textComment)
        {
            Id = id;
            Value = value;
            TextComment = textComment;
        }
    }
}
