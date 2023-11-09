using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace GoTravnikApi.Models
{
    public class Attraction : TouristContent
    {
        

        public Attraction()
        {
        }

        public Attraction(int id, string name, string description, string type, int idLocation, Location location, string image)
        {
            Id = id;
            Name = name;
            Description = description;
            IdLocation = idLocation;
            Location = location;
            Image = image;
        }
    }
}
