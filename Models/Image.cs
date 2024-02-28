using System.ComponentModel.DataAnnotations;

namespace GoTravnikApi.Models
{
    public class Image
    {
        [Key]
        public int Id { get; set; }
        public string Url { get; set; }
        public TouristContent TouristContent { get; set; } 
        public Image()
        {
        }
        public Image(int id, string url, TouristContent touristContent)
        {
            Id = id;
            Url = url;
            TouristContent = touristContent;    
        }    
    }
}
