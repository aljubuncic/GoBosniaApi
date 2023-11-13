using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace GoTravnikApi.Models
{
    public class Activity : TouristContent
    {
        
        public Activity()
        {
        }

        public Activity(int id, string name, string description, Location location, string image)
        {
            Id = id;
            Name = name;
            Description = description;
            Location = location;
            Image = image;
        }
    }
}

