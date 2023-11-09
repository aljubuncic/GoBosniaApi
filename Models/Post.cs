using System.ComponentModel.DataAnnotations;

namespace GoTravnikApi.Models
{
    public class Post : TouristContent
    {
        public DateTime PostDate { get; set; }

        public Post()
        {
        }

        public Post(int id, string name, string description, string type, int idRating, Rating rating, int idLocation, Location location, string image, DateTime postDate)
        {
            Id = id;
            Name = name;
            Description = description;
            IdLocation = idLocation;
            Location = location;
            Image = image;
            PostDate = postDate;
        }
    }
}
