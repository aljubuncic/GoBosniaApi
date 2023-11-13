using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace GoTravnikApi.Models
{
    public class Attraction : TouristContent
    {
        

        public Attraction()
        {
        }

        public Attraction(int id, string name, string description, string type, Location location, string image)
        {
            Id = id;
            Name = name;
            Description = description;
            Location = location;
            Image = image;
        }
    }
}
